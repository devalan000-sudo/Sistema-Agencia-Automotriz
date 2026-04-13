using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;
using System.Text;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormCuentaPorCobrarList : Form
{
    private readonly ICuentaPorCobrarServicio _cuentaServicio;
    private readonly IClienteServicio _clienteServicio;

    public FormCuentaPorCobrarList(ICuentaPorCobrarServicio cuentaServicio, IClienteServicio clienteServicio)
    {
        _cuentaServicio = cuentaServicio;
        _clienteServicio = clienteServicio;
        InitializeComponent();
        CargarCuentas();
    }

    private async void CargarCuentas()
    {
        try
        {
            var cuentas = await _cuentaServicio.GetActivasAsync();
            var totalPendiente = await _cuentaServicio.GetTotalPendienteAsync();
            lblTotalPendiente.Text = $"Total Pendiente: {totalPendiente:C2}";

            dgvCuentas.DataSource = cuentas.Select(c => new
            {
                c.Id,
                Cliente = c.Cliente?.Nombre ?? "Sin cliente",
                c.Total,
                c.Pagado,
                Restante = c.Total - c.Pagado,
                c.FechaVencimiento,
                Estado = c.Estatus.ToString(),
                DiasRestantes = (c.FechaVencimiento - DateTime.Now).Days
            }).ToList();

            dgvCuentas.Columns["Id"].Width = 50;
            dgvCuentas.Columns["Cliente"].Width = 180;
            dgvCuentas.Columns["Total"].Width = 90;
            dgvCuentas.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvCuentas.Columns["Pagado"].Width = 90;
            dgvCuentas.Columns["Pagado"].DefaultCellStyle.Format = "C2";
            dgvCuentas.Columns["Restante"].Width = 90;
            dgvCuentas.Columns["Restante"].DefaultCellStyle.Format = "C2";
            dgvCuentas.Columns["FechaVencimiento"].Width = 100;
            dgvCuentas.Columns["Estado"].Width = 80;
            dgvCuentas.Columns["DiasRestantes"].Width = 80;

            foreach (DataGridViewRow row in dgvCuentas.Rows)
            {
                var estado = row.Cells["Estado"].Value?.ToString();
                var dias = Convert.ToInt32(row.Cells["DiasRestantes"].Value);
                
                if (estado == "Pendiente" && dias < 0)
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                else if (estado == "Parcial")
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar cuentas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnVerAbonos_Click(object sender, EventArgs e)
    {
        if (dgvCuentas.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione una cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvCuentas.SelectedRows[0].Cells["Id"].Value);
        
        try
        {
            var cuenta = await _cuentaServicio.GetByIdAsync(id);
            var abonos = await _cuentaServicio.GetAbonosAsync(id);

            var sb = new StringBuilder();
            sb.AppendLine($"Cuenta #{cuenta.Id} - Cliente: {cuenta.Cliente?.Nombre}");
            sb.AppendLine($"Total: {cuenta.Total:C2} | Pagado: {cuenta.Pagado:C2} | Restante: {cuenta.Restante:C2}");
            sb.AppendLine(new string('=', 50));
            sb.AppendLine("ABONOS:");
            
            if (abonos.Count == 0)
            {
                sb.AppendLine("No hay abonos registrados.");
            }
            else
            {
                foreach (var a in abonos)
                {
                    sb.AppendLine($"  {a.Fecha:dd/MM/yyyy HH:mm} - {a.Monto:C2} - Usuario: {a.Usuario?.Nombre}");
                    if (!string.IsNullOrEmpty(a.Observaciones))
                        sb.AppendLine($"    Obs: {a.Observaciones}");
                }
            }

            MessageBox.Show(sb.ToString(), "Abonos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnRegistrarAbono_Click(object sender, EventArgs e)
    {
        if (dgvCuentas.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione una cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var id = Convert.ToInt32(dgvCuentas.SelectedRows[0].Cells["Id"].Value);
        var restante = Convert.ToDecimal(dgvCuentas.SelectedRows[0].Cells["Restante"].Value);

        var form = new FormAbonoEdit(restante);
        if (form.ShowDialog() == DialogResult.OK)
        {
            try
            {
                var abono = new Abono
                {
                    CuentaPorCobrarId = id,
                    Monto = form.Monto,
                    Observaciones = form.Observaciones,
                    UsuarioId = SesionActual.UsuarioLogueado!.Id
                };

                await _cuentaServicio.RegistrarAbonoAsync(abono);
                CargarCuentas();
                MessageBox.Show("Abono registrado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar abono: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnActualizar_Click(object sender, EventArgs e)
    {
        CargarCuentas();
    }
}

public class FormAbonoEdit : Form
{
    private TextBox txtMonto;
    private TextBox txtObservaciones;
    private Button btnGuardar;
    private Button btnCancelar;

    public decimal Monto { get; private set; }
    public string? Observaciones => txtObservaciones.Text.Trim();

    public FormAbonoEdit(decimal restante)
    {
        InitializeComponent();
        txtMonto.Text = restante.ToString("F2");
    }

    private void InitializeComponent()
    {
        this.Text = "Registrar Abono";
        this.Size = new Size(350, 220);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        var lblMonto = new Label { Location = new Point(20, 20), Text = "Monto:", Size = new Size(100, 20) };
        txtMonto = new TextBox { Location = new Point(20, 45), Size = new Size(300, 23) };
        
        var lblObs = new Label { Location = new Point(20, 80), Text = "Observaciones:", Size = new Size(100, 20) };
        txtObservaciones = new TextBox { Location = new Point(20, 105), Size = new Size(300, 50), Multiline = true };

        btnGuardar = new Button
        {
            Location = new Point(90, 160),
            Size = new Size(100, 30),
            Text = "Guardar",
            BackColor = Color.FromArgb(0, 120, 215),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        btnGuardar.Click += (s, e) =>
        {
            if (!decimal.TryParse(txtMonto.Text, out var monto) || monto <= 0)
            {
                MessageBox.Show("Monto inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Monto = monto;
            this.DialogResult = DialogResult.OK;
            this.Close();
        };

        btnCancelar = new Button
        {
            Location = new Point(200, 160),
            Size = new Size(100, 30),
            Text = "Cancelar",
            FlatStyle = FlatStyle.Flat
        };
        btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

        this.Controls.AddRange(new Control[] { lblMonto, txtMonto, lblObs, txtObservaciones, btnGuardar, btnCancelar });
    }
}
