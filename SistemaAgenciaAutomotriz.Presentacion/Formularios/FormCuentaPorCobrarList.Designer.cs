namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

partial class FormCuentaPorCobrarList
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvCuentas;
    private Button btnVerAbonos;
    private Button btnRegistrarAbono;
    private Button btnActualizar;
    private Label lblTotalPendiente;

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
        this.Text = "Cuentas por Cobrar";
        this.StartPosition = FormStartPosition.CenterParent;
        this.ClientSize = new Size(900, 550);

        dgvCuentas = new DataGridView();
        btnVerAbonos = new Button();
        btnRegistrarAbono = new Button();
        btnActualizar = new Button();
        lblTotalPendiente = new Label();

        this.SuspendLayout();

        lblTotalPendiente.Location = new Point(20, 20);
        lblTotalPendiente.Size = new Size(400, 25);
        lblTotalPendiente.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
        this.Controls.Add(lblTotalPendiente);

        dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCuentas.Location = new Point(20, 50);
        dgvCuentas.Name = "dgvCuentas";
        dgvCuentas.Size = new Size(860, 380);
        dgvCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCuentas.MultiSelect = false;
        dgvCuentas.ReadOnly = true;
        this.Controls.Add(dgvCuentas);

        btnVerAbonos.FlatStyle = FlatStyle.Flat;
        btnVerAbonos.Location = new Point(20, 450);
        btnVerAbonos.Size = new Size(130, 35);
        btnVerAbonos.Text = "Ver Abonos";
        btnVerAbonos.Click += btnVerAbonos_Click;
        this.Controls.Add(btnVerAbonos);

        btnRegistrarAbono.BackColor = Color.FromArgb(0, 120, 215);
        btnRegistrarAbono.ForeColor = Color.White;
        btnRegistrarAbono.FlatStyle = FlatStyle.Flat;
        btnRegistrarAbono.Location = new Point(160, 450);
        btnRegistrarAbono.Size = new Size(150, 35);
        btnRegistrarAbono.Text = "Registrar Abono";
        btnRegistrarAbono.Click += btnRegistrarAbono_Click;
        this.Controls.Add(btnRegistrarAbono);

        btnActualizar.FlatStyle = FlatStyle.Flat;
        btnActualizar.Location = new Point(780, 450);
        btnActualizar.Size = new Size(100, 35);
        btnActualizar.Text = "Actualizar";
        btnActualizar.Click += btnActualizar_Click;
        this.Controls.Add(btnActualizar);

        this.ResumeLayout(false);
    }
}
