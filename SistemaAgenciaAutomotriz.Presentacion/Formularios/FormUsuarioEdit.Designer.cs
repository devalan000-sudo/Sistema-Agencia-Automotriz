using SistemaAgenciaAutomotriz.Dominio.Enumeradores;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormUsuarioEdit
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtId;
    private TextBox txtNombre;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private ComboBox cmbRol;
    private Button btnGuardar;
    private Button btnCancelar;
    private Label lblTitulo;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblTitulo = new Label();
        this.txtId = new TextBox();
        this.txtNombre = new TextBox();
        this.txtUsername = new TextBox();
        this.txtPassword = new TextBox();
        this.cmbRol = new ComboBox();
        this.btnGuardar = new Button();
        this.btnCancelar = new Button();

        this.SuspendLayout();

        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold);
        this.lblTitulo.ForeColor = Color.FromArgb(0, 120, 215);
        this.lblTitulo.Location = new Point(20, 20);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new Size(360, 30);
        this.lblTitulo.Text = _esNuevo ? "Nuevo Usuario" : "Editar Usuario";

        var lblId = new Label { Location = new Point(20, 70), Text = "ID:", Size = new Size(100, 20) };
        this.txtId.Location = new Point(20, 95);
        this.txtId.Size = new Size(100, 23);
        this.txtId.ReadOnly = true;
        this.txtId.BackColor = SystemColors.Control;

        var lblNombre = new Label { Location = new Point(20, 130), Text = "Nombre:", Size = new Size(100, 20) };
        this.txtNombre.Location = new Point(20, 155);
        this.txtNombre.Size = new Size(340, 23);

        var lblUsername = new Label { Location = new Point(20, 190), Text = "Usuario:", Size = new Size(100, 20) };
        this.txtUsername.Location = new Point(20, 215);
        this.txtUsername.Size = new Size(340, 23);

        var lblPassword = new Label { Location = new Point(20, 250), Text = "Contraseña:", Size = new Size(100, 20) };
        this.txtPassword.Location = new Point(20, 275);
        this.txtPassword.Size = new Size(340, 23);
        this.txtPassword.PasswordChar = '*';

        var lblRol = new Label { Location = new Point(20, 310), Text = "Rol:", Size = new Size(100, 20) };
        this.cmbRol.Location = new Point(20, 335);
        this.cmbRol.Size = new Size(200, 23);
        this.cmbRol.DataSource = Enum.GetValues(typeof(RolUsuario));
        this.cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;

        this.btnGuardar.BackColor = Color.FromArgb(0, 120, 215);
        this.btnGuardar.ForeColor = Color.White;
        this.btnGuardar.FlatStyle = FlatStyle.Flat;
        this.btnGuardar.Location = new Point(130, 380);
        this.btnGuardar.Size = new Size(120, 35);
        this.btnGuardar.Text = "Guardar";
        this.btnGuardar.UseVisualStyleBackColor = false;
        this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

        this.btnCancelar.BackColor = Color.Gray;
        this.btnCancelar.ForeColor = Color.White;
        this.btnCancelar.FlatStyle = FlatStyle.Flat;
        this.btnCancelar.Location = new Point(260, 380);
        this.btnCancelar.Size = new Size(100, 35);
        this.btnCancelar.Text = "Cancelar";
        this.btnCancelar.UseVisualStyleBackColor = false;
        this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

        this.Controls.AddRange(new Control[] {
            lblTitulo, lblId, txtId, lblNombre, txtNombre,
            lblUsername, txtUsername, lblPassword, txtPassword,
            lblRol, cmbRol, btnGuardar, btnCancelar
        });

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(380, 440);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Usuario";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
