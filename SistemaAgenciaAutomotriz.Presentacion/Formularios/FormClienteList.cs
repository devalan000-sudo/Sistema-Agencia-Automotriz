using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Dominio.Services;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormClienteList : Form
{
    private readonly IClienteServicio _clienteServicio;
    private readonly IValidadorService _validadorService;

    public FormClienteList(IClienteServicio clienteServicio, IValidadorService validadorService)
    {
        InitializeComponent();
        _clienteServicio = clienteServicio;
        _validadorService = validadorService;
        ConfigurarPermisos();
        CargarClientes();
    }

    private void ConfigurarPermisos()
    {
        bool puedeCrear = true;
        bool puedeEditar = SesionActual.EsAdminOSupervisor || SesionActual.EsCajero;
        bool puedeEliminar = SesionActual.EsAdminOSupervisor;

        btnNuevo.Visible = puedeCrear;
        btnEditar.Visible = puedeEditar;
        btnEliminar.Visible = puedeEliminar;
    }

    private async void CargarClientes()
    {
        try
        {
            var clientes = await _clienteServicio.GetAllAsync();
            dgvClientes.DataSource = clientes.OrderBy(c => c.Id).Select(c => new
            {
                c.Id,
                c.Nombre,
                c.RFC,
                c.Email,
                c.Telefono,
                c.Direccion,
                c.Licencia,
                c.INE,
                c.TelefonoEmergencia,
                c.ContactoEmergencia,
                c.FechaAlta
            }).ToList();

            dgvClientes.Columns["Id"].Width = 40;
            dgvClientes.Columns["Nombre"].Width = 150;
            dgvClientes.Columns["RFC"].Width = 100;
            dgvClientes.Columns["Email"].Width = 150;
            dgvClientes.Columns["Telefono"].Width = 100;
            dgvClientes.Columns["Direccion"].Width = 150;
            dgvClientes.Columns["Licencia"].Width = 120;
            dgvClientes.Columns["INE"].Width = 120;
            dgvClientes.Columns["TelefonoEmergencia"].Width = 130;
            dgvClientes.Columns["ContactoEmergencia"].Width = 150;
            dgvClientes.Columns["FechaAlta"].Width = 100;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BuscarCliente()
    {
        var buscar = txtBuscar.Text.Trim().ToLower();
        if (string.IsNullOrEmpty(buscar))
        {
            CargarClientes();
            return;
        }

        var clientes = await _clienteServicio.GetAllAsync();
        var filtrado = clientes.Where(c =>
            c.Nombre.ToLower().Contains(buscar) ||
            c.RFC.ToLower().Contains(buscar) ||
            c.Email.ToLower().Contains(buscar)).ToList();

        dgvClientes.DataSource = filtrado.OrderBy(c => c.Id).Select(c => new
        {
            c.Id,
            c.Nombre,
            c.RFC,
            c.Email,
            c.Telefono,
            c.Direccion,
            c.Licencia,
            c.INE,
            c.TelefonoEmergencia,
            c.ContactoEmergencia,
            c.FechaAlta
        }).ToList();
    }

    private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            BuscarCliente();
        }
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        var form = new FormClienteEdit(_validadorService);
        if (form.ShowDialog() == DialogResult.OK && form.Cliente != null)
        {
            try
            {
                await _clienteServicio.CreateAsync(form.Cliente);
                CargarClientes();
                MessageBox.Show("Cliente creado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvClientes.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["Id"].Value);
        var cliente = await _clienteServicio.GetByIdAsync(id);

        if (cliente != null)
        {
            var form = new FormClienteEdit(_validadorService, cliente);
            if (form.ShowDialog() == DialogResult.OK && form.Cliente != null)
            {
                try
                {
                    await _clienteServicio.UpdateAsync(form.Cliente);
                    CargarClientes();
                    MessageBox.Show("Cliente actualizado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvClientes.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["Id"].Value);
        var nombre = dgvClientes.SelectedRows[0].Cells["Nombre"].Value.ToString();

        var result = MessageBox.Show($"Eliminar cliente '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                await _clienteServicio.DeleteAsync(id);
                CargarClientes();
                MessageBox.Show("Cliente eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnVerHistorial_Click(object sender, EventArgs e)
    {
        if (dgvClientes.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["Id"].Value);
        var nombre = dgvClientes.SelectedRows[0].Cells["Nombre"].Value.ToString();

        try
        {
            var ventas = await _clienteServicio.GetHistorialComprasAsync(id);

            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"Historial de Compras - {nombre}");
            sb.AppendLine(new string('=', 50));

            if (ventas.Count == 0)
            {
                sb.AppendLine("No hay compras registradas.");
            }
            else
            {
                decimal total = 0;
                foreach (var venta in ventas)
                {
                    sb.AppendLine($"\nVenta #{venta.Id} - {venta.Fecha:dd/MM/yyyy HH:mm}");
                    sb.AppendLine($"  Estado: {venta.Estatus} | Metodo: {venta.MetodoPago}");
                    sb.AppendLine($"  Total: {venta.Total:C2}");
                    total += venta.Total;
                }
                sb.AppendLine($"\n{new string('-', 50)}");
                sb.AppendLine($"TOTAL COMPRAS: {total:C2}");
            }

            MessageBox.Show(sb.ToString(), "Historial de Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnActualizar_Click(object sender, EventArgs e)
    {
        CargarClientes();
    }
}
