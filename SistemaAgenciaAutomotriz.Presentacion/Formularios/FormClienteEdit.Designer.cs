using System.Windows.Forms;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormClienteEdit : Form
{
    private TextBox txtId;
    private TextBox txtNombre;
    private TextBox txtRFC;
    private TextBox txtEmail;
    private TextBox txtTelefono;
    private TextBox txtDireccion;
    private TextBox txtLicencia;
    private TextBox txtINE;
    private TextBox txtTelefonoEmergencia;
    private TextBox txtContactoEmergencia;
    private Button btnGuardar;
    private Button btnCancelar;
    private Label lblTitulo;

    private void InitializeComponent()
    {
        txtId = new TextBox();
        txtNombre = new TextBox();
        txtRFC = new TextBox();
        txtEmail = new TextBox();
        txtTelefono = new TextBox();
        txtDireccion = new TextBox();
        txtLicencia = new TextBox();
        txtINE = new TextBox();
        txtTelefonoEmergencia = new TextBox();
        txtContactoEmergencia = new TextBox();
        btnGuardar = new Button();
        btnCancelar = new Button();
        lblTitulo = new Label();

        this.SuspendLayout();

        int y = 20;

        lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(0, 120, 215);
        lblTitulo.Location = new Point(20, y);
        lblTitulo.Size = new Size(380, 30);
        this.Controls.Add(lblTitulo);
        y += 40;

        AddLabel("ID:", ref y);
        txtId.Location = new Point(160, y); txtId.Size = new Size(80, 23); txtId.ReadOnly = true; txtId.BackColor = SystemColors.Control;
        this.Controls.Add(txtId);
        y += 30;

        AddLabel("Nombre:", ref y);
        txtNombre.Location = new Point(160, y); txtNombre.Size = new Size(300, 23);
        this.Controls.Add(txtNombre);
        y += 30;

        AddLabel("RFC:", ref y);
        txtRFC.Location = new Point(160, y); txtRFC.Size = new Size(150, 23);
        this.Controls.Add(txtRFC);
        y += 30;

        AddLabel("Email:", ref y);
        txtEmail.Location = new Point(160, y); txtEmail.Size = new Size(300, 23);
        this.Controls.Add(txtEmail);
        y += 30;

        AddLabel("Teléfono:", ref y);
        txtTelefono.Location = new Point(160, y); txtTelefono.Size = new Size(150, 23);
        this.Controls.Add(txtTelefono);
        y += 30;

        AddLabel("Dirección:", ref y);
        txtDireccion.Location = new Point(160, y); txtDireccion.Size = new Size(300, 50);
        txtDireccion.Multiline = true;
        this.Controls.Add(txtDireccion);
        y += 60;

        AddLabel("Licencia:", ref y);
        txtLicencia.Location = new Point(160, y); txtLicencia.Size = new Size(150, 23);
        this.Controls.Add(txtLicencia);
        y += 30;

        AddLabel("INE:", ref y);
        txtINE.Location = new Point(160, y); txtINE.Size = new Size(150, 23);
        this.Controls.Add(txtINE);
        y += 30;

        AddLabel("Tel. Emergencia:", ref y);
        txtTelefonoEmergencia.Location = new Point(160, y); txtTelefonoEmergencia.Size = new Size(150, 23);
        this.Controls.Add(txtTelefonoEmergencia);
        y += 30;

        AddLabel("Contacto Emergencia:", ref y);
        txtContactoEmergencia.Location = new Point(160, y); txtContactoEmergencia.Size = new Size(300, 23);
        this.Controls.Add(txtContactoEmergencia);
        y += 30;

        btnGuardar.BackColor = Color.FromArgb(0, 120, 215);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Location = new Point(190, y);
        btnGuardar.Size = new Size(120, 35);
        btnGuardar.Text = "Guardar";
        btnGuardar.Click += btnGuardar_Click;
        this.Controls.Add(btnGuardar);

        btnCancelar.BackColor = Color.Gray;
        btnCancelar.ForeColor = Color.White;
        btnCancelar.FlatStyle = FlatStyle.Flat;
        btnCancelar.Location = new Point(320, y);
        btnCancelar.Size = new Size(100, 35);
        btnCancelar.Text = "Cancelar";
        btnCancelar.Click += btnCancelar_Click;
        this.Controls.Add(btnCancelar);

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.ClientSize = new Size(500, y + 60);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Cliente";
        this.ResumeLayout(false);
    }

    private void AddLabel(string text, ref int y)
    {
        var label = new Label { Location = new Point(20, y), Text = text, Size = new Size(140, 20) };
        this.Controls.Add(label);
        y += 5;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
