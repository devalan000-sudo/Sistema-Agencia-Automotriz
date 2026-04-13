using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormProductoList : Form
{
    private readonly IProductoServicio _productoServicio;
    private readonly ICategoriaServicio _categoriaServicio;

    public FormProductoList(IProductoServicio productoServicio, ICategoriaServicio categoriaServicio)
    {
        InitializeComponent();
        _productoServicio = productoServicio;
        _categoriaServicio = categoriaServicio;
        ConfigurarPermisos();
        CargarProductos();
    }

    private void ConfigurarPermisos()
    {
        bool puedeGestionar = SesionActual.EsAdminOSupervisor;
        btnNuevo.Visible = puedeGestionar;
        btnEditar.Visible = puedeGestionar;
        btnEliminar.Visible = puedeGestionar;
    }

    private async void CargarProductos()
    {
        try
        {
            var productos = await _productoServicio.GetAllConCategoriaAsync();
            dgvProductos.DataSource = productos.Select(p => new
            {
                p.Id,
                p.Codigo,
                p.Nombre,
                Categoria = p.Categoria?.Nombre ?? "Sin categoría",
                p.Precio,
                p.Stock,
                p.StockMinimo,
                Estado = p.Stock <= p.StockMinimo ? "BAJO" : "OK"
            }).ToList();

            FormatearColumnas();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void FormatearColumnas()
    {
        dgvProductos.Columns["Id"].Width = 40;
        dgvProductos.Columns["Codigo"].Width = 80;
        dgvProductos.Columns["Nombre"].Width = 200;
        dgvProductos.Columns["Categoria"].Width = 120;
        dgvProductos.Columns["Precio"].Width = 80;
        dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
        dgvProductos.Columns["Stock"].Width = 60;
        dgvProductos.Columns["StockMinimo"].Width = 80;
        dgvProductos.Columns["Estado"].Width = 50;

        foreach (DataGridViewRow row in dgvProductos.Rows)
        {
            if (row.Cells["Estado"].Value?.ToString() == "BAJO")
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
        }
    }

    private async void BuscarProducto()
    {
        var buscar = txtBuscar.Text.Trim().ToLower();
        if (string.IsNullOrEmpty(buscar))
        {
            CargarProductos();
            return;
        }

        var productos = await _productoServicio.GetAllConCategoriaAsync();
        var filtrado = productos.Where(p => 
            p.Nombre.ToLower().Contains(buscar) || 
            p.Codigo.ToLower().Contains(buscar)).ToList();

        dgvProductos.DataSource = filtrado.Select(p => new
        {
            p.Id,
            p.Codigo,
            p.Nombre,
            Categoria = p.Categoria?.Nombre ?? "Sin categoría",
            p.Precio,
            p.Stock,
            p.StockMinimo,
            Estado = p.Stock <= p.StockMinimo ? "BAJO" : "OK"
        }).ToList();

        FormatearColumnas();
    }

    private async void btnNuevo_Click(object sender, EventArgs e)
    {
        var form = new FormProductoEdit(_categoriaServicio);
        if (form.ShowDialog() == DialogResult.OK && form.Producto != null)
        {
            try
            {
                await _productoServicio.CreateAsync(form.Producto);
                CargarProductos();
                MessageBox.Show("Producto creado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnEditar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);
        var producto = await _productoServicio.GetByIdAsync(id);
        
        if (producto != null)
        {
            var form = new FormProductoEdit(_categoriaServicio, producto);
            if (form.ShowDialog() == DialogResult.OK && form.Producto != null)
            {
                try
                {
                    await _productoServicio.UpdateAsync(form.Producto);
                    CargarProductos();
                    MessageBox.Show("Producto actualizado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        if (dgvProductos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);
        var nombre = dgvProductos.SelectedRows[0].Cells["Nombre"].Value.ToString();

        var result = MessageBox.Show($"Eliminar producto '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            try
            {
                await _productoServicio.DeleteAsync(id);
                CargarProductos();
                MessageBox.Show("Producto eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnActualizar_Click(object sender, EventArgs e)
    {
        await _productoServicio.GetAllConCategoriaAsync();
        CargarProductos();
    }
}