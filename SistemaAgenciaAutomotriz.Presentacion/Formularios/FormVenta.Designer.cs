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
    private Panel pnlBottomBar;
    private Button btnToggleBottomBar;
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
    private TextBox txtRFC;

    private GroupBox gbCliente;
    private GroupBox gbVenta;
    private GroupBox gbPago;
    private Panel pnlInformacionVenta;
    private Panel headerPanel;
    private Label lblTitulo;
    private Label lblSeleccionVehiculo;

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
        dgvVehiculos = new DataGridView();
        txtBuscar = new TextBox();
        lblBuscar = new Label();
        lblVehiculoSeleccionado = new Label();
        lblSubtotal = new Label();
        lblIVA = new Label();
        lblTotal = new Label();
        lblSubtotalVal = new Label();
        lblIVAVal = new Label();
        lblTotalVal = new Label();
        lblMensualidad = new Label();
        cmbMetodoPago = new ComboBox();
        cmbTipoPago = new ComboBox();
        lblMetodoPago = new Label();
        lblTipoPago = new Label();
        btnLimpiar = new Button();
        btnVender = new Button();
        btnBuscar = new Button();
        pnlFinanciamiento = new Panel();
        lblEnganche = new Label();
        txtEnganche = new TextBox();
        lblPlazo = new Label();
        txtPlazo = new TextBox();
        lblTasa = new Label();
        txtTasa = new TextBox();
        chkSeguro = new CheckBox();
        pnlBottomBar = new Panel();
        btnToggleBottomBar = new Button();
        lblCliente = new Label();
        txtClienteId = new TextBox();
        lblNombreCliente = new Label();
        txtRFC = new TextBox();
        headerPanel = new Panel();
        lblTitulo = new Label();
        lblSeleccionVehiculo = new Label();
        gbCliente = new GroupBox();
        gbVenta = new GroupBox();
        gbPago = new GroupBox();
        pnlInformacionVenta = new Panel();
        
        ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
        pnlFinanciamiento.SuspendLayout();
        pnlBottomBar.SuspendLayout();
        headerPanel.SuspendLayout();
        gbCliente.SuspendLayout();
        gbVenta.SuspendLayout();
        gbPago.SuspendLayout();
        pnlInformacionVenta.SuspendLayout();
        SuspendLayout();

        // headerPanel
        headerPanel.BackColor = Color.FromArgb(0, 120, 215);
        headerPanel.Controls.Add(lblTitulo);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Name = "headerPanel";
        headerPanel.Size = new Size(1463, 67);

        // lblTitulo
        lblTitulo.Dock = DockStyle.Fill;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(0, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(1463, 67);
        lblTitulo.Text = "  Punto de Venta Exclusivo - Vehículos Automotríces";
        lblTitulo.TextAlign = ContentAlignment.MiddleLeft;

        // lblSeleccionVehiculo
        lblSeleccionVehiculo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblSeleccionVehiculo.Location = new Point(23, 80);
        lblSeleccionVehiculo.Name = "lblSeleccionVehiculo";
        lblSeleccionVehiculo.Size = new Size(229, 33);
        lblSeleccionVehiculo.Text = "Catálogo de Vehículos";

        // lblBuscar
        lblBuscar.Location = new Point(23, 114);
        lblBuscar.Name = "lblBuscar";
        lblBuscar.Size = new Size(91, 27);
        lblBuscar.Text = "Buscar:";

        // txtBuscar
        txtBuscar.Location = new Point(114, 111);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.Size = new Size(342, 27);
        txtBuscar.KeyPress += TxtBuscar_KeyPress;

        // btnBuscar
        btnBuscar.Location = new Point(480, 109);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(91, 30);
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = true;
        btnBuscar.Click += BtnBuscar_Click;

        // dgvVehiculos
        dgvVehiculos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvVehiculos.Location = new Point(23, 150);
        dgvVehiculos.MultiSelect = false;
        dgvVehiculos.Name = "dgvVehiculos";
        dgvVehiculos.ReadOnly = true;
        dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvVehiculos.Size = new Size(1417, 450);
        dgvVehiculos.DoubleClick += DgvVehiculos_DoubleClick;

        // pnlInformacionVenta
        pnlInformacionVenta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnlInformacionVenta.Controls.Add(gbCliente);
        pnlInformacionVenta.Controls.Add(gbVenta);
        pnlInformacionVenta.Controls.Add(gbPago);
        pnlInformacionVenta.Controls.Add(btnLimpiar);
        pnlInformacionVenta.Controls.Add(btnVender);
        pnlInformacionVenta.Location = new Point(23, 620);
        pnlInformacionVenta.Name = "pnlInformacionVenta";
        pnlInformacionVenta.Size = new Size(1417, 260);

        // gbCliente
        gbCliente.Controls.Add(lblCliente);
        gbCliente.Controls.Add(txtClienteId);
        gbCliente.Controls.Add(lblNombreCliente);
        gbCliente.Controls.Add(txtRFC);
        gbCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        gbCliente.Location = new Point(0, 5);
        gbCliente.Name = "gbCliente";
        gbCliente.Size = new Size(310, 240);
        gbCliente.Text = "Datos del Cliente";

        lblCliente.Font = new Font("Segoe UI", 9F);
        lblCliente.Location = new Point(15, 40);
        lblCliente.Size = new Size(80, 27);
        lblCliente.Text = "ID Cliente:";

        txtClienteId.Font = new Font("Segoe UI", 9F);
        txtClienteId.Location = new Point(100, 37);
        txtClienteId.Size = new Size(100, 27);
        txtClienteId.TextChanged += TxtClienteId_TextChanged;

        lblNombreCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblNombreCliente.ForeColor = Color.Gray;
        lblNombreCliente.Location = new Point(15, 80);
        lblNombreCliente.Size = new Size(280, 27);
        lblNombreCliente.Text = "--";

        txtRFC.Font = new Font("Segoe UI", 9F);
        txtRFC.Location = new Point(15, 120);
        txtRFC.ReadOnly = true;
        txtRFC.Size = new Size(200, 27);
        txtRFC.Text = "RFC: --";

        // gbVenta
        gbVenta.Controls.Add(lblVehiculoSeleccionado);
        gbVenta.Controls.Add(lblSubtotal);
        gbVenta.Controls.Add(lblSubtotalVal);
        gbVenta.Controls.Add(lblIVA);
        gbVenta.Controls.Add(lblIVAVal);
        gbVenta.Controls.Add(lblTotal);
        gbVenta.Controls.Add(lblTotalVal);
        gbVenta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        gbVenta.Location = new Point(320, 5);
        gbVenta.Name = "gbVenta";
        gbVenta.Size = new Size(390, 240);
        gbVenta.Text = "Detalles y Totales";

        lblVehiculoSeleccionado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblVehiculoSeleccionado.ForeColor = Color.FromArgb(0, 120, 215);
        lblVehiculoSeleccionado.Location = new Point(20, 35);
        lblVehiculoSeleccionado.Size = new Size(350, 40);
        lblVehiculoSeleccionado.Text = "Sin vehículo seleccionado";

        lblSubtotal.Font = new Font("Segoe UI", 10F);
        lblSubtotal.Location = new Point(20, 85);
        lblSubtotal.Size = new Size(91, 27);
        lblSubtotal.Text = "Subtotal:";

        lblSubtotalVal.Font = new Font("Segoe UI", 10F);
        lblSubtotalVal.Location = new Point(150, 85);
        lblSubtotalVal.Size = new Size(200, 27);
        lblSubtotalVal.Text = "$0.00";
        lblSubtotalVal.TextAlign = ContentAlignment.MiddleRight;

        lblIVA.Font = new Font("Segoe UI", 10F);
        lblIVA.Location = new Point(20, 125);
        lblIVA.Size = new Size(91, 27);
        lblIVA.Text = "IVA (16%):";

        lblIVAVal.Font = new Font("Segoe UI", 10F);
        lblIVAVal.Location = new Point(150, 125);
        lblIVAVal.Size = new Size(200, 27);
        lblIVAVal.Text = "$0.00";
        lblIVAVal.TextAlign = ContentAlignment.MiddleRight;

        lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTotal.Location = new Point(20, 175);
        lblTotal.Size = new Size(91, 33);
        lblTotal.Text = "Total:";

        lblTotalVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTotalVal.Location = new Point(150, 175);
        lblTotalVal.Size = new Size(200, 33);
        lblTotalVal.Text = "$0.00";
        lblTotalVal.TextAlign = ContentAlignment.MiddleRight;

        // gbPago
        gbPago.Controls.Add(lblTipoPago);
        gbPago.Controls.Add(cmbTipoPago);
        gbPago.Controls.Add(lblMetodoPago);
        gbPago.Controls.Add(cmbMetodoPago);
        gbPago.Controls.Add(pnlFinanciamiento);
        gbPago.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        gbPago.Location = new Point(720, 5);
        gbPago.Name = "gbPago";
        gbPago.Size = new Size(390, 240);
        gbPago.Text = "Configuración de Pago";

        lblTipoPago.Font = new Font("Segoe UI", 9F);
        lblTipoPago.Location = new Point(15, 35);
        lblTipoPago.Size = new Size(90, 27);
        lblTipoPago.Text = "Tipo Pago:";

        cmbTipoPago.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTipoPago.Font = new Font("Segoe UI", 9F);
        cmbTipoPago.FormattingEnabled = true;
        cmbTipoPago.Items.AddRange(new object[] { "Contado", "Financiamiento" });
        cmbTipoPago.Location = new Point(110, 32);
        cmbTipoPago.Size = new Size(150, 28);
        cmbTipoPago.SelectedIndexChanged += CmbTipoPago_SelectedIndexChanged;

        lblMetodoPago.Font = new Font("Segoe UI", 9F);
        lblMetodoPago.Location = new Point(15, 75);
        lblMetodoPago.Size = new Size(90, 27);
        lblMetodoPago.Text = "Método:";

        cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMetodoPago.Font = new Font("Segoe UI", 9F);
        cmbMetodoPago.FormattingEnabled = true;
        cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
        cmbMetodoPago.Location = new Point(110, 72);
        cmbMetodoPago.Size = new Size(150, 28);

        // pnlFinanciamiento
        pnlFinanciamiento.BackColor = Color.FromArgb(244, 244, 244);
        pnlFinanciamiento.Controls.Add(lblEnganche);
        pnlFinanciamiento.Controls.Add(txtEnganche);
        pnlFinanciamiento.Controls.Add(lblPlazo);
        pnlFinanciamiento.Controls.Add(txtPlazo);
        pnlFinanciamiento.Controls.Add(lblTasa);
        pnlFinanciamiento.Controls.Add(txtTasa);
        pnlFinanciamiento.Controls.Add(chkSeguro);
        pnlFinanciamiento.Controls.Add(lblMensualidad);
        pnlFinanciamiento.Location = new Point(10, 110);
        pnlFinanciamiento.Name = "pnlFinanciamiento";
        pnlFinanciamiento.Size = new Size(365, 115);
        pnlFinanciamiento.Visible = false;

        lblEnganche.Font = new Font("Segoe UI", 9F);
        lblEnganche.Location = new Point(10, 10);
        lblEnganche.Size = new Size(80, 20);
        lblEnganche.Text = "Enganche:";

        txtEnganche.Font = new Font("Segoe UI", 9F);
        txtEnganche.Location = new Point(10, 35);
        txtEnganche.Size = new Size(100, 27);
        txtEnganche.Text = "0";
        txtEnganche.TextChanged += TxtEnganche_TextChanged;

        lblPlazo.Font = new Font("Segoe UI", 9F);
        lblPlazo.Location = new Point(125, 10);
        lblPlazo.Size = new Size(60, 20);
        lblPlazo.Text = "Meses:";

        txtPlazo.Font = new Font("Segoe UI", 9F);
        txtPlazo.Location = new Point(125, 35);
        txtPlazo.Size = new Size(60, 27);
        txtPlazo.Text = "12";
        txtPlazo.TextChanged += TxtPlazo_TextChanged;

        lblTasa.Font = new Font("Segoe UI", 9F);
        lblTasa.Location = new Point(10, 65);
        lblTasa.Size = new Size(80, 20);
        lblTasa.Text = "Tasa %:";

        txtTasa.Font = new Font("Segoe UI", 9F);
        txtTasa.Location = new Point(10, 85);
        txtTasa.Size = new Size(100, 27);
        txtTasa.Text = "12";
        txtTasa.TextChanged += TxtTasa_TextChanged;

        chkSeguro.Font = new Font("Segoe UI", 9F);
        chkSeguro.Location = new Point(125, 87);
        chkSeguro.Size = new Size(80, 25);
        chkSeguro.Text = "Seguro";

        lblMensualidad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMensualidad.ForeColor = Color.FromArgb(0, 120, 215);
        lblMensualidad.Location = new Point(200, 35);
        lblMensualidad.Size = new Size(150, 60);
        lblMensualidad.Visible = true;

        // btnLimpiar
        btnLimpiar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLimpiar.Font = new Font("Segoe UI", 10F);
        btnLimpiar.Location = new Point(1205, 18);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(190, 45);
        btnLimpiar.Text = "LIMPIAR TODO";
        btnLimpiar.UseVisualStyleBackColor = true;
        btnLimpiar.Click += BtnLimpiar_Click;

        // btnVender
        btnVender.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnVender.BackColor = Color.FromArgb(40, 167, 69);
        btnVender.FlatAppearance.BorderSize = 0;
        btnVender.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnVender.ForeColor = Color.White;
        btnVender.Location = new Point(1205, 75);
        btnVender.Name = "btnVender";
        btnVender.Size = new Size(190, 110);
        btnVender.Text = "CONCRETAR VENTA DE VEHÍCULO";
        btnVender.UseVisualStyleBackColor = false;
        btnVender.Click += BtnVender_Click;

        // pnlBottomBar
        pnlBottomBar.BackColor = SystemColors.Control;
        pnlBottomBar.Controls.Add(btnToggleBottomBar);
        pnlBottomBar.Dock = DockStyle.Bottom;
        pnlBottomBar.Location = new Point(0, 907);
        pnlBottomBar.Name = "pnlBottomBar";
        pnlBottomBar.Padding = new Padding(6, 7, 6, 7);
        pnlBottomBar.Size = new Size(1463, 53);

        // btnToggleBottomBar
        btnToggleBottomBar.Location = new Point(7, 11);
        btnToggleBottomBar.Name = "btnToggleBottomBar";
        btnToggleBottomBar.Size = new Size(137, 32);
        btnToggleBottomBar.Text = "Ocultar barra";
        btnToggleBottomBar.Click += BtnToggleBottomBar_Click;

        // FormVenta
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1463, 960);
        Controls.Add(pnlInformacionVenta);
        Controls.Add(pnlBottomBar);
        Controls.Add(headerPanel);
        Controls.Add(lblSeleccionVehiculo);
        Controls.Add(lblBuscar);
        Controls.Add(txtBuscar);
        Controls.Add(btnBuscar);
        Controls.Add(dgvVehiculos);
        Name = "FormVenta";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Punto de Venta Exclusivo - Vehículos";
        
        ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
        pnlFinanciamiento.ResumeLayout(false);
        pnlFinanciamiento.PerformLayout();
        pnlBottomBar.ResumeLayout(false);
        headerPanel.ResumeLayout(false);
        gbCliente.ResumeLayout(false);
        gbCliente.PerformLayout();
        gbVenta.ResumeLayout(false);
        gbPago.ResumeLayout(false);
        pnlInformacionVenta.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}
