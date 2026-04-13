namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormCategoriaEdit
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtId;
    private TextBox txtNombre;
    private TextBox txtDescripcion;
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
        this.txtNombre = new TextBox();
        this.txtDescripcion = new TextBox();
        this.btnGuardar = new Button();
        this.btnCancelar = new Button();
        this.lblTitulo = new Label();
        this.SuspendLayout();

        // lblTitulo
        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.lblTitulo.Location = new System.Drawing.Point(20, 20);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new System.Drawing.Size(360, 30);
        this.lblTitulo.Text = "Nueva Categoría";

        // Label ID
        var lblId = new System.Windows.Forms.Label();
        lblId.Location = new System.Drawing.Point(20, 70);
        lblId.Name = "lblId";
        lblId.Size = new System.Drawing.Size(100, 20);
        lblId.Text = "ID:";

        // txtId
        this.txtId.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.txtId.Location = new System.Drawing.Point(20, 95);
        this.txtId.Name = "txtId";
        this.txtId.ReadOnly = true;
        this.txtId.Size = new System.Drawing.Size(100, 23);
        this.txtId.TabIndex = 0;

        // Label Nombre
        var lblNombre = new System.Windows.Forms.Label();
        lblNombre.Location = new System.Drawing.Point(20, 130);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new System.Drawing.Size(100, 20);
        lblNombre.Text = "Nombre:";

        // txtNombre
        this.txtNombre.Location = new System.Drawing.Point(20, 155);
        this.txtNombre.Name = "txtNombre";
        this.txtNombre.Size = new System.Drawing.Size(340, 23);
        this.txtNombre.TabIndex = 1;

        // Label Descripcion
        var lblDescripcion = new System.Windows.Forms.Label();
        lblDescripcion.Location = new System.Drawing.Point(20, 190);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new System.Drawing.Size(100, 20);
        lblDescripcion.Text = "Descripción:";

        // txtDescripcion
        this.txtDescripcion.Location = new System.Drawing.Point(20, 215);
        this.txtDescripcion.Multiline = true;
        this.txtDescripcion.Name = "txtDescripcion";
        this.txtDescripcion.Size = new System.Drawing.Size(340, 60);
        this.txtDescripcion.TabIndex = 2;

        // btnGuardar
        this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.btnGuardar.FlatAppearance.BorderSize = 0;
        this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnGuardar.ForeColor = System.Drawing.Color.White;
        this.btnGuardar.Location = new System.Drawing.Point(140, 300);
        this.btnGuardar.Name = "btnGuardar";
        this.btnGuardar.Size = new System.Drawing.Size(120, 35);
        this.btnGuardar.Text = "GUARDAR";
        this.btnGuardar.UseVisualStyleBackColor = false;
        this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

        // btnCancelar
        this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
        this.btnCancelar.FlatAppearance.BorderSize = 0;
        this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnCancelar.ForeColor = System.Drawing.Color.White;
        this.btnCancelar.Location = new System.Drawing.Point(270, 300);
        this.btnCancelar.Name = "btnCancelar";
        this.btnCancelar.Size = new System.Drawing.Size(90, 35);
        this.btnCancelar.Text = "CANCELAR";
        this.btnCancelar.UseVisualStyleBackColor = false;
        this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

        // FormCategoriaEdit
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(380, 360);
        this.Controls.Add(this.lblTitulo);
        this.Controls.Add(lblId);
        this.Controls.Add(this.txtId);
        this.Controls.Add(lblNombre);
        this.Controls.Add(this.txtNombre);
        this.Controls.Add(lblDescripcion);
        this.Controls.Add(this.txtDescripcion);
        this.Controls.Add(this.btnGuardar);
        this.Controls.Add(this.btnCancelar);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "FormCategoriaEdit";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Categoría";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}