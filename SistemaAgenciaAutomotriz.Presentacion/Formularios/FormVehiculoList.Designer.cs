namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormVehiculoList
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvVehiculos;
    private Button btnNuevo;
    private Button btnEditar;
    private Button btnEliminar;
    private Button btnActualizar;
    private Panel headerPanel;
    private Label lblTitulo;
    private Panel pnlAcciones;

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
        this.btnNuevo = new Button();
        this.btnEditar = new Button();
        this.btnEliminar = new Button();
        this.btnActualizar = new Button();
        this.headerPanel = new Panel();
        this.pnlAcciones = new Panel();
        this.lblTitulo = new Label();
        ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).BeginInit();
        this.SuspendLayout();

        // headerPanel
        this.headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
        this.headerPanel.Location = new System.Drawing.Point(0, 0);
        this.headerPanel.Name = "headerPanel";
        this.headerPanel.Size = new System.Drawing.Size(1000, 50);
        this.headerPanel.TabIndex = 0;

        // lblTitulo
        this.lblTitulo.AutoSize = false;
        this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.ForeColor = System.Drawing.Color.White;
        this.lblTitulo.Location = new System.Drawing.Point(0, 0);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new System.Drawing.Size(1000, 50);
        this.lblTitulo.Text = "  Catálogo de Vehículos";
        this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.headerPanel.Controls.Add(this.lblTitulo);

        // dgvVehiculos
        this.dgvVehiculos.AllowUserToAddRows = false;
        this.dgvVehiculos.AllowUserToDeleteRows = false;
        this.dgvVehiculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvVehiculos.BackgroundColor = System.Drawing.Color.White;
        this.dgvVehiculos.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvVehiculos.ColumnHeadersHeight = 40;
        this.dgvVehiculos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        this.dgvVehiculos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.dgvVehiculos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this.dgvVehiculos.EnableHeadersVisualStyles = false;
        this.dgvVehiculos.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
        this.dgvVehiculos.Location = new System.Drawing.Point(20, 65);
        this.dgvVehiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        this.dgvVehiculos.Name = "dgvVehiculos";
        this.dgvVehiculos.ReadOnly = true;
        this.dgvVehiculos.RowHeadersVisible = false;
        this.dgvVehiculos.RowTemplate.Height = 35;
        this.dgvVehiculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvVehiculos.Size = new System.Drawing.Size(960, 400);
        this.dgvVehiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        this.dgvVehiculos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.dgvVehiculos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.dgvVehiculos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

        // btnNuevo
        this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.btnNuevo.FlatAppearance.BorderSize = 0;
        this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnNuevo.ForeColor = System.Drawing.Color.White;
        this.btnNuevo.Location = new System.Drawing.Point(10, 8);
        this.btnNuevo.Name = "btnNuevo";
        this.btnNuevo.Size = new System.Drawing.Size(120, 40);
        this.btnNuevo.Text = "NUEVO";
        this.btnNuevo.UseVisualStyleBackColor = false;
        this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

        // btnEditar
        this.btnEditar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
        this.btnEditar.FlatAppearance.BorderSize = 0;
        this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnEditar.ForeColor = System.Drawing.Color.White;
        this.btnEditar.Location = new System.Drawing.Point(140, 8);
        this.btnEditar.Name = "btnEditar";
        this.btnEditar.Size = new System.Drawing.Size(120, 40);
        this.btnEditar.Text = "EDITAR";
        this.btnEditar.UseVisualStyleBackColor = false;
        this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

        // btnEliminar
        this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
        this.btnEliminar.FlatAppearance.BorderSize = 0;
        this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnEliminar.ForeColor = System.Drawing.Color.White;
        this.btnEliminar.Location = new System.Drawing.Point(270, 8);
        this.btnEliminar.Name = "btnEliminar";
        this.btnEliminar.Size = new System.Drawing.Size(120, 40);
        this.btnEliminar.Text = "ELIMINAR";
        this.btnEliminar.UseVisualStyleBackColor = false;
        this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

        // btnActualizar
        this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
        this.btnActualizar.FlatAppearance.BorderSize = 0;
        this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnActualizar.ForeColor = System.Drawing.Color.White;
        this.btnActualizar.Location = new System.Drawing.Point(390, 8);
        this.btnActualizar.Name = "btnActualizar";
        this.btnActualizar.Size = new System.Drawing.Size(120, 40);
        this.btnActualizar.Text = "ACTUALIZAR";
        this.btnActualizar.UseVisualStyleBackColor = false;
        this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

        // FormVehiculoList
        this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlAcciones.Height = 60;
        this.pnlAcciones.BackColor = System.Drawing.SystemColors.Control;
        this.pnlAcciones.Padding = new System.Windows.Forms.Padding(5);
        this.pnlAcciones.Controls.Add(this.btnNuevo);
        this.pnlAcciones.Controls.Add(this.btnEditar);
        this.pnlAcciones.Controls.Add(this.btnEliminar);
        this.pnlAcciones.Controls.Add(this.btnActualizar);
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1280, 720);
        this.Controls.Add(this.headerPanel);
        this.Controls.Add(this.dgvVehiculos);
        this.Controls.Add(this.pnlAcciones);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.Name = "FormVehiculoList";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Catálogo de Vehículos";
        ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).EndInit();
        this.ResumeLayout(false);
    }
}
