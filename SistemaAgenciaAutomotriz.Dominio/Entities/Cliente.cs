using System.ComponentModel.DataAnnotations;

namespace SistemaAgenciaAutomotriz.Dominio.Entities;

public class Cliente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El RFC es requerido")]
    [StringLength(13, MinimumLength = 10, ErrorMessage = "El RFC debe tener entre 10 y 13 caracteres")]
    [RegularExpression(@"^[A-Z&Ñ]{3,4}[0-9]{6}[A-Z0-9]{2,3}$", ErrorMessage = "RFC inválido")]
    public string RFC { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "Email inválido")]
    [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es requerido")]
    [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
    [RegularExpression(@"^[\d\s\-\+\(\)]+$", ErrorMessage = "Teléfono inválido")]
    public string Telefono { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
    public string Direccion { get; set; } = string.Empty;

    public DateTime FechaAlta { get; set; } = DateTime.Now;
    public bool Activo { get; set; } = true;

    [StringLength(20, ErrorMessage = "La licencia no puede exceder 20 caracteres")]
    public string Licencia { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "El INE no puede exceder 20 caracteres")]
    public string INE { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "El teléfono de emergencia no puede exceder 20 caracteres")]
    [RegularExpression(@"^[\d\s\-\+\(\)]*$", ErrorMessage = "Teléfono de emergencia inválido")]
    public string TelefonoEmergencia { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "El contacto de emergencia no puede exceder 100 caracteres")]
    public string ContactoEmergencia { get; set; } = string.Empty;

    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    public ICollection<CuentaPorCobrar> CuentasPorCobrar { get; set; } = new List<CuentaPorCobrar>();
}