namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormVentaList : Form
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvVentas;
    private Button btnActualizar;
    private Button btnCerrar;
    private Panel headerPanel;
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
        this.dgvVentas = new DataGridView();
        this.btnActualizar = new Button();
        this.btnCerrar = new Button();
        this.headerPanel = new Panel();
        this.lblTitulo = new Label();
        ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
        this.SuspendLayout();

        // Header
        this.headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.headerPanel.Dock = DockStyle.Top;
        this.headerPanel.Location = new Point(0, 0);
        this.headerPanel.Name = "headerPanel";
        this.headerPanel.Size = new Size(1000, 50);

        this.lblTitulo.AutoSize = false;
        this.lblTitulo.Dock = DockStyle.Fill;
        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.ForeColor = System.Drawing.Color.White;
        this.lblTitulo.Location = new Point(0, 0);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new Size(1000, 50);
        this.lblTitulo.Text = "  Historial de Ventas";
        this.lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
        this.headerPanel.Controls.Add(this.lblTitulo);

        // DataGrid
        this.dgvVentas.AllowUserToAddRows = false;
        this.dgvVentas.AllowUserToDeleteRows = false;
        this.dgvVentas.AllowUserToResizeRows = false;
        this.dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
        this.dgvVentas.BorderStyle = BorderStyle.None;
        this.dgvVentas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        this.dgvVentas.ColumnHeadersHeight = 40;
        this.dgvVentas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        this.dgvVentas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.dgvVentas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this.dgvVentas.EnableHeadersVisualStyles = false;
        this.dgvVentas.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
        this.dgvVentas.Location = new Point(20, 65);
        this.dgvVentas.Name = "dgvVentas";
        this.dgvVentas.ReadOnly = true;
        this.dgvVentas.RowHeadersVisible = false;
        this.dgvVentas.RowTemplate.Height = 35;
        this.dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvVentas.Size = new Size(960, 350);

        // Buttons
        this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.btnActualizar.FlatAppearance.BorderSize = 0;
        this.btnActualizar.FlatStyle = FlatStyle.Flat;
        this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnActualizar.ForeColor = System.Drawing.Color.White;
        this.btnActualizar.Location = new Point(20, 430);
        this.btnActualizar.Name = "btnActualizar";
        this.btnActualizar.Size = new Size(120, 40);
        this.btnActualizar.Text = "ACTUALIZAR";
        this.btnActualizar.UseVisualStyleBackColor = false;
        this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);

        this.btnCerrar.BackColor = System.Drawing.Color.Gray;
        this.btnCerrar.FlatAppearance.BorderSize = 0;
        this.btnCerrar.FlatStyle = FlatStyle.Flat;
        this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnCerrar.ForeColor = System.Drawing.Color.White;
        this.btnCerrar.Location = new Point(860, 430);
        this.btnCerrar.Name = "btnCerrar";
        this.btnCerrar.Size = new Size(120, 40);
        this.btnCerrar.Text = "CERRAR";
        this.btnCerrar.UseVisualStyleBackColor = false;
        this.btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

        // Form
        this.Text = "Historial de Ventas";
        this.StartPosition = FormStartPosition.CenterParent;
        this.ClientSize = new Size(1000, 490);
        this.FormBorderStyle = FormBorderStyle.Sizable;

        this.Controls.Add(this.headerPanel);
        this.Controls.AddRange(new Control[] { dgvVentas, btnActualizar, btnCerrar });
        ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
        this.ResumeLayout(false);
    }
}