namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormPrincipal
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem vehículosToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem categoríasToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cuentasPorCobrarToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
    private System.Windows.Forms.ToolStripStatusLabel lblFecha;
    private System.Windows.Forms.Panel panelHeader;
    private System.Windows.Forms.Label lblTituloSistema;
    private System.Windows.Forms.PictureBox pictureBox1;

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
        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.vehículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.categoríasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.cuentasPorCobrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
        this.lblFecha = new System.Windows.Forms.ToolStripStatusLabel();
        this.panelHeader = new System.Windows.Forms.Panel();
        this.lblTituloSistema = new System.Windows.Forms.Label();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.panelHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.menuStrip1.SuspendLayout();
        this.statusStrip1.SuspendLayout();
        this.SuspendLayout();

        // Header Panel
        this.panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelHeader.Location = new System.Drawing.Point(0, 0);
        this.panelHeader.Name = "panelHeader";
        this.panelHeader.Size = new System.Drawing.Size(1200, 60);
        this.panelHeader.TabIndex = 0;

        this.lblTituloSistema.AutoSize = false;
        this.lblTituloSistema.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblTituloSistema.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        this.lblTituloSistema.ForeColor = System.Drawing.Color.White;
        this.lblTituloSistema.Location = new System.Drawing.Point(0, 0);
        this.lblTituloSistema.Name = "lblTituloSistema";
        this.lblTituloSistema.Size = new System.Drawing.Size(1200, 60);
        this.lblTituloSistema.Text = "Sistema de Agencia Automotriz";
        this.lblTituloSistema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.lblTituloSistema.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
        this.panelHeader.Controls.Add(this.lblTituloSistema);

        // Menu Strip
        this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        this.menuStrip1.ForeColor = System.Drawing.Color.White;
        this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.menuStrip1.Location = new System.Drawing.Point(0, 60);
        this.menuStrip1.Name = "menuStrip1";
        this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
        this.menuStrip1.TabIndex = 1;
        this.menuStrip1.Text = "menuStrip1";

        // Ventas Menu
        this.ventasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
        this.ventasToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
        this.ventasToolStripMenuItem.Text = "Ventas";

        var ventaVehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        ventaVehiculosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        ventaVehiculosToolStripMenuItem.Name = "ventaVehiculosToolStripMenuItem";
        ventaVehiculosToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
        ventaVehiculosToolStripMenuItem.Text = "Venta de Vehículos";
        ventaVehiculosToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);

        var ventaAccesoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        ventaAccesoriosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        ventaAccesoriosToolStripMenuItem.Name = "ventaAccesoriosToolStripMenuItem";
        ventaAccesoriosToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
        ventaAccesoriosToolStripMenuItem.Text = "Venta de Accesorios";
        ventaAccesoriosToolStripMenuItem.Click += new System.EventHandler(this.ventaAccesoriosToolStripMenuItem_Click);

        var historialVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        historialVentasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        historialVentasToolStripMenuItem.Name = "historialVentasToolStripMenuItem";
        historialVentasToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
        historialVentasToolStripMenuItem.Text = "Historial de Ventas";
        historialVentasToolStripMenuItem.Click += new System.EventHandler(this.historialVentasToolStripMenuItem_Click);

        this.ventasToolStripMenuItem.DropDownItems.Add(ventaVehiculosToolStripMenuItem);
        this.ventasToolStripMenuItem.DropDownItems.Add(ventaAccesoriosToolStripMenuItem);
        this.ventasToolStripMenuItem.DropDownItems.Add(historialVentasToolStripMenuItem);

        // Clientes Menu
        this.clientesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
        this.clientesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
        this.clientesToolStripMenuItem.Text = "Clientes";
        this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);

        // Inventario Menu
        this.inventarioToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
        this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
        this.inventarioToolStripMenuItem.Text = "Inventario";
        this.inventarioToolStripMenuItem.Click += new System.EventHandler(this.inventarioToolStripMenuItem_Click);

        // Vehículos Menu
        this.vehículosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        this.vehículosToolStripMenuItem.Name = "vehículosToolStripMenuItem";
        this.vehículosToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
        this.vehículosToolStripMenuItem.Text = "Vehículos";

        var listaVehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        listaVehiculosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        listaVehiculosToolStripMenuItem.Name = "listaVehiculosToolStripMenuItem";
        listaVehiculosToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
        listaVehiculosToolStripMenuItem.Text = "Lista de Vehículos";
        listaVehiculosToolStripMenuItem.Click += new System.EventHandler(this.vehículosToolStripMenuItem_Click);

        var historialVehiculosVendidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        historialVehiculosVendidosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        historialVehiculosVendidosToolStripMenuItem.Name = "historialVehiculosVendidosToolStripMenuItem";
        historialVehiculosVendidosToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
        historialVehiculosVendidosToolStripMenuItem.Text = "Historial de Vendidos";
        historialVehiculosVendidosToolStripMenuItem.Click += new System.EventHandler(this.historialVehiculosVendidosToolStripMenuItem_Click);

        this.vehículosToolStripMenuItem.DropDownItems.Add(listaVehiculosToolStripMenuItem);
        this.vehículosToolStripMenuItem.DropDownItems.Add(historialVehiculosVendidosToolStripMenuItem);

        // Categorías Menu
        this.categoríasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        this.categoríasToolStripMenuItem.Name = "categoríasToolStripMenuItem";
        this.categoríasToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
        this.categoríasToolStripMenuItem.Text = "Categorías";
        this.categoríasToolStripMenuItem.Click += new System.EventHandler(this.categoríasToolStripMenuItem_Click);

        // Reportes Menu
        this.reportesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
        this.reportesToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
        this.reportesToolStripMenuItem.Text = "Reportes";
        this.reportesToolStripMenuItem.Click += new System.EventHandler(this.reportesToolStripMenuItem_Click);

        // Cuentas por Cobrar Menu
        this.cuentasPorCobrarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        this.cuentasPorCobrarToolStripMenuItem.Name = "cuentasPorCobrarToolStripMenuItem";
        this.cuentasPorCobrarToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
        this.cuentasPorCobrarToolStripMenuItem.Text = "Cuentas x Cobrar";
        this.cuentasPorCobrarToolStripMenuItem.Click += new System.EventHandler(this.cuentasPorCobrarToolStripMenuItem_Click);

        // Usuarios Menu
        this.usuariosToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
        this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
        this.usuariosToolStripMenuItem.Text = "Usuarios";
        this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);


        // Salir Menu
        this.salirToolStripMenuItem.ForeColor = System.Drawing.Color.White;
        this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
        this.salirToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
        this.salirToolStripMenuItem.Text = "Salir";
        this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);

        // Add items to menu
        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.vehículosToolStripMenuItem,
            this.inventarioToolStripMenuItem,
            this.categoríasToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.cuentasPorCobrarToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.salirToolStripMenuItem});

        // Status Strip
        this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        this.statusStrip1.Location = new System.Drawing.Point(0, 628);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Size = new System.Drawing.Size(1200, 24);
        this.statusStrip1.TabIndex = 2;
        this.statusStrip1.Text = "statusStrip1";

        this.lblUsuario.ForeColor = System.Drawing.Color.White;
        this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblUsuario.Name = "lblUsuario";
        this.lblUsuario.Size = new System.Drawing.Size(150, 17);
        this.lblUsuario.Text = "Usuario: Admin";

        this.lblFecha.ForeColor = System.Drawing.Color.White;
        this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblFecha.Name = "lblFecha";
        this.lblFecha.Size = new System.Drawing.Size(150, 17);

        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblFecha});

        // PictureBox
        this.pictureBox1.Location = new System.Drawing.Point(1100, 10);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(40, 40);
        this.pictureBox1.TabIndex = 3;
        this.pictureBox1.TabStop = false;

        // Form
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1200, 652);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.statusStrip1);
        this.Controls.Add(this.menuStrip1);
        this.Controls.Add(this.panelHeader);
        this.MainMenuStrip = this.menuStrip1;
        this.Name = "FormPrincipal";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Sistema de Agencia Automotriz";
        this.Load += new System.EventHandler(this.FormPrincipal_Load);

        this.panelHeader.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.menuStrip1.ResumeLayout(false);
        this.menuStrip1.PerformLayout();
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}