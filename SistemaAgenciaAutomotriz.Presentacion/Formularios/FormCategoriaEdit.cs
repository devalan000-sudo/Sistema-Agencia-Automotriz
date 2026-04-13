using SistemaAgenciaAutomotriz.Dominio.Entities;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormCategoriaEdit : Form
{
    public Categoria? Categoria { get; private set; }
    private bool _esNuevo;

    public FormCategoriaEdit(Categoria? categoria = null)
    {
        InitializeComponent();
        _esNuevo = categoria == null;
        Categoria = categoria ?? new Categoria();

        txtId.Text = _esNuevo ? "Auto" : Categoria!.Id.ToString();
        txtNombre.Text = Categoria!.Nombre;
        txtDescripcion.Text = Categoria.Descripcion;
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("El nombre es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Categoria!.Nombre = txtNombre.Text.Trim();
        Categoria.Descripcion = txtDescripcion.Text.Trim();

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}