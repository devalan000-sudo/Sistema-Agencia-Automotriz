using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Interfaces;
using SistemaAgenciaAutomotriz.Dominio.Services;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormClienteEdit : Form
{
    public Cliente? Cliente { get; private set; }
    private bool _esNuevo;
    private readonly IValidadorService _validadorService;

    public FormClienteEdit(IValidadorService validadorService, Cliente? cliente = null)
    {
        InitializeComponent();
        _esNuevo = cliente == null;
        _validadorService = validadorService;
        Cliente = cliente ?? new Cliente();

        lblTitulo.Text = _esNuevo ? "Nuevo Cliente" : "Editar Cliente";
        txtId.Text = _esNuevo ? "Auto" : Cliente!.Id.ToString();
        txtNombre.Text = Cliente!.Nombre;
        txtRFC.Text = Cliente.RFC;
        txtEmail.Text = Cliente.Email;
        txtTelefono.Text = Cliente.Telefono;
        txtDireccion.Text = Cliente.Direccion;
        txtLicencia.Text = Cliente.Licencia;
        txtINE.Text = Cliente.INE;
        txtTelefonoEmergencia.Text = Cliente.TelefonoEmergencia;
        txtContactoEmergencia.Text = Cliente.ContactoEmergencia;
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show("El nombre es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Cliente!.Nombre = txtNombre.Text.Trim();
        Cliente.RFC = txtRFC.Text.Trim().ToUpper();
        Cliente.Email = txtEmail.Text.Trim();
        Cliente.Telefono = txtTelefono.Text.Trim();
        Cliente.Direccion = txtDireccion.Text.Trim();
        Cliente.Licencia = txtLicencia.Text.Trim();
        Cliente.INE = txtINE.Text.Trim();
        Cliente.TelefonoEmergencia = txtTelefonoEmergencia.Text.Trim();
        Cliente.ContactoEmergencia = txtContactoEmergencia.Text.Trim();

        var resultado = _validadorService.Validar(Cliente);

        if (!resultado.EsValido)
        {
            MessageBox.Show(
                string.Join("\n", resultado.Errores),
                "Errores de Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            ResaltarCamposConErrores(resultado.ErroresPorCampo);
            return;
        }

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void ResaltarCamposConErrores(Dictionary<string, string> errores)
    {
        ResetearColores();

        foreach (var campo in errores.Keys)
        {
            var control = campo.ToLower() switch
            {
                "nombre" => txtNombre,
                "rfc" => txtRFC,
                "email" => txtEmail,
                "telefono" => txtTelefono,
                "telefonoemergencia" => null,
                "direccion" => txtDireccion,
                _ => null
            };

            if (control != null)
                control.BackColor = Color.LightPink;
        }
    }

    private void ResetearColores()
    {
        txtNombre.BackColor = SystemColors.Window;
        txtRFC.BackColor = SystemColors.Window;
        txtEmail.BackColor = SystemColors.Window;
        txtTelefono.BackColor = SystemColors.Window;
        txtDireccion.BackColor = SystemColors.Window;
    }
}
