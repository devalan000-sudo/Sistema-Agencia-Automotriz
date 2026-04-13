using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Dominio.Services;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormVehiculoEdit : Form
{
    public Vehiculo? Vehiculo { get; private set; }
    private bool _esNuevo;
    private readonly IValidadorService _validadorService;

    public FormVehiculoEdit(IValidadorService validadorService, Vehiculo? vehiculo = null)
    {
        InitializeComponent();
        _esNuevo = vehiculo == null;
        _validadorService = validadorService;
        Vehiculo = vehiculo ?? new Vehiculo();

        txtId.Text = _esNuevo ? "Auto" : Vehiculo!.Id.ToString();
        txtVIN.Text = Vehiculo!.VIN;
        txtMarca.Text = Vehiculo.Marca;
        txtModelo.Text = Vehiculo.Modelo;
        txtYear.Text = Vehiculo.Year.ToString();
        txtColor.Text = Vehiculo.Color;
        txtKilometraje.Text = Vehiculo.Kilometraje.ToString();
        txtPrecio.Text = Vehiculo.Precio.ToString("F2");
        txtCosto.Text = Vehiculo.Costo.ToString("F2");
        txtMotor.Text = Vehiculo.Motor;
        txtTransmision.Text = Vehiculo.Transmision;
        txtCombustible.Text = Vehiculo.Combustible;
        txtDescripcion.Text = Vehiculo.Descripcion;
        cmbTipo.SelectedIndex = Vehiculo.Tipo - 1;

        lblTitulo.Text = _esNuevo ? "Nuevo Vehículo" : "Editar Vehículo";
    }

    private void btnGuardar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtVIN.Text) || string.IsNullOrWhiteSpace(txtMarca.Text) || string.IsNullOrWhiteSpace(txtModelo.Text))
        {
            MessageBox.Show("VIN, Marca y Modelo son obligatorios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!int.TryParse(txtYear.Text, out int year) || year < 1900 || year > DateTime.Now.Year + 1)
        {
            MessageBox.Show("Año inválido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
        {
            MessageBox.Show("Precio inválido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Vehiculo!.VIN = txtVIN.Text.Trim().ToUpper();
        Vehiculo.Marca = txtMarca.Text.Trim();
        Vehiculo.Modelo = txtModelo.Text.Trim();
        Vehiculo.Year = year;
        Vehiculo.Color = txtColor.Text.Trim();
        Vehiculo.Kilometraje = int.TryParse(txtKilometraje.Text, out int km) ? km : 0;
        Vehiculo.Precio = precio;
        Vehiculo.Costo = decimal.TryParse(txtCosto.Text, out decimal costo) ? costo : 0;
        Vehiculo.Tipo = cmbTipo.SelectedIndex + 1;
        Vehiculo.Motor = txtMotor.Text.Trim();
        Vehiculo.Transmision = txtTransmision.Text.Trim();
        Vehiculo.Combustible = txtCombustible.Text.Trim();
        Vehiculo.Descripcion = txtDescripcion.Text.Trim();

        var resultado = _validadorService.Validar(Vehiculo);

        if (!resultado.EsValido)
        {
            MessageBox.Show(
                string.Join("\n", resultado.Errores),
                "Errores de Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            ResaltarCamposConErrores(resultado.ErroresPorCampo);
            return;
        }

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void ResaltarCamposConErrores(Dictionary<string, string> errores)
    {
        ResetearColores();

        foreach (var campo in errores.Keys)
        {
            Control? control = campo.ToLower() switch
            {
                "vin" => txtVIN,
                "year" => txtYear,
                "precio" => txtPrecio,
                "costo" => txtCosto,
                "kilometraje" => txtKilometraje,
                "tipo" => cmbTipo,
                "marca" => txtMarca,
                "modelo" => txtModelo,
                "color" => txtColor,
                "descripcion" => txtDescripcion,
                "motor" => txtMotor,
                "transmision" => txtTransmision,
                "combustible" => txtCombustible,
                _ => null
            };

            if (control is TextBox tb)
                tb.BackColor = Color.LightPink;
            else if (control is ComboBox cb)
                cb.BackColor = Color.LightPink;
        }
    }

    private void ResetearColores()
    {
        txtVIN.BackColor = SystemColors.Window;
        txtYear.BackColor = SystemColors.Window;
        txtPrecio.BackColor = SystemColors.Window;
        txtCosto.BackColor = SystemColors.Window;
        txtKilometraje.BackColor = SystemColors.Window;
        txtMarca.BackColor = SystemColors.Window;
        txtModelo.BackColor = SystemColors.Window;
        txtColor.BackColor = SystemColors.Window;
        txtDescripcion.BackColor = SystemColors.Window;
        txtMotor.BackColor = SystemColors.Window;
        txtTransmision.BackColor = SystemColors.Window;
        txtCombustible.BackColor = SystemColors.Window;
        cmbTipo.BackColor = SystemColors.Window;
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}