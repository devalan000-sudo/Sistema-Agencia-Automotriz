namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormUsuarioList
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvUsuarios;
    private Button btnNuevo;
    private Button btnEditar;
    private Button btnEliminar;
    private Button btnActualizar;

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
        this.dgvUsuarios = new DataGridView();
        this.btnNuevo = new Button();
        this.btnEditar = new Button();
        this.btnEliminar = new Button();
        this.btnActualizar = new Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
        this.SuspendLayout();

        this.Text = "Usuarios";
        this.StartPosition = FormStartPosition.CenterParent;
        this.ClientSize = new Size(700, 450);

        this.dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvUsuarios.Location = new Point(20, 20);
        this.dgvUsuarios.Name = "dgvUsuarios";
        this.dgvUsuarios.Size = new Size(660, 320);
        this.dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvUsuarios.MultiSelect = false;
        this.dgvUsuarios.ReadOnly = true;
        this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));

        this.btnNuevo.BackColor = Color.FromArgb(0, 120, 215);
        this.btnNuevo.ForeColor = Color.White;
        this.btnNuevo.FlatStyle = FlatStyle.Flat;
        this.btnNuevo.Location = new Point(20, 360);
        this.btnNuevo.Size = new Size(120, 35);
        this.btnNuevo.Text = "Nuevo";
        this.btnNuevo.UseVisualStyleBackColor = false;
        this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);

        this.btnEditar.BackColor = Color.FromArgb(40, 167, 69);
        this.btnEditar.ForeColor = Color.White;
        this.btnEditar.FlatStyle = FlatStyle.Flat;
        this.btnEditar.Location = new Point(150, 360);
        this.btnEditar.Size = new Size(120, 35);
        this.btnEditar.Text = "Editar";
        this.btnEditar.UseVisualStyleBackColor = false;
        this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);

        this.btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
        this.btnEliminar.ForeColor = Color.White;
        this.btnEliminar.FlatStyle = FlatStyle.Flat;
        this.btnEliminar.Location = new Point(280, 360);
        this.btnEliminar.Size = new Size(120, 35);
        this.btnEliminar.Text = "Eliminar";
        this.btnEliminar.UseVisualStyleBackColor = false;
        this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

        this.btnActualizar.FlatStyle = FlatStyle.Flat;
        this.btnActualizar.Location = new Point(560, 360);
        this.btnActualizar.Size = new Size(120, 35);
        this.btnActualizar.Text = "Actualizar";
        this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

        this.Controls.Add(this.dgvUsuarios);
        this.Controls.Add(this.btnNuevo);
        this.Controls.Add(this.btnEditar);
        this.Controls.Add(this.btnEliminar);
        this.Controls.Add(this.btnActualizar);

        ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
        this.ResumeLayout(false);
    }

    private void btnActualizar_Click(object sender, EventArgs e)
    {
        CargarUsuarios();
    }
}
