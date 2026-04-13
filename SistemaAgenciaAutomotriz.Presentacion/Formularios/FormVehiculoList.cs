using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Dominio.Services;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormVehiculoList : Form
{
    private readonly IVehiculoServicio _vehiculoServicio;
    private readonly IValidadorService _validadorService;

    public FormVehiculoList(IVehiculoServicio vehiculoServicio, IValidadorService validadorService)
    {
        InitializeComponent();
        _vehiculoServicio = vehiculoServicio;
        _validadorService = validadorService;
        ConfigurarPermisos();
        CargarVehiculos();
    }

    private void ConfigurarPermisos()
    {
        bool puedeGestionar = SesionActual.EsAdminOSupervisor;
        btnNuevo.Visible = puedeGestionar;
        btnEditar.Visible = puedeGestionar;
        btnEliminar.Visible = puedeGestionar;
    }

    private async void CargarVehiculos()
    {
        try
        {
            var vehiculos = await _vehiculoServicio.GetAllAsync();
            dgvVehiculos.DataSource = vehiculos.OrderBy(v => v.Id).Select(v => new
            {
                v.Id,
                v.VIN,
                v.Marca,
                v.Modelo,
                v.Year,
                v.Color,
                v.Kilometraje,
                v.Precio,
                Tipo = ((TipoVehiculo)v.Tipo).ToString(),
                Estado = ((EstatusVehiculo)v.Estatus).ToString()
            }).ToList();

            FormatearColumnas();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar vehículos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void FormatearColumnas()
    {
        dgvVehiculos.Columns["Id"].Width = 40;
        dgvVehiculos.Columns["VIN"].Width = 150;
        dgvVehiculos.Columns["Marca"].Width = 100;
        dgvVehiculos.Columns["Modelo"].Width = 120;
        dgvVehiculos.Columns["Year"].Width = 60;
        dgvVehiculos.Columns["Color"].Width = 80;
        dgvVehiculos.Columns["Kilometraje"].Width = 100;
        dgvVehiculos.Columns["Precio"].Width = 100;
        dgvVehiculos.Columns["Precio"].DefaultCellStyle.Format = "C2";
        dgvVehiculos.Columns["Tipo"].Width = 80;
        dgvVehiculos.Columns["Estado"].Width = 90;

        foreach (DataGridViewRow row in dgvVehiculos.Rows)
        {
            var estado = row.Cells["Estado"].Value?.ToString();
            if (estado == "Disponible")
                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200);
            else if (estado == "Reservado")
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200);
            else if (estado == "Vendido")
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
        }
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        var form = new FormVehiculoEdit(_validadorService);
        if (form.ShowDialog() == DialogResult.OK && form.Vehiculo != null)
        {
            try
            {
                await _vehiculoServicio.CreateAsync(form.Vehiculo);
                CargarVehiculos();
                MessageBox.Show("Vehículo agregado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvVehiculos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un vehículo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvVehiculos.SelectedRows[0].Cells["Id"].Value);
        var vehiculo = await _vehiculoServicio.GetByIdAsync(id);

        if (vehiculo != null)
        {
            var form = new FormVehiculoEdit(_validadorService, vehiculo);
            if (form.ShowDialog() == DialogResult.OK && form.Vehiculo != null)
            {
                try
                {
                    await _vehiculoServicio.UpdateAsync(form.Vehiculo);
                    CargarVehiculos();
                    MessageBox.Show("Vehículo actualizado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvVehiculos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un vehículo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvVehiculos.SelectedRows[0].Cells["Id"].Value);
        var nombre = $"{dgvVehiculos.SelectedRows[0].Cells["Marca"].Value} {dgvVehiculos.SelectedRows[0].Cells["Modelo"].Value}";

        var result = MessageBox.Show($"Eliminar vehículo '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                await _vehiculoServicio.DeleteAsync(id);
                CargarVehiculos();
                MessageBox.Show("Vehículo eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnActualizar_Click(object sender, EventArgs e)
    {
        await _vehiculoServicio.GetAllAsync();
        CargarVehiculos();
    }
}