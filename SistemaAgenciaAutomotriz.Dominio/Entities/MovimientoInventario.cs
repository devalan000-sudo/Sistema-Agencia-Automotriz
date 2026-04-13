using System.ComponentModel.DataAnnotations;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;

namespace SistemaAgenciaAutomotriz.Dominio.Entities;

public class MovimientoInventario
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    public int ProductoId { get; set; }

    public TipoMovimiento Tipo { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El motivo es requerido")]
    [StringLength(200, ErrorMessage = "El motivo no puede exceder 200 caracteres")]
    public string Motivo { get; set; } = string.Empty;

    public int UsuarioId { get; set; }

    public Producto Producto { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}