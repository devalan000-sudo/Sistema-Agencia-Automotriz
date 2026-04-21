using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;
using SistemaAgenciaAutomotriz.Dominio.Interfaces;
using SistemaAgenciaAutomotriz.Dominio.ValueObjects;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormVentaAccesorios : Form
{
    private readonly IProductoServicio _productoServicio;
    private readonly IVentaServicio _ventaServicio;
    private readonly IVentaCalculadora _ventaCalculadora;
    private readonly IClienteServicio _clienteServicio;
    private List<Producto> _productos = new();
    private List<VentaDetalle> _carrito = new();
    private List<Cliente> _clientesLista = new();

    public FormVentaAccesorios(IProductoServicio productoServicio, IVentaServicio ventaServicio, IVentaCalculadora ventaCalculadora, IClienteServicio clienteServicio)
    {
        _productoServicio = productoServicio;
        _ventaServicio = ventaServicio;
        _ventaCalculadora = ventaCalculadora;
        _clienteServicio = clienteServicio;
        InitializeComponent();
        CargarDatos();
    }

    private async void CargarDatos()
    {
        _productos = await _productoServicio.GetAllConCategoriaAsync();
        _clientesLista = await _clienteServicio.GetAllAsync();
        BuscarProductos();
    }

    private void BuscarProductos()
    {
        var buscar = txtBuscarAcc.Text.Trim().ToLower();
        if (string.IsNullOrEmpty(buscar))
        {
            dgvProductos.DataSource = _productos.Select(p => new
            {
                p.Id,
                p.Codigo,
                p.Nombre,
                p.Precio,
                p.Stock
            }).ToList();
            FormatearGridProductos();
            return;
        }

        var filtrado = _productos.Where(p =>
            p.Nombre.ToLower().Contains(buscar) ||
            p.Codigo.ToLower().Contains(buscar)).ToList();

        dgvProductos.DataSource = filtrado.Select(p => new
        {
            p.Id,
            p.Codigo,
            p.Nombre,
            p.Precio,
            p.Stock
        }).ToList();
        FormatearGridProductos();
    }
    
    private void FormatearGridProductos()
    {
        if(dgvProductos.Columns["Id"] != null) dgvProductos.Columns["Id"].Visible = false;
        if(dgvProductos.Columns["Precio"] != null) dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
    }

    private void BtnBuscarAcc_Click(object? sender, EventArgs e) => BuscarProductos();

    private void DgvProductos_DoubleClick(object? sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count == 0) return;

        var id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);
        var producto = _productos.FirstOrDefault(p => p.Id == id);

        if (producto != null) AgregarAlCarrito(producto);
    }

    private void AgregarAlCarrito(Producto producto)
    {
        var cantidad = (int)nudCantidad.Value;

        if (producto.Stock < cantidad)
        {
            MessageBox.Show($"Stock insuficiente. Solo hay {producto.Stock} unidades.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var itemExistente = _carrito.FirstOrDefault(c => c.ProductoId == producto.Id);
        if (itemExistente != null)
        {
            var nuevaCantidad = itemExistente.Cantidad + cantidad;
            if (producto.Stock < nuevaCantidad)
            {
                MessageBox.Show($"Stock insuficiente.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            itemExistente.Cantidad = nuevaCantidad;
            itemExistente.Importe = itemExistente.Cantidad * itemExistente.PrecioUnitario;
        }
        else
        {
            _carrito.Add(new VentaDetalle
            {
                ProductoId = producto.Id,
                Producto = producto,
                Cantidad = cantidad,
                PrecioUnitario = producto.Precio,
                Importe = cantidad * producto.Precio
            });
        }

        ActualizarCarrito();
    }

    private void ActualizarCarrito()
    {
        dgvCarrito.DataSource = _carrito.Select(c => new
        {
            c.ProductoId,
            Producto = c.Producto?.Nombre ?? "Accesorio",
            c.Cantidad,
            c.PrecioUnitario,
            c.Importe
        }).ToList();

        if(dgvCarrito.Columns["ProductoId"] != null) dgvCarrito.Columns["ProductoId"].Visible = false;
        if(dgvCarrito.Columns["Producto"] != null) dgvCarrito.Columns["Producto"].Width = 260;
        if(dgvCarrito.Columns["Cantidad"] != null) dgvCarrito.Columns["Cantidad"].Width = 80;
        if(dgvCarrito.Columns["PrecioUnitario"] != null) dgvCarrito.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
        if(dgvCarrito.Columns["Importe"] != null) dgvCarrito.Columns["Importe"].DefaultCellStyle.Format = "C2";

        CalcularTotales();
    }

    private void CalcularTotales()
    {
        TotalesVenta totales = _ventaCalculadora.CalcularTotales(0, _carrito);
        
        lblSubtotalVal.Text = totales.Subtotal.ToString("C2");
        lblIVAVal.Text = totales.IVA.ToString("C2");
        lblTotalVal.Text = totales.Total.ToString("C2");
    }

    private void TxtClienteId_TextChanged(object? sender, EventArgs e)
    {
        UIParserHelper.BuscarYMostrarClienteVisualmente(txtClienteId.Text, _clientesLista, lblNombreCliente);
    }

    private void BtnQuitar_Click(object? sender, EventArgs e)
    {
        if (dgvCarrito.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un item para quitar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvCarrito.SelectedRows[0].Cells["ProductoId"].Value);
        _carrito.RemoveAll(c => c.ProductoId == id);
        ActualizarCarrito();
    }

    private void BtnLimpiar_Click(object? sender, EventArgs e)
    {
        _carrito.Clear();
        txtClienteId.Text = "";
        lblNombreCliente.Text = "--";
        lblNombreCliente.ForeColor = Color.Gray;
        ActualizarCarrito();
    }

    private async void BtnVender_Click(object? sender, EventArgs e)
    {
        if (!ValidarVentaPrevia()) return;

        try
        {
            var venta = ConstruirEntidadVenta();
            await _ventaServicio.CrearVentaAsync(venta, _carrito);
            MostrarReciboYReiniciar(venta);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cobrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #region Metodos Extrapolados de Refactorizacion (SOLID)

    private bool ValidarVentaPrevia()
    {
        if (_carrito.Count == 0)
        {
            MessageBox.Show("El carrito está vacío", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    private Venta ConstruirEntidadVenta()
    {
        var metodoPago = (MetodoPago)(cmbMetodoPago.SelectedIndex + 1);
        TotalesVenta totales = _ventaCalculadora.CalcularTotales(0, _carrito);
        int? clienteRevisadoId = UIParserHelper.ParseIntNullable(txtClienteId.Text);
        var cli = _clientesLista.FirstOrDefault(x => x.Id == clienteRevisadoId);

        return new Venta
        {
            ClienteId = cli?.Id,
            VehiculoId = null,
            UsuarioId = SesionActual.UsuarioLogueado!.Id,
            MetodoPago = metodoPago,
            TipoPagoVEH = TipoPago.Contado, // Siempre es contado en accesorios
            Enganche = 0,
            MontoFinanciado = 0,
            PlazoMeses = 0,
            TasaInteres = 0,
            Mensualidad = 0,
            RequiereSeguro = false,
            Subtotal = totales.Subtotal,
            IVA = totales.IVA,
            Total = totales.Total
        };
    }

    private void MostrarReciboYReiniciar(Venta venta)
    {
        string mensaje = $"Cobro realizado exitosamente!\n\nFolio: {venta.Id}\nTotal: {venta.Total:C2}\nMétodo: {venta.MetodoPago}";
        MessageBox.Show(mensaje, "Venta Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        BtnLimpiar_Click(null, EventArgs.Empty);
        CargarDatos();
    }

    #endregion
}
