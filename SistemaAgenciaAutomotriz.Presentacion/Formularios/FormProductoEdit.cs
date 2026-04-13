using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Dominio.Entities;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormProductoEdit : Form
{
    private readonly ICategoriaServicio _categoriaServicio;
    public Producto? Producto { get; private set; }
    private bool _esNuevo;

    public FormProductoEdit(ICategoriaServicio categoriaServicio, Producto? producto = null)
    {
        InitializeComponent();
        _categoriaServicio = categoriaServicio;
        _esNuevo = producto == null;
        Producto = producto ?? new Producto();
        CargarCategorias();
        InicializarControles();
    }

    private void InicializarControles()
    {
        lblTitulo.Text = _esNuevo ? "Nuevo Producto" : "Editar Producto";
        txtId.Text = _esNuevo ? "Auto" : Producto!.Id.ToString();
        txtCodigo.Text = Producto!.Codigo;
        txtNombre.Text = Producto.Nombre;
        txtDescripcion.Text = Producto.Descripcion;
        txtPrecio.Text = Producto.Precio.ToString("F2");
        txtCosto.Text = Producto.Costo.ToString("F2");
        txtStock.Text = Producto.Stock.ToString();
        txtStockMinimo.Text = Producto.StockMinimo.ToString();
    }

    private async void CargarCategorias()
    {
        var categorias = await _categoriaServicio.GetAllAsync();
        cmbCategoria.DataSource = categorias;
        cmbCategoria.DisplayMember = "Nombre";
        cmbCategoria.ValueMember = "Id";
        cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;

        if (Producto!.CategoriaId.HasValue)
            cmbCategoria.SelectedValue = Producto.CategoriaId;
        else
            cmbCategoria.SelectedIndex = -1;
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("Código y nombre son obligatorios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!decimal.TryParse(txtPrecio.Text, out var precio) || precio < 0)
        {
            MessageBox.Show("Precio inválido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!int.TryParse(txtStock.Text, out var stock) || stock < 0)
        {
            MessageBox.Show("Stock inválido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        decimal.TryParse(txtCosto.Text, out var costo);

        int.TryParse(txtStockMinimo.Text, out var stockMinimo);

        Producto!.Codigo = txtCodigo.Text.Trim();
        Producto.Nombre = txtNombre.Text.Trim();
        Producto.Descripcion = txtDescripcion.Text.Trim();
        Producto.Precio = precio;
        Producto.Costo = costo;
        Producto.Stock = stock;
        Producto.StockMinimo = stockMinimo > 0 ? stockMinimo : 5;
        Producto.CategoriaId = cmbCategoria.SelectedValue as int?;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
