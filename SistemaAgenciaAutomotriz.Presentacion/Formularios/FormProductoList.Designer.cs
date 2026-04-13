namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormProductoList
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvProductos;
    private Button btnNuevo;
    private Button btnEditar;
    private Button btnEliminar;
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
        this.dgvProductos = new DataGridView();
        this.btnNuevo = new Button();
        this.btnEditar = new Button();
        this.btnEliminar = new Button();
        this.btnActualizar = new Button();
        this.txtBuscar = new TextBox();
        this.lblBuscar = new Label();
        this.headerPanel = new Panel();
        this.lblTitulo = new Label();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
        this.SuspendLayout();

        // headerPanel
        this.headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
        this.headerPanel.Location = new System.Drawing.Point(0, 0);
        this.headerPanel.Name = "headerPanel";
        this.headerPanel.Size = new System.Drawing.Size(1190, 50);
        this.headerPanel.TabIndex = 0;

        // lblTitulo
        this.lblTitulo.AutoSize = false;
        this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.ForeColor = System.Drawing.Color.White;
        this.lblTitulo.Location = new System.Drawing.Point(0, 0);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new System.Drawing.Size(1190, 50);
        this.lblTitulo.Text = "  Inventario de Productos";
        this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.headerPanel.Controls.Add(this.lblTitulo);

        // lblBuscar
        this.lblBuscar.BackColor = System.Drawing.Color.Transparent;
        this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
        this.lblBuscar.Location = new System.Drawing.Point(20, 70);
        this.lblBuscar.Name = "lblBuscar";
        this.lblBuscar.Size = new System.Drawing.Size(70, 20);
        this.lblBuscar.Text = "BUSCAR";

        // txtBuscar
        this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
        this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtBuscar.Location = new System.Drawing.Point(20, 92);
        this.txtBuscar.Name = "txtBuscar";
        this.txtBuscar.Size = new System.Drawing.Size(250, 25);
        this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);

        // dgvProductos
        this.dgvProductos.AllowUserToAddRows = false;
        this.dgvProductos.AllowUserToDeleteRows = false;
        this.dgvProductos.AllowUserToResizeRows = false;
        this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
        this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
        this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.dgvProductos.ColumnHeadersHeight = 40;
        this.dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        this.dgvProductos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this.dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.dgvProductos.EnableHeadersVisualStyles = false;
        this.dgvProductos.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
        this.dgvProductos.Location = new System.Drawing.Point(20, 125);
        this.dgvProductos.Name = "dgvProductos";
        this.dgvProductos.ReadOnly = true;
        this.dgvProductos.RowHeadersVisible = false;
        this.dgvProductos.RowTemplate.Height = 35;
        this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvProductos.Size = new System.Drawing.Size(1150, 400);
        this.dgvProductos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.dgvProductos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.dgvProductos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

        // btnNuevo
        this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.btnNuevo.FlatAppearance.BorderSize = 0;
        this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnNuevo.ForeColor = System.Drawing.Color.White;
        this.btnNuevo.Location = new System.Drawing.Point(20, 540);
        this.btnNuevo.Name = "btnNuevo";
        this.btnNuevo.Size = new System.Drawing.Size(120, 40);
        this.btnNuevo.Text = "NUEVO";
        this.btnNuevo.UseVisualStyleBackColor = false;
        this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

        // btnEditar
        this.btnEditar.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
        this.btnEditar.FlatAppearance.BorderSize = 0;
        this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnEditar.ForeColor = System.Drawing.Color.White;
        this.btnEditar.Location = new System.Drawing.Point(150, 540);
        this.btnEditar.Name = "btnEditar";
        this.btnEditar.Size = new System.Drawing.Size(120, 40);
        this.btnEditar.Text = "EDITAR";
        this.btnEditar.UseVisualStyleBackColor = false;
        this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

        // btnEliminar
        this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
        this.btnEliminar.FlatAppearance.BorderSize = 0;
        this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnEliminar.ForeColor = System.Drawing.Color.White;
        this.btnEliminar.Location = new System.Drawing.Point(280, 540);
        this.btnEliminar.Name = "btnEliminar";
        this.btnEliminar.Size = new System.Drawing.Size(120, 40);
        this.btnEliminar.Text = "ELIMINAR";
        this.btnEliminar.UseVisualStyleBackColor = false;
        this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

        // btnActualizar
        this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
        this.btnActualizar.FlatAppearance.BorderSize = 0;
        this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnActualizar.ForeColor = System.Drawing.Color.White;
        this.btnActualizar.Location = new System.Drawing.Point(1000, 540);
        this.btnActualizar.Name = "btnActualizar";
        this.btnActualizar.Size = new System.Drawing.Size(120, 40);
        this.btnActualizar.Text = "ACTUALIZAR";
        this.btnActualizar.UseVisualStyleBackColor = false;
        this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

        // FormProductoList
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1190, 600);
        this.Controls.Add(this.headerPanel);
        this.Controls.Add(this.lblBuscar);
        this.Controls.Add(this.txtBuscar);
        this.Controls.Add(this.dgvProductos);
        this.Controls.Add(this.btnNuevo);
        this.Controls.Add(this.btnEditar);
        this.Controls.Add(this.btnEliminar);
        this.Controls.Add(this.btnActualizar);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.Name = "FormProductoList";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Inventario - Productos";
        ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
        this.ResumeLayout(false);
    }

    private void txtBuscar_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            BuscarProducto();
        }
    }
}