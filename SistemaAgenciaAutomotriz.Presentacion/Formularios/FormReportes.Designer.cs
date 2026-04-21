using System.Drawing;
using System.Windows.Forms;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormReportes
{
    private System.ComponentModel.IContainer components = null;

    private Panel headerPanel;
    private Label lblTitulo;
    private Label lblTipoReporte;
    private ComboBox cmbTipoReporte;
    private Label lblRangoTiempo;
    private ComboBox cmbRangoTiempo;
    private Button btnGenerar;
    private Label lblInfo;

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
        this.headerPanel = new Panel();
        this.lblTitulo = new Label();
        this.lblTipoReporte = new Label();
        this.cmbTipoReporte = new ComboBox();
        this.lblRangoTiempo = new Label();
        this.cmbRangoTiempo = new ComboBox();
        this.btnGenerar = new Button();
        this.lblInfo = new Label();

        this.SuspendLayout();

        // Header Panel
        this.headerPanel.BackColor = Color.FromArgb(0, 120, 215);
        this.headerPanel.Dock = DockStyle.Top;
        this.headerPanel.Location = new Point(0, 0);
        this.headerPanel.Name = "headerPanel";
        this.headerPanel.Size = new Size(1280, 50);

        this.lblTitulo.Dock = DockStyle.Fill;
        this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        this.lblTitulo.ForeColor = Color.White;
        this.lblTitulo.Text = "  Centro de Reportes Financieros";
        this.lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
        this.headerPanel.Controls.Add(this.lblTitulo);

        // Form Layout
        this.BackColor = Color.White;

        this.lblTipoReporte.Location = new Point(50, 80);
        this.lblTipoReporte.Name = "lblTipoReporte";
        this.lblTipoReporte.Size = new Size(150, 30);
        this.lblTipoReporte.Text = "Reporte:";
        this.lblTipoReporte.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        this.cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbTipoReporte.FormattingEnabled = true;
        this.cmbTipoReporte.Items.AddRange(new object[] {
            "Ventas Generales (Vehículos e Historial)",
            "Ventas Exclusivas (Solo Accesorios)",
            "Cuentas por Cobrar e Historial",
            "Estado Actual del Inventario (Stock)"});
        this.cmbTipoReporte.Location = new Point(50, 115);
        this.cmbTipoReporte.Name = "cmbTipoReporte";
        this.cmbTipoReporte.Size = new Size(400, 25);
        this.cmbTipoReporte.SelectedIndex = 0;
        this.cmbTipoReporte.Font = new Font("Segoe UI", 10F);

        this.lblRangoTiempo.Location = new Point(50, 160);
        this.lblRangoTiempo.Name = "lblRangoTiempo";
        this.lblRangoTiempo.Size = new Size(150, 20);
        this.lblRangoTiempo.Text = "Rango de Tiempo:";
        this.lblRangoTiempo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        this.cmbRangoTiempo.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbRangoTiempo.FormattingEnabled = true;
        this.cmbRangoTiempo.Items.AddRange(new object[] {
            "Semanal (Últimos 8 días)",
            "Mensual (Últimos 30 días)"});
        this.cmbRangoTiempo.Location = new Point(50, 185);
        this.cmbRangoTiempo.Name = "cmbRangoTiempo";
        this.cmbRangoTiempo.Size = new Size(400, 25);
        this.cmbRangoTiempo.SelectedIndex = 0;
        this.cmbRangoTiempo.Font = new Font("Segoe UI", 10F);

        this.lblInfo.Location = new Point(50, 240);
        this.lblInfo.Name = "lblInfo";
        this.lblInfo.Size = new Size(400, 40);
        this.lblInfo.Text = "Los reportes se exportarán en formato nativo de Excel (.xlsx) conteniendo resúmenes y múltiples pestañas detalladas.";
        this.lblInfo.ForeColor = Color.Gray;
        this.lblInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);

        this.btnGenerar.BackColor = Color.FromArgb(40, 167, 69);
        this.btnGenerar.FlatAppearance.BorderSize = 0;
        this.btnGenerar.FlatStyle = FlatStyle.Flat;
        this.btnGenerar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        this.btnGenerar.ForeColor = Color.White;
        this.btnGenerar.Location = new Point(140, 300);
        this.btnGenerar.Name = "btnGenerar";
        this.btnGenerar.Size = new Size(220, 45);
        this.btnGenerar.Text = "Generar Reporte Excel";
        this.btnGenerar.UseVisualStyleBackColor = false;
        this.btnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1280, 720);
        this.Controls.Add(this.btnGenerar);
        this.Controls.Add(this.lblInfo);
        this.Controls.Add(this.cmbRangoTiempo);
        this.Controls.Add(this.lblRangoTiempo);
        this.Controls.Add(this.cmbTipoReporte);
        this.Controls.Add(this.lblTipoReporte);
        this.Controls.Add(this.headerPanel);
        this.Name = "FormReportes";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Reportes";

        this.ResumeLayout(false);
    }
}
