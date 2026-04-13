namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormLogin : Form
{
    public string Username => txtUsuario.Text;
    public string Password => txtContrasena.Text;

    public FormLogin()
    {
        InitializeComponent();
    }

    private void btnIngresar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
        {
            MessageBox.Show("Por favor ingrese usuario y contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}