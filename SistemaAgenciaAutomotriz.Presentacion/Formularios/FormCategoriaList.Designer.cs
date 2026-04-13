namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormCategoriaList
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvCategorias;
    private Button btnNuevo;
    private Button btnEditar;
    private Button btnEliminar;
    private Button btnActualizar;
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
        this.dgvCategorias = new DataGridView();
        this.btnNuevo = new Button();
        this.btnEditar = new Button();
        this.btnEliminar = new Button();
        this.btnActualizar = new Button();
        this.headerPanel = new Panel();
        this.lblTitulo = new Label();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
        this.SuspendLayout();

        // headerPanel
        this.headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
        this.headerPanel.Location = new System.Drawing.Point(0, 0);
        this.headerPanel.Name = "headerPanel";
        this.headerPanel.Size = new System.Drawing.Size(650, 50);
        this.headerPanel.TabIndex = 0;

        // lblTitulo
        this.lblTitulo.AutoSize = false;
        this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.ForeColor = System.Drawing.Color.White;
        this.lblTitulo.Location = new System.Drawing.Point(0, 0);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new System.Drawing.Size(650, 50);
        this.lblTitulo.Text = "  Categorías";
        this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.headerPanel.Controls.Add(this.lblTitulo);

        // dgvCategorias
        this.dgvCategorias.AllowUserToAddRows = false;
        this.dgvCategorias.AllowUserToDeleteRows = false;
        this.dgvCategorias.AllowUserToResizeRows = false;
        this.dgvCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvCategorias.BackgroundColor = System.Drawing.Color.White;
        this.dgvCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvCategorias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
        this.dgvCategorias.ColumnHeadersHeight = 40;
        this.dgvCategorias.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        this.dgvCategorias.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.dgvCategorias.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
        this.dgvCategorias.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.dgvCategorias.EnableHeadersVisualStyles = false;
        this.dgvCategorias.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
        this.dgvCategorias.Location = new System.Drawing.Point(20, 65);
        this.dgvCategorias.Name = "dgvCategorias";
        this.dgvCategorias.ReadOnly = true;
        this.dgvCategorias.RowHeadersVisible = false;
        this.dgvCategorias.RowTemplate.Height = 35;
        this.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvCategorias.Size = new System.Drawing.Size(610, 280);
        this.dgvCategorias.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.dgvCategorias.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.dgvCategorias.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

        // btnNuevo
        this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
        this.btnNuevo.FlatAppearance.BorderSize = 0;
        this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.btnNuevo.ForeColor = System.Drawing.Color.White;
        this.btnNuevo.Location = new System.Drawing.Point(20, 360);
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
        this.btnEditar.Location = new System.Drawing.Point(150, 360);
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
        this.btnEliminar.Location = new System.Drawing.Point(280, 360);
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
        this.btnActualizar.Location = new System.Drawing.Point(510, 360);
        this.btnActualizar.Name = "btnActualizar";
        this.btnActualizar.Size = new System.Drawing.Size(120, 40);
        this.btnActualizar.Text = "ACTUALIZAR";
        this.btnActualizar.UseVisualStyleBackColor = false;
        this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

        // FormCategoriaList
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(650, 420);
        this.Controls.Add(this.dgvCategorias);
        this.Controls.Add(this.btnNuevo);
        this.Controls.Add(this.btnEditar);
        this.Controls.Add(this.btnEliminar);
        this.Controls.Add(this.btnActualizar);
        this.Controls.Add(this.headerPanel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        this.Name = "FormCategoriaList";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Categorías";
        ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
        this.ResumeLayout(false);
    }
}