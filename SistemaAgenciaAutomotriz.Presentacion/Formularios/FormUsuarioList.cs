using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;
using System.Data;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormUsuarioList : Form
{
    private readonly IUsuarioServicio _usuarioServicio;

    public FormUsuarioList(IUsuarioServicio usuarioServicio)
    {
        InitializeComponent();
        _usuarioServicio = usuarioServicio;
        ConfigurarPermisos();
        CargarUsuarios();
    }

    private void ConfigurarPermisos()
    {
        bool puedeGestionar = SesionActual.EsAdmin;
        btnNuevo.Visible = puedeGestionar;
        btnEditar.Visible = puedeGestionar;
        btnEliminar.Visible = puedeGestionar;
    }

    private async void CargarUsuarios()
    {
        try
        {
            var usuarios = await _usuarioServicio.GetAllAsync();
            dgvUsuarios.DataSource = usuarios.Select(u => new
            {
                u.Id,
                u.Nombre,
                u.Username,
                Rol = u.Rol.ToString(),
                u.FechaAlta
            }).ToList();

            dgvUsuarios.Columns["Id"].Width = 50;
            dgvUsuarios.Columns["Nombre"].Width = 180;
            dgvUsuarios.Columns["Username"].Width = 120;
            dgvUsuarios.Columns["Rol"].Width = 100;
            dgvUsuarios.Columns["FechaAlta"].Width = 120;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        var form = new FormUsuarioEdit();
        if (form.ShowDialog() == DialogResult.OK && form.Usuario != null)
        {
            try
            {
                await _usuarioServicio.CreateAsync(form.Usuario);
                CargarUsuarios();
                MessageBox.Show("Usuario creado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvUsuarios.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);
        var usuario = await _usuarioServicio.GetByIdAsync(id);
        
        if (usuario != null)
        {
            var form = new FormUsuarioEdit(usuario);
            if (form.ShowDialog() == DialogResult.OK && form.Usuario != null)
            {
                try
                {
                    await _usuarioServicio.UpdateAsync(form.Usuario);
                    CargarUsuarios();
                    MessageBox.Show("Usuario actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvUsuarios.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["Id"].Value);
        var nombre = dgvUsuarios.SelectedRows[0].Cells["Nombre"].Value.ToString();

        if (id == SesionActual.UsuarioLogueado?.Id)
        {
            MessageBox.Show("No puede eliminarse a sí mismo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show($"¿Eliminar usuario '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                await _usuarioServicio.DeleteAsync(id);
                CargarUsuarios();
                MessageBox.Show("Usuario eliminado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
