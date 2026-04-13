namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormVehiculoEdit
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtId;
    private TextBox txtVIN;
    private TextBox txtMarca;
    private TextBox txtModelo;
    private TextBox txtYear;
    private TextBox txtColor;
    private TextBox txtKilometraje;
    private TextBox txtPrecio;
    private TextBox txtCosto;
    private TextBox txtMotor;
    private TextBox txtTransmision;
    private TextBox txtCombustible;
    private TextBox txtDescripcion;
    private ComboBox cmbTipo;
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
        this.txtId = new TextBox();
        this.txtVIN = new TextBox();
        this.txtMarca = new TextBox();
        this.txtModelo = new TextBox();
        this.txtYear = new TextBox();
        this.txtColor = new TextBox();
        this.txtKilometraje = new TextBox();
        this.txtPrecio = new TextBox();
        this.txtCosto = new TextBox();
        this.txtMotor = new TextBox();
        this.txtTransmision = new TextBox();
        this.txtCombustible = new TextBox();
        this.txtDescripcion = new TextBox();
        this.cmbTipo = new ComboBox();
        this.btnGuardar = new Button();
        this.btnCancelar = new Button();
        this.lblTitulo = new Label();
        this.SuspendLayout();

        // lblTitulo
        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.lblTitulo.Location = new System.Drawing.Point(20, 20);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new System.Drawing.Size(400, 30);
        this.lblTitulo.Text = "Nuevo Vehículo";

        // Labels and Inputs
        var labels = new (string Label, TextBox Box, int Row)[]
        {
            ("ID:", txtId, 70),
            ("VIN:", txtVIN, 100),
            ("Marca:", txtMarca, 130),
            ("Modelo:", txtModelo, 160),
            ("Año:", txtYear, 190),
            ("Color:", txtColor, 220),
            ("Kilometraje:", txtKilometraje, 250),
            ("Precio:", txtPrecio, 280),
            ("Costo:", txtCosto, 310),
            ("Motor:", txtMotor, 340),
            ("Transmisión:", txtTransmision, 370),
            ("Combustible:", txtCombustible, 400),
        };

        int y = 70;
        foreach (var (label, box, row) in labels)
        {
            var lbl = new System.Windows.Forms.Label();
            lbl.Location = new System.Drawing.Point(20, row);
            lbl.Name = "lbl" + label.Replace(":", "");
            lbl.Size = new System.Drawing.Size(100, 20);
            lbl.Text = label;
            this.Controls.Add(lbl);

            box.Location = new System.Drawing.Point(130, row);
            box.Name = box.Name;
            box.Size = new System.Drawing.Size(300, 23);
            this.Controls.Add(box);
            y = row + 30;
        }

        // Descripcion multiline
        var lblDescripcion = new System.Windows.Forms.Label();
        lblDescripcion.Location = new System.Drawing.Point(20, 430);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new System.Drawing.Size(100, 20);
        lblDescripcion.Text = "Descripción:";
        this.Controls.Add(lblDescripcion);

        this.txtDescripcion.Location = new System.Drawing.Point(130, 430);
        this.txtDescripcion.Multiline = true;
        this.txtDescripcion.Name = "txtDescripcion";
        this.txtDescripcion.Size = new System.Drawing.Size(300, 60);
        this.Controls.Add(this.txtDescripcion);

        // cmbTipo
        var lblTipo = new System.Windows.Forms.Label();
        lblTipo.Location = new System.Drawing.Point(20, 500);
        lblTipo.Name = "lblTipo";
        lblTipo.Size = new System.Drawing.Size(100, 20);
        lblTipo.Text = "Tipo:";
        this.Controls.Add(lblTipo);

        this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbTipo.Items.AddRange(new object[] { "Nuevo", "Seminuevo", "Usado" });
        this.cmbTipo.Location = new System.Drawing.Point(130, 500);
        this.cmbTipo.Name = "cmbTipo";
        this.cmbTipo.Size = new System.Drawing.Size(150, 23);
        this.cmbTipo.SelectedIndex = 0;
        this.Controls.Add(this.cmbTipo);

        // btnGuardar
        this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.btnGuardar.FlatAppearance.BorderSize = 0;
        this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnGuardar.ForeColor = System.Drawing.Color.White;
        this.btnGuardar.Location = new System.Drawing.Point(150, 540);
        this.btnGuardar.Name = "btnGuardar";
        this.btnGuardar.Size = new System.Drawing.Size(130, 40);
        this.btnGuardar.Text = "GUARDAR";
        this.btnGuardar.UseVisualStyleBackColor = false;
        this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
        this.Controls.Add(this.btnGuardar);

        // btnCancelar
        this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
        this.btnCancelar.FlatAppearance.BorderSize = 0;
        this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnCancelar.ForeColor = System.Drawing.Color.White;
        this.btnCancelar.Location = new System.Drawing.Point(290, 540);
        this.btnCancelar.Name = "btnCancelar";
        this.btnCancelar.Size = new System.Drawing.Size(130, 40);
        this.btnCancelar.Text = "CANCELAR";
        this.btnCancelar.UseVisualStyleBackColor = false;
        this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        this.Controls.Add(this.btnCancelar);

        // FormVehiculoEdit
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(450, 600);
        this.Controls.Add(this.lblTitulo);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "FormVehiculoEdit";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Vehículo";
        this.ResumeLayout(false);
    }
}