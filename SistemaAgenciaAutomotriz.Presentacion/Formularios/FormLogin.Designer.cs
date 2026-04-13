namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormLogin
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox txtUsuario;
    private System.Windows.Forms.TextBox txtContrasena;
    private System.Windows.Forms.Label lblUsuario;
    private System.Windows.Forms.Label lblContrasena;
    private System.Windows.Forms.Button btnIngresar;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Panel panel2;

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
        this.txtUsuario = new System.Windows.Forms.TextBox();
        this.txtContrasena = new System.Windows.Forms.TextBox();
        this.lblUsuario = new System.Windows.Forms.Label();
        this.lblContrasena = new System.Windows.Forms.Label();
        this.btnIngresar = new System.Windows.Forms.Button();
        this.btnCancelar = new System.Windows.Forms.Button();
        this.panel1 = new System.Windows.Forms.Panel();
        this.panel2 = new System.Windows.Forms.Panel();
        this.lblTitulo = new System.Windows.Forms.Label();
        this.panel1.SuspendLayout();
        this.panel2.SuspendLayout();
        this.SuspendLayout();

        // Panel title bar
        this.panel2.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
        this.panel2.Location = new System.Drawing.Point(0, 0);
        this.panel2.Name = "panel2";
        this.panel2.Size = new System.Drawing.Size(400, 80);
        this.panel2.TabIndex = 0;

        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.ForeColor = System.Drawing.Color.White;
        this.lblTitulo.Location = new System.Drawing.Point(0, 15);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new System.Drawing.Size(400, 50);
        this.lblTitulo.Text = "Sistema Agencia";
        this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.panel2.Controls.Add(this.lblTitulo);

        // Labels
        this.lblUsuario.AutoSize = true;
        this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.lblUsuario.Location = new System.Drawing.Point(75, 110);
        this.lblUsuario.Name = "lblUsuario";
        this.lblUsuario.Size = new System.Drawing.Size(60, 17);
        this.lblUsuario.TabIndex = 1;
        this.lblUsuario.Text = "Usuario";

        this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
        this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.txtUsuario.Location = new System.Drawing.Point(75, 130);
        this.txtUsuario.Name = "txtUsuario";
        this.txtUsuario.Padding = new System.Windows.Forms.Padding(8);
        this.txtUsuario.Size = new System.Drawing.Size(250, 32);
        this.txtUsuario.TabIndex = 2;

        this.lblContrasena.AutoSize = true;
        this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblContrasena.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.lblContrasena.Location = new System.Drawing.Point(75, 175);
        this.lblContrasena.Name = "lblContrasena";
        this.lblContrasena.Size = new System.Drawing.Size(85, 17);
        this.lblContrasena.TabIndex = 3;
        this.lblContrasena.Text = "Contraseña";

        this.txtContrasena.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
        this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
        this.txtContrasena.Location = new System.Drawing.Point(75, 195);
        this.txtContrasena.Name = "txtContrasena";
        this.txtContrasena.PasswordChar = '*';
        this.txtContrasena.Padding = new System.Windows.Forms.Padding(8);
        this.txtContrasena.Size = new System.Drawing.Size(250, 32);
        this.txtContrasena.TabIndex = 4;

        // Buttons with modern styling
        this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.btnIngresar.FlatAppearance.BorderSize = 0;
        this.btnIngresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 100, 190);
        this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnIngresar.ForeColor = System.Drawing.Color.White;
        this.btnIngresar.Location = new System.Drawing.Point(75, 255);
        this.btnIngresar.Name = "btnIngresar";
        this.btnIngresar.Size = new System.Drawing.Size(120, 40);
        this.btnIngresar.TabIndex = 5;
        this.btnIngresar.Text = "INGRESAR";
        this.btnIngresar.UseVisualStyleBackColor = false;
        this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);

        this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
        this.btnCancelar.FlatAppearance.BorderSize = 0;
        this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(90, 100, 108);
        this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.btnCancelar.ForeColor = System.Drawing.Color.White;
        this.btnCancelar.Location = new System.Drawing.Point(205, 255);
        this.btnCancelar.Name = "btnCancelar";
        this.btnCancelar.Size = new System.Drawing.Size(120, 40);
        this.btnCancelar.TabIndex = 6;
        this.btnCancelar.Text = "CANCELAR";
        this.btnCancelar.UseVisualStyleBackColor = false;
        this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

        this.panel1.BackColor = System.Drawing.Color.White;
        this.panel1.Controls.Add(this.lblUsuario);
        this.panel1.Controls.Add(this.txtUsuario);
        this.panel1.Controls.Add(this.lblContrasena);
        this.panel1.Controls.Add(this.txtContrasena);
        this.panel1.Controls.Add(this.btnIngresar);
        this.panel1.Controls.Add(this.btnCancelar);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panel1.Location = new System.Drawing.Point(0, 80);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(400, 320);
        this.panel1.TabIndex = 1;

        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 400);
        this.Controls.Add(this.panel1);
        this.Controls.Add(this.panel2);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FormLogin";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Login - Sistema Agencia";
        this.panel2.ResumeLayout(false);
        this.panel1.ResumeLayout(false);
        this.panel1.PerformLayout();
        this.ResumeLayout(false);
    }
}