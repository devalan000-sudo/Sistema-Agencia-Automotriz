using System.Drawing;
using System.Windows.Forms;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormVentaAccesorios
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView dgvProductos;
    private DataGridView dgvCarrito;
    private Label lblCarrito;
    private TextBox txtBuscarAcc;
    private Label lblBuscarAcc;
    private Label lblSubtotal;
    private Label lblIVA;
    private Label lblTotal;
    private Label lblSubtotalVal;
    private Label lblIVAVal;
    private Label lblTotalVal;
    private ComboBox cmbMetodoPago;
    private Label lblMetodoPago;
    private Button btnQuitar;
    private Button btnLimpiar;
    private Button btnVender;
    private Button btnBuscarAcc;
    private NumericUpDown nudCantidad;
    private Label lblCantidad;
    private Label lblCliente;
    private TextBox txtClienteId;
    private Label lblNombreCliente;

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
        this.dgvProductos = new DataGridView();
        this.dgvCarrito = new DataGridView();
        this.lblCarrito = new Label();
        this.txtBuscarAcc = new TextBox();
        this.lblBuscarAcc = new Label();
        this.lblSubtotal = new Label();
        this.lblIVA = new Label();
        this.lblTotal = new Label();
        this.lblSubtotalVal = new Label();
        this.lblIVAVal = new Label();
        this.lblTotalVal = new Label();
        this.cmbMetodoPago = new ComboBox();
        this.lblMetodoPago = new Label();
        this.btnQuitar = new Button();
        this.btnLimpiar = new Button();
        this.btnVender = new Button();
        this.btnBuscarAcc = new Button();
        this.nudCantidad = new NumericUpDown();
        this.lblCantidad = new Label();
        this.lblCliente = new Label();
        this.txtClienteId = new TextBox();
        this.lblNombreCliente = new Label();

        ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
        this.SuspendLayout();

        // Header
        var headerPanel = new Panel();
        headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Name = "headerPanel";
        headerPanel.Size = new Size(1000, 50);
        
        var lblTitulo = new Label();
        lblTitulo.AutoSize = false;
        lblTitulo.Dock = DockStyle.Fill;
        lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitulo.ForeColor = System.Drawing.Color.White;
        lblTitulo.Text = "  Punto de Venta Exclusivo - Accesorios";
        lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
        headerPanel.Controls.Add(lblTitulo);

        // Accessories Section
        var lblAccesorios = new Label();
        lblAccesorios.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblAccesorios.Location = new Point(20, 65);
        lblAccesorios.Name = "lblAccesorios";
        lblAccesorios.Size = new Size(200, 25);
        lblAccesorios.Text = "Accesorios/Refacciones";

        this.lblBuscarAcc.Location = new Point(20, 95);
        this.lblBuscarAcc.Name = "lblBuscarAcc";
        this.lblBuscarAcc.Size = new Size(80, 20);
        this.lblBuscarAcc.Text = "Buscar:";

        this.txtBuscarAcc.Location = new Point(100, 95);
        this.txtBuscarAcc.Name = "txtBuscarAcc";
        this.txtBuscarAcc.Size = new Size(300, 23);

        this.btnBuscarAcc.Location = new Point(410, 93);
        this.btnBuscarAcc.Name = "btnBuscarAcc";
        this.btnBuscarAcc.Size = new Size(80, 27);
        this.btnBuscarAcc.Text = "Buscar";
        this.btnBuscarAcc.UseVisualStyleBackColor = true;
        this.btnBuscarAcc.Click += new System.EventHandler(this.BtnBuscarAcc_Click);

        this.dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvProductos.Location = new Point(20, 125);
        this.dgvProductos.Name = "dgvProductos";
        this.dgvProductos.Size = new Size(940, 200);
        this.dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvProductos.MultiSelect = false;
        this.dgvProductos.ReadOnly = true;
        this.dgvProductos.DoubleClick += new System.EventHandler(this.DgvProductos_DoubleClick);

        this.lblCantidad.Location = new Point(20, 335);
        this.lblCantidad.Name = "lblCantidad";
        this.lblCantidad.Size = new Size(70, 20);
        this.lblCantidad.Text = "Cantidad:";

        this.nudCantidad.Location = new Point(100, 335);
        this.nudCantidad.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        this.nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        this.nudCantidad.Name = "nudCantidad";
        this.nudCantidad.Size = new Size(70, 23);
        this.nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });

        this.lblCarrito.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.lblCarrito.Location = new Point(20, 370);
        this.lblCarrito.Name = "lblCarrito";
        this.lblCarrito.Size = new Size(200, 25);
        this.lblCarrito.Text = "Carrito de Compras";

        this.dgvCarrito.AllowUserToAddRows = false;
        this.dgvCarrito.AllowUserToDeleteRows = false;
        this.dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvCarrito.Location = new Point(20, 400);
        this.dgvCarrito.Name = "dgvCarrito";
        this.dgvCarrito.ReadOnly = true;
        this.dgvCarrito.Size = new Size(600, 150);

        // Client and Payment Section
        this.lblCliente.Location = new Point(650, 400);
        this.lblCliente.Name = "lblCliente";
        this.lblCliente.Size = new Size(80, 20);
        this.lblCliente.Text = "ID Cliente:";

        this.txtClienteId.Location = new Point(730, 397);
        this.txtClienteId.Name = "txtClienteId";
        this.txtClienteId.Size = new Size(100, 23);
        this.txtClienteId.TextChanged += new System.EventHandler(this.TxtClienteId_TextChanged);

        this.lblNombreCliente.Location = new Point(650, 425);
        this.lblNombreCliente.Name = "lblNombreCliente";
        this.lblNombreCliente.Size = new Size(310, 20);
        this.lblNombreCliente.Text = "--";
        this.lblNombreCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblNombreCliente.ForeColor = System.Drawing.Color.Gray;

        this.lblMetodoPago.Location = new Point(650, 455);
        this.lblMetodoPago.Name = "lblMetodoPago";
        this.lblMetodoPago.Size = new Size(80, 20);
        this.lblMetodoPago.Text = "Método:";

        this.cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbMetodoPago.FormattingEnabled = true;
        this.cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
        this.cmbMetodoPago.Location = new Point(730, 452);
        this.cmbMetodoPago.Name = "cmbMetodoPago";
        this.cmbMetodoPago.Size = new Size(150, 23);
        this.cmbMetodoPago.SelectedIndex = 0;

        // Totals
        this.lblSubtotal.Location = new Point(650, 490);
        this.lblSubtotal.Name = "lblSubtotal";
        this.lblSubtotal.Size = new Size(80, 20);
        this.lblSubtotal.Text = "Subtotal:";

        this.lblSubtotalVal.Location = new Point(730, 490);
        this.lblSubtotalVal.Name = "lblSubtotalVal";
        this.lblSubtotalVal.Size = new Size(120, 20);
        this.lblSubtotalVal.Text = "$0.00";
        this.lblSubtotalVal.TextAlign = ContentAlignment.MiddleRight;

        this.lblIVA.Location = new Point(650, 520);
        this.lblIVA.Name = "lblIVA";
        this.lblIVA.Size = new Size(80, 20);
        this.lblIVA.Text = "IVA (16%):";

        this.lblIVAVal.Location = new Point(730, 520);
        this.lblIVAVal.Name = "lblIVAVal";
        this.lblIVAVal.Size = new Size(120, 20);
        this.lblIVAVal.Text = "$0.00";
        this.lblIVAVal.TextAlign = ContentAlignment.MiddleRight;

        this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTotal.Location = new Point(650, 550);
        this.lblTotal.Name = "lblTotal";
        this.lblTotal.Size = new Size(80, 25);
        this.lblTotal.Text = "Total:";

        this.lblTotalVal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTotalVal.Location = new Point(730, 550);
        this.lblTotalVal.Name = "lblTotalVal";
        this.lblTotalVal.Size = new Size(120, 25);
        this.lblTotalVal.Text = "$0.00";
        this.lblTotalVal.TextAlign = ContentAlignment.MiddleRight;

        // Buttons
        this.btnQuitar.Location = new Point(20, 560);
        this.btnQuitar.Name = "btnQuitar";
        this.btnQuitar.Size = new Size(100, 35);
        this.btnQuitar.Text = "Quitar";
        this.btnQuitar.UseVisualStyleBackColor = true;
        this.btnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);

        this.btnLimpiar.Location = new Point(130, 560);
        this.btnLimpiar.Name = "btnLimpiar";
        this.btnLimpiar.Size = new Size(100, 35);
        this.btnLimpiar.Text = "Limpiar";
        this.btnLimpiar.UseVisualStyleBackColor = true;
        this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);

        this.btnVender.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
        this.btnVender.FlatAppearance.BorderSize = 0;
        this.btnVender.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnVender.ForeColor = System.Drawing.Color.White;
        this.btnVender.Location = new Point(860, 510);
        this.btnVender.Name = "btnVender";
        this.btnVender.Size = new Size(100, 85);
        this.btnVender.Text = "COBRAR";
        this.btnVender.UseVisualStyleBackColor = false;
        this.btnVender.Click += new System.EventHandler(this.BtnVender_Click);

        // Add controls
        this.Controls.Add(headerPanel);
        this.Controls.Add(lblAccesorios);
        this.Controls.Add(this.lblBuscarAcc);
        this.Controls.Add(this.txtBuscarAcc);
        this.Controls.Add(this.btnBuscarAcc);
        this.Controls.Add(this.dgvProductos);
        this.Controls.Add(this.lblCantidad);
        this.Controls.Add(this.nudCantidad);
        this.Controls.Add(this.lblCarrito);
        this.Controls.Add(this.dgvCarrito);
        this.Controls.Add(this.lblSubtotal);
        this.Controls.Add(this.lblSubtotalVal);
        this.Controls.Add(this.lblIVA);
        this.Controls.Add(this.lblIVAVal);
        this.Controls.Add(this.lblTotal);
        this.Controls.Add(this.lblTotalVal);
        this.Controls.Add(this.lblMetodoPago);
        this.Controls.Add(this.cmbMetodoPago);
        this.Controls.Add(this.btnQuitar);
        this.Controls.Add(this.btnLimpiar);
        this.Controls.Add(this.btnVender);
        this.Controls.Add(this.lblCliente);
        this.Controls.Add(this.txtClienteId);
        this.Controls.Add(this.lblNombreCliente);

        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1000, 620);
        this.Name = "FormVentaAccesorios";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Punto de Venta Exclusivo - Accesorios";
        
        ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
