using System.ComponentModel.DataAnnotations;

namespace SistemaAgenciaAutomotriz.Dominio.Entities;

public class Vehiculo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El VIN es requerido")]
    [StringLength(17, MinimumLength = 17, ErrorMessage = "El VIN debe tener exactamente 17 caracteres")]
    [RegularExpression(@"^[A-HJ-NPR-Z0-9]{17}$", ErrorMessage = "VIN inválido")]
    public string VIN { get; set; } = string.Empty;

    [Required(ErrorMessage = "La marca es requerida")]
    [StringLength(50, ErrorMessage = "La marca no puede exceder 50 caracteres")]
    public string Marca { get; set; } = string.Empty;

    [Required(ErrorMessage = "El modelo es requerido")]
    [StringLength(50, ErrorMessage = "El modelo no puede exceder 50 caracteres")]
    public string Modelo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El año es requerido")]
    [Range(1900, 2030, ErrorMessage = "El año debe estar entre 1900 y 2030")]
    public int Year { get; set; }

    [StringLength(30, ErrorMessage = "El color no puede exceder 30 caracteres")]
    public string Color { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "El kilometraje no puede ser negativo")]
    public int Kilometraje { get; set; }

    [Required(ErrorMessage = "El precio es requerido")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal Precio { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El costo no puede ser negativo")]
    public decimal Costo { get; set; }

    [Range(1, 3, ErrorMessage = "Tipo de vehículo inválido")]
    public int Tipo { get; set; }

    [Range(1, 3, ErrorMessage = "Estatus de vehículo inválido")]
    public int Estatus { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
    public string Descripcion { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "La ruta de imagen no puede exceder 200 caracteres")]
    public string ImagenPath { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "El motor no puede exceder 50 caracteres")]
    public string Motor { get; set; } = string.Empty;

    [StringLength(30, ErrorMessage = "La transmisión no puede exceder 30 caracteres")]
    public string Transmision { get; set; } = string.Empty;

    [StringLength(30, ErrorMessage = "El combustible no puede exceder 30 caracteres")]
    public string Combustible { get; set; } = string.Empty;

    public bool Activo { get; set; } = true;
    public DateTime FechaAlta { get; set; } = DateTime.Now;
}