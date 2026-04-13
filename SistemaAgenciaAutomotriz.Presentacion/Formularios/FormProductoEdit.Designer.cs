namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormProductoEdit
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtId;
    private TextBox txtCodigo;
    private TextBox txtNombre;
    private TextBox txtDescripcion;
    private TextBox txtPrecio;
    private TextBox txtCosto;
    private TextBox txtStock;
    private TextBox txtStockMinimo;
    private ComboBox cmbCategoria;
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
        this.txtCodigo = new TextBox();
        this.txtNombre = new TextBox();
        this.txtDescripcion = new TextBox();
        this.txtPrecio = new TextBox();
        this.txtCosto = new TextBox();
        this.txtStock = new TextBox();
        this.txtStockMinimo = new TextBox();
        this.cmbCategoria = new ComboBox();
        this.btnGuardar = new Button();
        this.btnCancelar = new Button();
        this.lblTitulo = new Label();
        this.SuspendLayout();

        int y = 20;

        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.lblTitulo.Location = new System.Drawing.Point(20, y);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new System.Drawing.Size(400, 30);
        this.lblTitulo.Text = "Producto";
        y += 40;

        AddLabel("ID:", ref y);
        this.txtId.Location = new System.Drawing.Point(120, y);
        this.txtId.Size = new System.Drawing.Size(80, 23);
        this.txtId.ReadOnly = true;
        this.txtId.BackColor = System.Drawing.SystemColors.Control;
        this.txtId.Name = "txtId";
        this.Controls.Add(this.txtId);
        y += 30;

        AddLabel("Código:", ref y);
        this.txtCodigo.Location = new System.Drawing.Point(120, y);
        this.txtCodigo.Size = new System.Drawing.Size(200, 23);
        this.txtCodigo.Name = "txtCodigo";
        this.Controls.Add(this.txtCodigo);
        y += 30;

        AddLabel("Nombre:", ref y);
        this.txtNombre.Location = new System.Drawing.Point(120, y);
        this.txtNombre.Size = new System.Drawing.Size(300, 23);
        this.txtNombre.Name = "txtNombre";
        this.Controls.Add(this.txtNombre);
        y += 30;

        AddLabel("Descripción:", ref y);
        this.txtDescripcion.Location = new System.Drawing.Point(120, y);
        this.txtDescripcion.Size = new System.Drawing.Size(300, 40);
        this.txtDescripcion.Multiline = true;
        this.txtDescripcion.Name = "txtDescripcion";
        this.Controls.Add(this.txtDescripcion);
        y += 50;

        AddLabel("Precio:", ref y);
        this.txtPrecio.Location = new System.Drawing.Point(120, y);
        this.txtPrecio.Size = new System.Drawing.Size(120, 23);
        this.txtPrecio.Name = "txtPrecio";
        this.Controls.Add(this.txtPrecio);
        y += 30;

        AddLabel("Costo:", ref y);
        this.txtCosto.Location = new System.Drawing.Point(120, y);
        this.txtCosto.Size = new System.Drawing.Size(120, 23);
        this.txtCosto.Name = "txtCosto";
        this.Controls.Add(this.txtCosto);
        y += 30;

        AddLabel("Stock:", ref y);
        this.txtStock.Location = new System.Drawing.Point(120, y);
        this.txtStock.Size = new System.Drawing.Size(100, 23);
        this.txtStock.Name = "txtStock";
        this.Controls.Add(this.txtStock);
        y += 30;

        AddLabel("Stock Mínimo:", ref y);
        this.txtStockMinimo.Location = new System.Drawing.Point(120, y);
        this.txtStockMinimo.Size = new System.Drawing.Size(100, 23);
        this.txtStockMinimo.Name = "txtStockMinimo";
        this.Controls.Add(this.txtStockMinimo);
        y += 30;

        AddLabel("Categoría:", ref y);
        this.cmbCategoria.Location = new System.Drawing.Point(120, y);
        this.cmbCategoria.Size = new System.Drawing.Size(200, 23);
        this.cmbCategoria.Name = "cmbCategoria";
        this.Controls.Add(this.cmbCategoria);
        y += 40;

        this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.btnGuardar.ForeColor = System.Drawing.Color.White;
        this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnGuardar.Location = new System.Drawing.Point(150, y);
        this.btnGuardar.Size = new System.Drawing.Size(120, 35);
        this.btnGuardar.Text = "Guardar";
        this.btnGuardar.Name = "btnGuardar";
        this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
        this.Controls.Add(this.btnGuardar);

        this.btnCancelar.BackColor = System.Drawing.Color.Gray;
        this.btnCancelar.ForeColor = System.Drawing.Color.White;
        this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancelar.Location = new System.Drawing.Point(280, y);
        this.btnCancelar.Size = new System.Drawing.Size(100, 35);
        this.btnCancelar.Text = "Cancelar";
        this.btnCancelar.Name = "btnCancelar";
        this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
        this.Controls.Add(this.btnCancelar);

        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(450, y + 50);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.Name = "FormProductoEdit";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Producto";
        this.Controls.Add(this.lblTitulo);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void AddLabel(string text, ref int y)
    {
        var label = new System.Windows.Forms.Label();
        label.Location = new System.Drawing.Point(20, y);
        label.Text = text;
        label.Size = new System.Drawing.Size(100, 20);
        this.Controls.Add(label);
        y += 5;
    }
}
