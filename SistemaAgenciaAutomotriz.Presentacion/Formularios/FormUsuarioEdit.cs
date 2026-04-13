using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Dominio.Entities;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormUsuarioEdit : Form
{
    public Usuario? Usuario { get; private set; }
    private bool _esNuevo;

    public FormUsuarioEdit(Usuario? usuario = null)
    {
        InitializeComponent();
        _esNuevo = usuario == null;
        Usuario = usuario ?? new Usuario { Rol = RolUsuario.Cajero };
        CargarDatos();
    }

    private void CargarDatos()
    {
        txtId.Text = _esNuevo ? "Auto" : Usuario!.Id.ToString();
        txtNombre.Text = Usuario!.Nombre;
        txtUsername.Text = Usuario.Username;
        cmbRol.SelectedItem = Usuario.Rol;
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
        {
            MessageBox.Show("Nombre y usuario son obligatorios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Usuario!.Nombre = txtNombre.Text.Trim();
        Usuario.Username = txtUsername.Text.Trim();
        if (!string.IsNullOrEmpty(txtPassword.Text))
            Usuario.PasswordHash = txtPassword.Text;
        Usuario.Rol = (RolUsuario)cmbRol.SelectedItem!;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
