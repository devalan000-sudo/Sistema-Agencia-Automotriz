using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormCategoriaList : Form
{
    private readonly ICategoriaServicio _categoriaServicio;

    public FormCategoriaList(ICategoriaServicio categoriaServicio)
    {
        InitializeComponent();
        _categoriaServicio = categoriaServicio;
        ConfigurarPermisos();
        CargarCategorias();
    }

    private void ConfigurarPermisos()
    {
        bool puedeGestionar = SesionActual.EsAdminOSupervisor;
        btnNuevo.Visible = puedeGestionar;
        btnEditar.Visible = puedeGestionar;
        btnEliminar.Visible = puedeGestionar;
    }

    private async void CargarCategorias()
    {
        try
        {
            var categorias = await _categoriaServicio.GetAllAsync();
            dgvCategorias.DataSource = categorias.Select(c => new
            {
                c.Id,
                c.Nombre,
                c.Descripcion
            }).ToList();

            dgvCategorias.Columns["Id"].Width = 50;
            dgvCategorias.Columns["Nombre"].Width = 150;
            dgvCategorias.Columns["Descripcion"].Width = 300;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        var form = new FormCategoriaEdit();
        if (form.ShowDialog() == DialogResult.OK && form.Categoria != null)
        {
            try
            {
                await _categoriaServicio.CreateAsync(form.Categoria);
                CargarCategorias();
                MessageBox.Show("Categoría creada exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvCategorias.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione una categoría", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["Id"].Value);
        var categoria = await _categoriaServicio.GetByIdAsync(id);
        
        if (categoria != null)
        {
            var form = new FormCategoriaEdit(categoria);
            if (form.ShowDialog() == DialogResult.OK && form.Categoria != null)
            {
                try
                {
                    await _categoriaServicio.UpdateAsync(form.Categoria);
                    CargarCategorias();
                    MessageBox.Show("Categoría actualizada exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvCategorias.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione una categoría", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["Id"].Value);
        var nombre = dgvCategorias.SelectedRows[0].Cells["Nombre"].Value.ToString();

        var result = MessageBox.Show($"Eliminar categoría '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                await _categoriaServicio.DeleteAsync(id);
                CargarCategorias();
                MessageBox.Show("Categoría eliminada exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnActualizar_Click(object sender, EventArgs e)
    {
        await _categoriaServicio.GetAllAsync();
        CargarCategorias();
    }
}