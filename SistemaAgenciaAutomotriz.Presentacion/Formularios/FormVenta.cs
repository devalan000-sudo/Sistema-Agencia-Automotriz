using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;
using SistemaAgenciaAutomotriz.Dominio.Interfaces;
using SistemaAgenciaAutomotriz.Dominio.ValueObjects;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
        if(dgvVehiculos.Columns["Id"] != null) dgvVehiculos.Columns["Id"].Visible = false;
        if(dgvVehiculos.Columns["VIN"] != null) dgvVehiculos.Columns["VIN"].Width = 180;
        if(dgvVehiculos.Columns["Marca"] != null) dgvVehiculos.Columns["Marca"].Width = 120;
        if(dgvVehiculos.Columns["Modelo"] != null) dgvVehiculos.Columns["Modelo"].Width = 160;
        if(dgvVehiculos.Columns["Year"] != null) dgvVehiculos.Columns["Year"].Width = 70;
        if(dgvVehiculos.Columns["Color"] != null) dgvVehiculos.Columns["Color"].Width = 100;
        if(dgvVehiculos.Columns["Precio"] != null) 
        {
            dgvVehiculos.Columns["Precio"].Width = 120;
            dgvVehiculos.Columns["Precio"].DefaultCellStyle.Format = "C2";
        }
        if(dgvVehiculos.Columns["Estado"] != null) dgvVehiculos.Columns["Estado"].Width = 120;

        foreach (DataGridViewRow row in dgvVehiculos.Rows)
        {
            if (row.Cells["Estado"].Value?.ToString() == "Disponible")
                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
        }
    }

    private void ActualizarDisponibles()
    {
        _vehiculos = _vehiculos.Where(v => v.Estatus == (int)EstatusVehiculo.Disponible).ToList();
        var listaVacia = _vehiculos.Select(v => new
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
        dgvVehiculos.DataSource = listaVacia;
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
            var financiamiento = new DatosFinanciamiento(
                UIParserHelper.ParseDecimal(txtEnganche.Text),
                UIParserHelper.ParseInt(txtPlazo.Text),
                UIParserHelper.ParseDecimal(txtTasa.Text),
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
        else // Contado
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
        pnlFinanciamiento.Visible = cmbTipoPago.SelectedIndex == 1;
        CalcularTotales();
    }

    private void TxtEnganche_TextChanged(object? sender, EventArgs e) => CalcularTotales();
    private void TxtPlazo_TextChanged(object? sender, EventArgs e) => CalcularTotales();
    private void TxtTasa_TextChanged(object? sender, EventArgs e) => CalcularTotales();

    private void TxtClienteId_TextChanged(object? sender, EventArgs e)
    {
        UIParserHelper.BuscarYMostrarClienteVisualmente(txtClienteId.Text, _clientesLista, lblNombreCliente, txtRFC);
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
        if (!ValidarVentaPrevia()) return;

        try
        {
            var venta = ConstruirEntidadVenta();
            await _ventaServicio.CrearVentaAsync(venta, new List<VentaDetalle>());
            MostrarReciboYReiniciar(venta);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al realizar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #region Metodos Extrapolados de Refactorizacion (SOLID)

    private bool ValidarVentaPrevia()
    {
        if (_vehiculoSeleccionado == null)
        {
            MessageBox.Show("Seleccione un vehículo para la venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var tipoPagoSel = (TipoPago)(cmbTipoPago.SelectedIndex + 1);
        int? clienteId = UIParserHelper.ParseIntNullable(txtClienteId.Text);
        var cli = _clientesLista.FirstOrDefault(x => x.Id == clienteId);

        if (tipoPagoSel == TipoPago.Financiamiento && cli == null)
        {
            MessageBox.Show("Debe ingresar un ID de Cliente válido para procesar una venta por Financiamiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    private Venta ConstruirEntidadVenta()
    {
        var tipoPago = (TipoPago)(cmbTipoPago.SelectedIndex + 1);
        var metodoPago = (MetodoPago)(cmbMetodoPago.SelectedIndex + 1);
        int? clienteId = UIParserHelper.ParseIntNullable(txtClienteId.Text);
        var cli = _clientesLista.FirstOrDefault(x => x.Id == clienteId);

        decimal enganche = 0, montoFinanciado = 0, tasa = 0, mensualidad = 0;
        int plazo = 0;
        bool requiereSeguro = false;
        TotalesVenta totales;
        
        if (tipoPago == TipoPago.Financiamiento)
        {
            enganche = UIParserHelper.ParseDecimal(txtEnganche.Text);
            plazo = UIParserHelper.ParseInt(txtPlazo.Text);
            tasa = UIParserHelper.ParseDecimal(txtTasa.Text);
            requiereSeguro = chkSeguro.Checked;

            decimal totalEsperado = _vehiculoSeleccionado!.Precio + _ventaCalculadora.CalcularIVA(_vehiculoSeleccionado.Precio);
            var financiamiento = new DatosFinanciamiento(enganche, plazo, tasa, requiereSeguro, totalEsperado);
            
            totales = _ventaCalculadora.CalcularTotalesConFinanciamiento(_vehiculoSeleccionado.Precio, new List<VentaDetalle>(), financiamiento);
            montoFinanciado = financiamiento.MontoFinanciado;
            mensualidad = totales.Mensualidad ?? 0;
        }
        else
        {
            totales = _ventaCalculadora.CalcularTotales(_vehiculoSeleccionado!.Precio, new List<VentaDetalle>());
        }

        return new Venta
        {
            ClienteId = cli?.Id,
            VehiculoId = _vehiculoSeleccionado.Id,
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
    }

    private void MostrarReciboYReiniciar(Venta venta)
    {
        string mensaje = $"Venta realizada exitosamente!\n\nFolio: {venta.Id}\nVehículo: {_vehiculoSeleccionado?.Marca} {_vehiculoSeleccionado?.Modelo}\nTotal: {venta.Total:C2}";
        if (venta.TipoPagoVEH == TipoPago.Financiamiento)
        {
            mensaje += $"\n\nFinanciamiento:\nEnganche: {venta.Enganche:C2}\nPlazo: {venta.PlazoMeses} meses\nMensualidad: {venta.Mensualidad:C2}";
        }
        MessageBox.Show(mensaje, "Venta Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        BtnLimpiar_Click(null, EventArgs.Empty);
        CargarDatos();
    }

    #endregion

    private void BtnToggleBottomBar_Click(object? sender, EventArgs e)
    {
        var bottomBar = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "pnlBottomBar");
        if (bottomBar != null) bottomBar.Visible = !bottomBar.Visible;
    }
}
