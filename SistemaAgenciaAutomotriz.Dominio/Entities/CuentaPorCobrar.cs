using System.ComponentModel.DataAnnotations;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;

namespace SistemaAgenciaAutomotriz.Dominio.Entities;

public class CuentaPorCobrar
{
    public int Id { get; set; }

    public int VentaId { get; set; }

    public int ClienteId { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor a 0")]
    public decimal Total { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El monto pagado no puede ser negativo")]
    public decimal Pagado { get; set; }

    public decimal Restante => Total - Pagado;

    public DateTime FechaVencimiento { get; set; }

    public EstatusCuentaPorCobrar Estatus { get; set; } = EstatusCuentaPorCobrar.Pendiente;
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public Venta Venta { get; set; } = null!;
    public Cliente Cliente { get; set; } = null!;
    public ICollection<Abono> Abonos { get; set; } = new List<Abono>();
}

public class Abono
{
    public int Id { get; set; }

    public int CuentaPorCobrarId { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
    public decimal Monto { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    [StringLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
    public string? Observaciones { get; set; }

    public int UsuarioId { get; set; }

    public CuentaPorCobrar CuentaPorCobrar { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}