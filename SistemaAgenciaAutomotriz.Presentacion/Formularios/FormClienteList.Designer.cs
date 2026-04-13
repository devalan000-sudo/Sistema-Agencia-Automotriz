namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormClienteList
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvClientes;
    private Button btnNuevo;
    private Button btnEditar;
    private Button btnEliminar;
    private Button btnVerHistorial;
    private Button btnActualizar;
    private TextBox txtBuscar;
    private Label lblBuscar;
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
        this.dgvClientes = new DataGridView();
        this.btnNuevo = new Button();
        this.btnEditar = new Button();
        this.btnEliminar = new Button();
        this.btnVerHistorial = new Button();
        this.btnActualizar = new Button();
        this.txtBuscar = new TextBox();
        this.lblBuscar = new Label();
        this.headerPanel = new Panel();
        this.lblTitulo = new Label();
        ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
        this.SuspendLayout();

        // Header
        this.headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.headerPanel.Dock = DockStyle.Top;
        this.headerPanel.Location = new Point(0, 0);
        this.headerPanel.Name = "headerPanel";
        this.headerPanel.Size = new Size(850, 50);
        this.headerPanel.TabIndex = 0;

        this.lblTitulo.AutoSize = false;
        this.lblTitulo.Dock = DockStyle.Fill;
        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.ForeColor = System.Drawing.Color.White;
        this.lblTitulo.Location = new Point(0, 0);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new Size(850, 50);
        this.lblTitulo.Text = "  Gestión de Clientes";
        this.lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
        this.headerPanel.Controls.Add(this.lblTitulo);

        // Search
        this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.lblBuscar.Location = new Point(20, 70);
        this.lblBuscar.Name = "lblBuscar";
        this.lblBuscar.Size = new Size(70, 20);
        this.lblBuscar.Text = "BUSCAR";

        this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
        this.txtBuscar.BorderStyle = BorderStyle.FixedSingle;
        this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtBuscar.Location = new Point(20, 92);
        this.txtBuscar.Name = "txtBuscar";
        this.txtBuscar.Size = new Size(250, 25);
        this.txtBuscar.Padding = new Padding(8, 4, 8, 4);
        this.txtBuscar.KeyPress += new KeyPressEventHandler(this.txtBuscar_KeyPress);

        // DataGrid
        this.dgvClientes.AllowUserToAddRows = false;
        this.dgvClientes.AllowUserToDeleteRows = false;
        this.dgvClientes.AllowUserToResizeRows = false;
        this.dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
        this.dgvClientes.BorderStyle = BorderStyle.None;
        this.dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        this.dgvClientes.ColumnHeadersHeight = 40;
        this.dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        this.dgvClientes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this.dgvClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.dgvClientes.EnableHeadersVisualStyles = false;
        this.dgvClientes.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
        this.dgvClientes.Location = new Point(20, 125);
        this.dgvClientes.Name = "dgvClientes";
        this.dgvClientes.ReadOnly = true;
        this.dgvClientes.RowHeadersVisible = false;
        this.dgvClientes.RowTemplate.Height = 35;
        this.dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvClientes.Size = new Size(1150, 350);
        
        // Buttons - adjusted positions
        this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.btnNuevo.FlatAppearance.BorderSize = 0;
        this.btnNuevo.FlatStyle = FlatStyle.Flat;
        this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnNuevo.ForeColor = System.Drawing.Color.White;
        this.btnNuevo.Location = new Point(20, 490);
        this.btnNuevo.Name = "btnNuevo";
        this.btnNuevo.Size = new Size(120, 40);
        this.btnNuevo.Text = "NUEVO";
        this.btnNuevo.UseVisualStyleBackColor = false;
        this.btnNuevo.Cursor = Cursors.Hand;
        this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);

        this.btnEditar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
        this.btnEditar.FlatAppearance.BorderSize = 0;
        this.btnEditar.FlatStyle = FlatStyle.Flat;
        this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnEditar.ForeColor = System.Drawing.Color.White;
        this.btnEditar.Location = new Point(150, 490);
        this.btnEditar.Name = "btnEditar";
        this.btnEditar.Size = new Size(120, 40);
        this.btnEditar.Text = "EDITAR";
        this.btnEditar.UseVisualStyleBackColor = false;
        this.btnEditar.Cursor = Cursors.Hand;
        this.btnEditar.Click += new EventHandler(this.btnEditar_Click);

        this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
        this.btnEliminar.FlatAppearance.BorderSize = 0;
        this.btnEliminar.FlatStyle = FlatStyle.Flat;
        this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnEliminar.ForeColor = System.Drawing.Color.White;
        this.btnEliminar.Location = new Point(280, 490);
        this.btnEliminar.Name = "btnEliminar";
        this.btnEliminar.Size = new Size(120, 40);
        this.btnEliminar.Text = "ELIMINAR";
        this.btnEliminar.UseVisualStyleBackColor = false;
        this.btnEliminar.Cursor = Cursors.Hand;
        this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);

        this.btnVerHistorial.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
        this.btnVerHistorial.FlatAppearance.BorderSize = 0;
        this.btnVerHistorial.FlatStyle = FlatStyle.Flat;
        this.btnVerHistorial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnVerHistorial.ForeColor = System.Drawing.Color.Black;
        this.btnVerHistorial.Location = new Point(410, 490);
        this.btnVerHistorial.Name = "btnVerHistorial";
        this.btnVerHistorial.Size = new Size(130, 40);
        this.btnVerHistorial.Text = "HISTORIAL";
        this.btnVerHistorial.UseVisualStyleBackColor = false;
        this.btnVerHistorial.Cursor = Cursors.Hand;
        this.btnVerHistorial.Click += new EventHandler(this.btnVerHistorial_Click);

        this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
        this.btnActualizar.FlatAppearance.BorderSize = 0;
        this.btnActualizar.FlatStyle = FlatStyle.Flat;
        this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnActualizar.ForeColor = System.Drawing.Color.White;
        this.btnActualizar.Location = new Point(950, 490);
        this.btnActualizar.Name = "btnActualizar";
        this.btnActualizar.Size = new Size(120, 40);
        this.btnActualizar.Text = "ACTUALIZAR";
        this.btnActualizar.UseVisualStyleBackColor = false;
        this.btnActualizar.Cursor = Cursors.Hand;
        this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);
        
        this.headerPanel.Size = new Size(1190, 50);
        this.lblTitulo.Size = new Size(1190, 50);
        this.ClientSize = new Size(1190, 600);
        this.FormBorderStyle = FormBorderStyle.Sizable;

        this.Controls.Add(this.headerPanel);
        this.Controls.AddRange(new Control[] { lblBuscar, txtBuscar, dgvClientes, btnNuevo, btnEditar, btnEliminar, btnVerHistorial, btnActualizar });
        ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
        this.ResumeLayout(false);
    }
}
