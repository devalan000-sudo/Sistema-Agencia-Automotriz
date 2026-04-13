using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;
using SistemaAgenciaAutomotriz.Dominio.Interfaces;
using SistemaAgenciaAutomotriz.Dominio.ValueObjects;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormVenta : Form
{
    private readonly IVehiculoServicio _vehiculoServicio;
    private readonly IVentaServicio _ventaServicio;
    private readonly IVentaCalculadora _ventaCalculadora;
    private readonly IClienteServicio _clienteServicio;
    private List<Vehiculo> _vehiculos = new();
    private List<Cliente> _clientesLista = new();
    private Vehiculo? _vehiculoSeleccionado;

    public FormVenta(IVehiculoServicio vehiculoServicio, IVentaServicio ventaServicio, IVentaCalculadora ventaCalculadora, IClienteServicio clienteServicio)
    {
        _vehiculoServicio = vehiculoServicio;
        _ventaServicio = ventaServicio;
        _ventaCalculadora = ventaCalculadora;
        _clienteServicio = clienteServicio;
        InitializeComponent();
        dgvVehiculos.SelectionChanged += DgvVehiculos_SelectionChanged;
        CargarDatos();
    }

    private void DgvVehiculos_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvVehiculos.SelectedRows.Count > 0)
        {
            var id = Convert.ToInt32(dgvVehiculos.SelectedRows[0].Cells["Id"].Value);
            _vehiculoSeleccionado = _vehiculos.FirstOrDefault(v => v.Id == id);

            if (_vehiculoSeleccionado != null)
            {
                lblVehiculoSeleccionado.Text = $"{_vehiculoSeleccionado.Marca} {_vehiculoSeleccionado.Modelo} ({_vehiculoSeleccionado.Year})";
                lblVehiculoSeleccionado.ForeColor = Color.FromArgb(0, 120, 215);
                CalcularTotales();
            }
        }
    }

    private async void CargarDatos()
    {
        _vehiculos = await _vehiculoServicio.GetDisponiblesAsync();
        _clientesLista = await _clienteServicio.GetAllAsync();
        
        dgvVehiculos.DataSource = _vehiculos.Select(v => new
        {
            v.Id,
            v.VIN,
            v.Marca,
            v.Modelo,
            v.Year,
            v.Color,
            v.Precio,
            Estado = ((EstatusVehiculo)v.Estatus).ToString()
        }).ToList();

        FormatearGridVehiculos();
        ActualizarDisponibles();
    }

    private void FormatearGridVehiculos()
    {
        dgvVehiculos.Columns["Id"].Visible = false;
        dgvVehiculos.Columns["VIN"].Width = 180;
        dgvVehiculos.Columns["Marca"].Width = 120;
        dgvVehiculos.Columns["Modelo"].Width = 160;
        dgvVehiculos.Columns["Year"].Width = 70;
        dgvVehiculos.Columns["Color"].Width = 100;
        dgvVehiculos.Columns["Precio"].Width = 120;
        dgvVehiculos.Columns["Precio"].DefaultCellStyle.Format = "C2";
        dgvVehiculos.Columns["Estado"].Width = 120;

        foreach (DataGridViewRow row in dgvVehiculos.Rows)
        {
            if (row.Cells["Estado"].Value?.ToString() == "Disponible")
                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
        }
    }

    private void ActualizarDisponibles()
    {
        _vehiculos = _vehiculos.Where(v => v.Estatus == (int)EstatusVehiculo.Disponible).ToList();
        dgvVehiculos.DataSource = _vehiculos.Select(v => new
        {
            v.Id,
            v.VIN,
            v.Marca,
            v.Modelo,
            v.Year,
            v.Color,
            v.Precio,
            Estado = ((EstatusVehiculo)v.Estatus).ToString()
        }).ToList();
        FormatearGridVehiculos();
    }

    private void BuscarVehiculos()
    {
        var buscar = txtBuscar.Text.Trim().ToLower();
        if (string.IsNullOrEmpty(buscar))
        {
            ActualizarDisponibles();
            return;
        }

        var filtrado = _vehiculos.Where(v =>
            v.Marca.ToLower().Contains(buscar) ||
            v.Modelo.ToLower().Contains(buscar) ||
            v.VIN.ToLower().Contains(buscar)).ToList();

        dgvVehiculos.DataSource = filtrado.Select(v => new
        {
            v.Id,
            v.VIN,
            v.Marca,
            v.Modelo,
            v.Year,
            v.Color,
            v.Precio,
            Estado = ((EstatusVehiculo)v.Estatus).ToString()
        }).ToList();
    }

    private void TxtBuscar_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13) BuscarVehiculos();
    }

    private void BtnBuscar_Click(object? sender, EventArgs e)
    {
        BuscarVehiculos();
    }

    private void DgvVehiculos_DoubleClick(object? sender, EventArgs e)
    {
        if (dgvVehiculos.SelectedRows.Count == 0) return;

        var id = Convert.ToInt32(dgvVehiculos.SelectedRows[0].Cells["Id"].Value);
        _vehiculoSeleccionado = _vehiculos.FirstOrDefault(v => v.Id == id);

        if (_vehiculoSeleccionado != null)
        {
            lblVehiculoSeleccionado.Text = $"{_vehiculoSeleccionado.Marca} {_vehiculoSeleccionado.Modelo} ({_vehiculoSeleccionado.Year})";
            lblVehiculoSeleccionado.ForeColor = Color.FromArgb(0, 120, 215);
            
            CalcularTotales();
        }
    }

    private void CalcularTotales()
    {
        decimal precioVehiculo = _vehiculoSeleccionado?.Precio ?? 0;
        var carritoVacioParaHelper = new List<VentaDetalle>();

        if (cmbTipoPago.SelectedIndex == 1) // Financiamiento
        {
            decimal enganche = decimal.TryParse(txtEnganche.Text, out var e) ? e : 0;
            int plazo = int.TryParse(txtPlazo.Text, out var p) ? p : 0;
            decimal tasa = decimal.TryParse(txtTasa.Text, out var t) ? t : 0;

            var financiamiento = new DatosFinanciamiento(
                enganche,
                plazo,
                tasa,
                chkSeguro.Checked,
                precioVehiculo + _ventaCalculadora.CalcularIVA(precioVehiculo)
            );

            TotalesVenta totales = _ventaCalculadora.CalcularTotalesConFinanciamiento(precioVehiculo, carritoVacioParaHelper, financiamiento);

            lblSubtotalVal.Text = totales.Subtotal.ToString("C2");
            lblIVAVal.Text = totales.IVA.ToString("C2");
            lblTotalVal.Text = totales.Total.ToString("C2");

            if (totales.Mensualidad.HasValue && totales.Mensualidad.Value > 0)
            {
                lblMensualidad.Text = $"Mensualidad: {totales.Mensualidad.Value:C2} x {totales.PlazoMeses} meses";
                lblMensualidad.Visible = true;
            }
            else
            {
                lblMensualidad.Visible = false;
            }
        }
        else
        {
            TotalesVenta totales = _ventaCalculadora.CalcularTotales(precioVehiculo, carritoVacioParaHelper);
            
            lblSubtotalVal.Text = totales.Subtotal.ToString("C2");
            lblIVAVal.Text = totales.IVA.ToString("C2");
            lblTotalVal.Text = totales.Total.ToString("C2");
            lblMensualidad.Visible = false;
        }
    }

    private void CmbTipoPago_SelectedIndexChanged(object? sender, EventArgs e)
    {
        bool esFinanciamiento = cmbTipoPago.SelectedIndex == 1;
        pnlFinanciamiento.Visible = esFinanciamiento;
        CalcularTotales();
    }

    private void TxtEnganche_TextChanged(object? sender, EventArgs e)
    {
        CalcularTotales();
    }

    private void TxtPlazo_TextChanged(object? sender, EventArgs e)
    {
        CalcularTotales();
    }

    private void TxtTasa_TextChanged(object? sender, EventArgs e)
    {
        CalcularTotales();
    }

    private void TxtClienteId_TextChanged(object? sender, EventArgs e)
    {
        if (int.TryParse(txtClienteId.Text.Trim(), out int id))
        {
            var c = _clientesLista.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                lblNombreCliente.Text = $"{c.Nombre} (RFC: {c.RFC})";
                lblNombreCliente.ForeColor = Color.Green;
                return;
            }
        }
        
        lblNombreCliente.Text = "Cliente no encontrado";
        lblNombreCliente.ForeColor = Color.Red;
    }

    private void BtnLimpiar_Click(object? sender, EventArgs e)
    {
        _vehiculoSeleccionado = null;
        lblVehiculoSeleccionado.Text = "Sin vehículo seleccionado";
        lblVehiculoSeleccionado.ForeColor = Color.Gray;
        lblMensualidad.Visible = false;
        txtClienteId.Text = "";
        lblNombreCliente.Text = "--";
        lblNombreCliente.ForeColor = Color.Gray;
        CalcularTotales();
    }

    private async void BtnVender_Click(object? sender, EventArgs e)
    {
        if (_vehiculoSeleccionado == null)
        {
            MessageBox.Show("Seleccione un vehículo para la venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var tipoPagoSel = (TipoPago)(cmbTipoPago.SelectedIndex + 1);
        int? clienteId = null;
        if (int.TryParse(txtClienteId.Text.Trim(), out int cid))
        {
            var cli = _clientesLista.FirstOrDefault(x => x.Id == cid);
            if (cli != null)
            {
                clienteId = cid;
            }
        }

        if (tipoPagoSel == TipoPago.Financiamiento && clienteId == null)
        {
            MessageBox.Show("Debe ingresar un ID de Cliente válido para procesar una venta por Financiamiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var tipoPago = (TipoPago)(cmbTipoPago.SelectedIndex + 1);
            var metodoPago = (MetodoPago)(cmbMetodoPago.SelectedIndex + 1);
            decimal precioVehiculo = _vehiculoSeleccionado.Precio;

            decimal enganche = 0, montoFinanciado = 0, tasa = 0, mensualidad = 0;
            int plazo = 0;
            bool requiereSeguro = false;
            TotalesVenta totales;
            var carritoVacioParaHelper = new List<VentaDetalle>();

            if (tipoPago == TipoPago.Financiamiento)
            {
                enganche = decimal.TryParse(txtEnganche.Text, out var e1) ? e1 : 0;
                plazo = int.TryParse(txtPlazo.Text, out var p) ? p : 0;
                tasa = decimal.TryParse(txtTasa.Text, out var t) ? t : 0;
                requiereSeguro = chkSeguro.Checked;

                decimal subtotalEsperado = precioVehiculo;
                decimal ivaEsperado = _ventaCalculadora.CalcularIVA(subtotalEsperado);
                decimal totalEsperado = subtotalEsperado + ivaEsperado;

                var financiamiento = new DatosFinanciamiento(enganche, plazo, tasa, requiereSeguro, totalEsperado);
                totales = _ventaCalculadora.CalcularTotalesConFinanciamiento(precioVehiculo, carritoVacioParaHelper, financiamiento);

                montoFinanciado = financiamiento.MontoFinanciado;
                mensualidad = totales.Mensualidad ?? 0;
            }
            else
            {
                totales = _ventaCalculadora.CalcularTotales(precioVehiculo, carritoVacioParaHelper);
            }

            var venta = new Venta
            {
                ClienteId = clienteId,
                VehiculoId = _vehiculoSeleccionado?.Id,
                UsuarioId = SesionActual.UsuarioLogueado!.Id,
                MetodoPago = metodoPago,
                TipoPagoVEH = tipoPago,
                Enganche = enganche,
                MontoFinanciado = montoFinanciado,
                PlazoMeses = plazo,
                TasaInteres = tasa,
                Mensualidad = mensualidad,
                RequiereSeguro = requiereSeguro,
                Subtotal = totales.Subtotal,
                IVA = totales.IVA,
                Total = totales.Total
            };

            await _ventaServicio.CrearVentaAsync(venta, carritoVacioParaHelper);

            string mensaje = $"Venta realizada exitosamente!\n\nFolio: {venta.Id}\nVehículo: {_vehiculoSeleccionado?.Marca} {_vehiculoSeleccionado?.Modelo}\nTotal: {venta.Total:C2}";
            
            if (tipoPago == TipoPago.Financiamiento)
            {
                mensaje += $"\n\nFinanciamiento:\nEnganche: {enganche:C2}\nPlazo: {plazo} meses\nMensualidad: {mensualidad:C2}";
            }

            MessageBox.Show(mensaje, "Venta Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnLimpiar_Click(null, EventArgs.Empty);
            CargarDatos();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al realizar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}