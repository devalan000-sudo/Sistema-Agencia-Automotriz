using System.Windows.Forms;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormVehiculoVendidoList
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvHistorial;
    private Label lblTitulo;
    private Label lblTotal;
    private Button btnActualizar;
    private Button btnCerrar;

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
        this.dgvHistorial = new DataGridView();
        this.lblTitulo = new Label();
        this.lblTotal = new Label();
        this.btnActualizar = new Button();
        this.btnCerrar = new Button();

        ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
        this.SuspendLayout();

        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.Location = new Point(20, 20);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new Size(350, 30);
        this.lblTitulo.Text = "Historial de Vehículos Vendidos";

        this.dgvHistorial.AllowUserToAddRows = false;
        this.dgvHistorial.AllowUserToDeleteRows = false;
        this.dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvHistorial.Location = new Point(20, 60);
        this.dgvHistorial.Name = "dgvHistorial";
        this.dgvHistorial.ReadOnly = true;
        this.dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvHistorial.Size = new Size(960, 400);
        this.dgvHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));

        this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblTotal.Location = new Point(20, 470);
        this.lblTotal.Name = "lblTotal";
        this.lblTotal.Size = new Size(400, 25);
        this.lblTotal.Text = "Total: 0";
        this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));

        this.btnActualizar.Location = new Point(800, 470);
        this.btnActualizar.Name = "btnActualizar";
        this.btnActualizar.Size = new Size(80, 30);
        this.btnActualizar.Text = "Actualizar";
        this.btnActualizar.UseVisualStyleBackColor = true;
        this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);

        this.btnCerrar.Location = new Point(890, 470);
        this.btnCerrar.Name = "btnCerrar";
        this.btnCerrar.Size = new Size(80, 30);
        this.btnCerrar.Text = "Cerrar";
        this.btnCerrar.UseVisualStyleBackColor = true;
        this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

        this.Controls.Add(this.lblTitulo);
        this.Controls.Add(this.dgvHistorial);
        this.Controls.Add(this.lblTotal);
        this.Controls.Add(this.btnActualizar);
        this.Controls.Add(this.btnCerrar);

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1000, 520);
        this.Name = "FormVehiculoVendidoList";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Historial de Vehículos Vendidos";

        ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
        this.ResumeLayout(false);
    }
}