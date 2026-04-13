using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Dominio.Entities;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormVentaList : Form
{
    private readonly IVentaServicio _ventaServicio;

    public FormVentaList(IVentaServicio ventaServicio)
    {
        InitializeComponent();
        _ventaServicio = ventaServicio;
        CargarVentas();
    }

    private async void CargarVentas()
    {
        try
        {
            var ventas = await _ventaServicio.GetAllConVehiculoAsync();
            dgvVentas.DataSource = ventas.Select(v => new
            {
                v.Id,
                v.Fecha,
                Cliente = v.Cliente?.Nombre ?? "Sin cliente",
                Vehiculo = v.Vehiculo != null ? $"{v.Vehiculo.Marca} {v.Vehiculo.Modelo}" : "Sin vehículo",
                v.Subtotal,
                v.IVA,
                v.Total,
                MetodoPago = v.MetodoPago.ToString(),
                TipoPago = v.TipoPagoVEH.ToString(),
                Estado = v.Estatus.ToString()
            }).ToList();

            dgvVentas.Columns["Id"].Width = 50;
            dgvVentas.Columns["Fecha"].Width = 120;
            dgvVentas.Columns["Cliente"].Width = 120;
            dgvVentas.Columns["Vehiculo"].Width = 150;
            dgvVentas.Columns["Subtotal"].Width = 90;
            dgvVentas.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            dgvVentas.Columns["IVA"].Width = 80;
            dgvVentas.Columns["IVA"].DefaultCellStyle.Format = "C2";
            dgvVentas.Columns["Total"].Width = 100;
            dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvVentas.Columns["MetodoPago"].Width = 80;
            dgvVentas.Columns["TipoPago"].Width = 80;
            dgvVentas.Columns["Estado"].Width = 80;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnActualizar_Click(object sender, EventArgs e)
    {
        CargarVentas();
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}