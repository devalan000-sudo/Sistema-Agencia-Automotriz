using SistemaAgenciaAutomotriz.Datos.Servicios;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormVehiculoVendidoList : Form
{
    private readonly IVentaServicio _ventaServicio;

    public FormVehiculoVendidoList(IVentaServicio ventaServicio)
    {
        InitializeComponent();
        _ventaServicio = ventaServicio;
        CargarHistorial();
    }

    private async void CargarHistorial()
    {
        try
        {
            var ventas = await _ventaServicio.GetVentasConVehiculoAsync();

            dgvHistorial.DataSource = ventas.Select(v => new
            {
                v.Id,
                Fecha = v.Fecha.ToString("dd/MM/yyyy HH:mm"),
                VIN = v.Vehiculo!.VIN,
                Marca = v.Vehiculo.Marca,
                Modelo = v.Vehiculo.Modelo,
                Year = v.Vehiculo.Year,
                Color = v.Vehiculo.Color,
                Cliente = v.Cliente != null ? v.Cliente.Nombre : "Sin cliente",
                Vendedor = v.Usuario.Nombre,
                TipoPago = v.TipoPagoVEH.ToString(),
                Total = v.Total,
                Estatus = v.Estatus.ToString()
            }).ToList();

            FormatearColumnas();
            CalcularTotales(ventas);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void FormatearColumnas()
    {
        dgvHistorial.Columns["Id"].HeaderText = "Venta";
        dgvHistorial.Columns["Id"].Width = 50;
        dgvHistorial.Columns["Fecha"].Width = 120;
        dgvHistorial.Columns["VIN"].Width = 120;
        dgvHistorial.Columns["Marca"].Width = 80;
        dgvHistorial.Columns["Modelo"].Width = 100;
        dgvHistorial.Columns["Year"].Width = 50;
        dgvHistorial.Columns["Color"].Width = 70;
        dgvHistorial.Columns["Cliente"].Width = 120;
        dgvHistorial.Columns["Vendedor"].Width = 80;
        dgvHistorial.Columns["TipoPago"].Width = 80;
        dgvHistorial.Columns["Total"].Width = 100;
        dgvHistorial.Columns["Total"].DefaultCellStyle.Format = "C2";
        dgvHistorial.Columns["Estatus"].Width = 80;

        foreach (DataGridViewRow row in dgvHistorial.Rows)
        {
            var estatus = row.Cells["Estatus"].Value?.ToString();
            if (estatus == "Cancelada")
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
            else
                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
        }
    }

    private void CalcularTotales(List<Dominio.Entities.Venta> ventas)
    {
        int total = ventas.Count;
        int canceladas = ventas.Count(v => v.Estatus == Dominio.Enumeradores.EstatusVenta.Cancelada);
        decimal montoTotal = ventas.Sum(v => v.Total);

        lblTotal.Text = $"Total: {total} | Canceladas: {canceladas} | Monto: {montoTotal:C2}";
    }

    private async void btnActualizar_Click(object sender, EventArgs e)
    {
        CargarHistorial();
    }

    private void btnCerrar_Click(object sender, EventArgs e)
    {
        Close();
    }
}