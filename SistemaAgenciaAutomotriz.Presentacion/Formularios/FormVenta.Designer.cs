using System.Windows.Forms;
using System.Drawing;
using System;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormVenta
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView dgvVehiculos;
    private TextBox txtBuscar;
    private Label lblBuscar;
    private Label lblVehiculoSeleccionado;
    private Label lblSubtotal;
    private Label lblIVA;
    private Label lblTotal;
    private Label lblSubtotalVal;
    private Label lblIVAVal;
    private Label lblTotalVal;
    private Label lblMensualidad;
    private ComboBox cmbMetodoPago;
    private ComboBox cmbTipoPago;
    private Label lblMetodoPago;
    private Label lblTipoPago;
    private Button btnLimpiar;
    private Button btnVender;
    private Button btnBuscar;
    private Panel pnlFinanciamiento;
    private TextBox txtEnganche;
    private TextBox txtPlazo;
    private TextBox txtTasa;
    private Label lblEnganche;
    private Label lblPlazo;
    private Label lblTasa;
    private CheckBox chkSeguro;
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
        this.dgvVehiculos = new DataGridView();
        this.txtBuscar = new TextBox();
        this.lblBuscar = new Label();
        this.lblVehiculoSeleccionado = new Label();
        this.lblSubtotal = new Label();
        this.lblIVA = new Label();
        this.lblTotal = new Label();
        this.lblSubtotalVal = new Label();
        this.lblIVAVal = new Label();
        this.lblTotalVal = new Label();
        this.lblMensualidad = new Label();
        this.cmbMetodoPago = new ComboBox();
        this.cmbTipoPago = new ComboBox();
        this.lblMetodoPago = new Label();
        this.lblTipoPago = new Label();
        this.btnLimpiar = new Button();
        this.btnVender = new Button();
        this.btnBuscar = new Button();
        this.pnlFinanciamiento = new Panel();
        this.txtEnganche = new TextBox();
        this.txtPlazo = new TextBox();
        this.txtTasa = new TextBox();
        this.lblEnganche = new Label();
        this.lblPlazo = new Label();
        this.lblTasa = new Label();
        this.chkSeguro = new CheckBox();
        this.lblCliente = new Label();
        this.txtClienteId = new TextBox();
        this.lblNombreCliente = new Label();

        ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).BeginInit();
        this.pnlFinanciamiento.SuspendLayout();
        this.SuspendLayout();

        // Header
        var headerPanel = new Panel();
        headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Name = "headerPanel";
        headerPanel.Size = new Size(1200, 50);
        
        var lblTitulo = new Label();
        lblTitulo.AutoSize = false;
        lblTitulo.Dock = DockStyle.Fill;
        lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblTitulo.ForeColor = System.Drawing.Color.White;
        lblTitulo.Text = "  Punto de Venta Exclusivo - Vehículos Automotríces";
        lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
        headerPanel.Controls.Add(lblTitulo);

        // Vehicle Selection Section
        var lblSeleccionVehiculo = new Label();
        lblSeleccionVehiculo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        lblSeleccionVehiculo.Location = new Point(20, 65);
        lblSeleccionVehiculo.Name = "lblSeleccionVehiculo";
        lblSeleccionVehiculo.Size = new Size(200, 25);
        lblSeleccionVehiculo.Text = "Catálogo de Vehículos";

        this.lblBuscar.Location = new Point(20, 95);
        this.lblBuscar.Name = "lblBuscar";
        this.lblBuscar.Size = new Size(80, 20);
        this.lblBuscar.Text = "Buscar:";

        this.txtBuscar.Location = new Point(100, 95);
        this.txtBuscar.Name = "txtBuscar";
        this.txtBuscar.Size = new Size(300, 23);
        this.txtBuscar.KeyPress += new KeyPressEventHandler(this.TxtBuscar_KeyPress);

        this.btnBuscar.Location = new Point(410, 93);
        this.btnBuscar.Name = "btnBuscar";
        this.btnBuscar.Size = new Size(80, 27);
        this.btnBuscar.Text = "Buscar";
        this.btnBuscar.UseVisualStyleBackColor = true;
        this.btnBuscar.Click += new EventHandler(this.BtnBuscar_Click);

        this.dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvVehiculos.Location = new Point(20, 125);
        this.dgvVehiculos.Name = "dgvVehiculos";
        this.dgvVehiculos.Size = new Size(950, 240);
        this.dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvVehiculos.MultiSelect = false;
        this.dgvVehiculos.ReadOnly = true;
        this.dgvVehiculos.DoubleClick += new EventHandler(this.DgvVehiculos_DoubleClick);

        this.lblVehiculoSeleccionado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblVehiculoSeleccionado.ForeColor = System.Drawing.Color.Gray;
        this.lblVehiculoSeleccionado.Location = new Point(20, 380);
        this.lblVehiculoSeleccionado.Name = "lblVehiculoSeleccionado";
        this.lblVehiculoSeleccionado.Size = new Size(600, 30);
        this.lblVehiculoSeleccionado.Text = "Sin vehículo seleccionado";

        // Payment Section
        this.lblSubtotal.Location = new Point(20, 420);
        this.lblSubtotal.Name = "lblSubtotal";
        this.lblSubtotal.Size = new Size(80, 20);
        this.lblSubtotal.Text = "Subtotal:";

        this.lblSubtotalVal.Location = new Point(100, 420);
        this.lblSubtotalVal.Name = "lblSubtotalVal";
        this.lblSubtotalVal.Size = new Size(120, 20);
        this.lblSubtotalVal.Text = "$0.00";
        this.lblSubtotalVal.TextAlign = ContentAlignment.MiddleRight;

        this.lblIVA.Location = new Point(250, 420);
        this.lblIVA.Name = "lblIVA";
        this.lblIVA.Size = new Size(80, 20);
        this.lblIVA.Text = "IVA (16%):";

        this.lblIVAVal.Location = new Point(330, 420);
        this.lblIVAVal.Name = "lblIVAVal";
        this.lblIVAVal.Size = new Size(120, 20);
        this.lblIVAVal.Text = "$0.00";
        this.lblIVAVal.TextAlign = ContentAlignment.MiddleRight;

        this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
        this.lblTotal.Location = new Point(480, 415);
        this.lblTotal.Name = "lblTotal";
        this.lblTotal.Size = new Size(80, 25);
        this.lblTotal.Text = "Total:";

        this.lblTotalVal.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
        this.lblTotalVal.Location = new Point(560, 415);
        this.lblTotalVal.Name = "lblTotalVal";
        this.lblTotalVal.Size = new Size(120, 25);
        this.lblTotalVal.Text = "$0.00";
        this.lblTotalVal.TextAlign = ContentAlignment.MiddleRight;

        this.lblCliente.Location = new Point(700, 420);
        this.lblCliente.Name = "lblCliente";
        this.lblCliente.Size = new Size(80, 20);
        this.lblCliente.Text = "ID Cliente:";

        this.txtClienteId.Location = new Point(780, 417);
        this.txtClienteId.Name = "txtClienteId";
        this.txtClienteId.Size = new Size(100, 23);
        this.txtClienteId.TextChanged += new EventHandler(this.TxtClienteId_TextChanged);

        this.lblNombreCliente.Location = new Point(700, 445);
        this.lblNombreCliente.Name = "lblNombreCliente";
        this.lblNombreCliente.Size = new Size(260, 20);
        this.lblNombreCliente.Text = "--";
        this.lblNombreCliente.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
        this.lblNombreCliente.ForeColor = System.Drawing.Color.Gray;

        this.lblMensualidad.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
        this.lblMensualidad.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.lblMensualidad.Location = new Point(480, 445);
        this.lblMensualidad.Name = "lblMensualidad";
        this.lblMensualidad.Size = new Size(250, 20);
        this.lblMensualidad.Visible = false;

        this.lblTipoPago.Location = new Point(20, 455);
        this.lblTipoPago.Name = "lblTipoPago";
        this.lblTipoPago.Size = new Size(80, 20);
        this.lblTipoPago.Text = "Tipo Pago:";

        this.cmbTipoPago.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbTipoPago.FormattingEnabled = true;
        this.cmbTipoPago.Items.AddRange(new object[] { "Contado", "Financiamiento" });
        this.cmbTipoPago.Location = new Point(100, 455);
        this.cmbTipoPago.Name = "cmbTipoPago";
        this.cmbTipoPago.Size = new Size(130, 23);
        this.cmbTipoPago.SelectedIndex = 0;
        this.cmbTipoPago.SelectedIndexChanged += new EventHandler(this.CmbTipoPago_SelectedIndexChanged);

        this.lblMetodoPago.Location = new Point(250, 455);
        this.lblMetodoPago.Name = "lblMetodoPago";
        this.lblMetodoPago.Size = new Size(80, 20);
        this.lblMetodoPago.Text = "Método:";

        this.cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbMetodoPago.FormattingEnabled = true;
        this.cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
        this.cmbMetodoPago.Location = new Point(330, 455);
        this.cmbMetodoPago.Name = "cmbMetodoPago";
        this.cmbMetodoPago.Size = new Size(130, 23);

        // Financing Panel
        this.pnlFinanciamiento.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        this.pnlFinanciamiento.Location = new Point(20, 490);
        this.pnlFinanciamiento.Name = "pnlFinanciamiento";
        this.pnlFinanciamiento.Size = new Size(280, 130);
        this.pnlFinanciamiento.Visible = false;

        this.lblEnganche.Location = new Point(10, 10);
        this.lblEnganche.Name = "lblEnganche";
        this.lblEnganche.Size = new Size(60, 20);
        this.lblEnganche.Text = "Enganche:";

        this.txtEnganche.Location = new Point(10, 32);
        this.txtEnganche.Name = "txtEnganche";
        this.txtEnganche.Size = new Size(80, 23);
        this.txtEnganche.Text = "0";
        this.txtEnganche.TextChanged += new EventHandler(this.TxtEnganche_TextChanged);

        this.lblPlazo.Location = new Point(100, 10);
        this.lblPlazo.Name = "lblPlazo";
        this.lblPlazo.Size = new Size(40, 20);
        this.lblPlazo.Text = "Meses:";

        this.txtPlazo.Location = new Point(100, 32);
        this.txtPlazo.Name = "txtPlazo";
        this.txtPlazo.Size = new Size(60, 23);
        this.txtPlazo.Text = "12";
        this.txtPlazo.TextChanged += new EventHandler(this.TxtPlazo_TextChanged);

        this.lblTasa.Location = new Point(10, 60);
        this.lblTasa.Name = "lblTasa";
        this.lblTasa.Size = new Size(60, 20);
        this.lblTasa.Text = "Tasa %:";

        this.txtTasa.Location = new Point(10, 82);
        this.txtTasa.Name = "txtTasa";
        this.txtTasa.Size = new Size(80, 23);
        this.txtTasa.Text = "12";
        this.txtTasa.TextChanged += new EventHandler(this.TxtTasa_TextChanged);

        this.chkSeguro.Location = new Point(100, 82);
        this.chkSeguro.Name = "chkSeguro";
        this.chkSeguro.Size = new Size(70, 20);
        this.chkSeguro.Text = "Seguro";

        this.pnlFinanciamiento.Controls.Add(this.lblEnganche);
        this.pnlFinanciamiento.Controls.Add(this.txtEnganche);
        this.pnlFinanciamiento.Controls.Add(this.lblPlazo);
        this.pnlFinanciamiento.Controls.Add(this.txtPlazo);
        this.pnlFinanciamiento.Controls.Add(this.lblTasa);
        this.pnlFinanciamiento.Controls.Add(this.txtTasa);
        this.pnlFinanciamiento.Controls.Add(this.chkSeguro);

        // Buttons
        this.btnLimpiar.Location = new Point(620, 560);
        this.btnLimpiar.Name = "btnLimpiar";
        this.btnLimpiar.Size = new Size(100, 35);
        this.btnLimpiar.Text = "Limpiar Todo";
        this.btnLimpiar.UseVisualStyleBackColor = true;
        this.btnLimpiar.Click += new EventHandler(this.BtnLimpiar_Click);

        this.btnVender.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
        this.btnVender.FlatAppearance.BorderSize = 0;
        this.btnVender.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
        this.btnVender.ForeColor = System.Drawing.Color.White;
        this.btnVender.Location = new Point(740, 540);
        this.btnVender.Name = "btnVender";
        this.btnVender.Size = new Size(230, 60);
        this.btnVender.Text = "CONCRETAR VENTA DE VEHÍCULO";
        this.btnVender.UseVisualStyleBackColor = false;
        this.btnVender.Click += new EventHandler(this.BtnVender_Click);

        // Add controls
        this.Controls.Add(headerPanel);
        this.Controls.Add(lblSeleccionVehiculo);
        this.Controls.Add(this.lblBuscar);
        this.Controls.Add(this.txtBuscar);
        this.Controls.Add(this.btnBuscar);
        this.Controls.Add(this.dgvVehiculos);
        this.Controls.Add(this.lblVehiculoSeleccionado);
        this.Controls.Add(this.lblSubtotal);
        this.Controls.Add(this.lblSubtotalVal);
        this.Controls.Add(this.lblIVA);
        this.Controls.Add(this.lblIVAVal);
        this.Controls.Add(this.lblTotal);
        this.Controls.Add(this.lblTotalVal);
        this.Controls.Add(this.lblMensualidad);
        this.Controls.Add(this.lblTipoPago);
        this.Controls.Add(this.cmbTipoPago);
        this.Controls.Add(this.lblMetodoPago);
        this.Controls.Add(this.cmbMetodoPago);
        this.Controls.Add(this.pnlFinanciamiento);
        this.Controls.Add(this.btnLimpiar);
        this.Controls.Add(this.btnVender);
        this.Controls.Add(this.lblCliente);
        this.Controls.Add(this.txtClienteId);
        this.Controls.Add(this.lblNombreCliente);

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1000, 650);
        this.Name = "FormVenta";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Punto de Venta Exclusivo - Vehículos";
        
        ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).EndInit();
        this.pnlFinanciamiento.ResumeLayout(false);
        this.pnlFinanciamiento.PerformLayout();
        this.ResumeLayout(false);
    }
}