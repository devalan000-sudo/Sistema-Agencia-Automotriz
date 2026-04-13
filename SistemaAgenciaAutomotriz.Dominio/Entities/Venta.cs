using System.ComponentModel.DataAnnotations;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;

namespace SistemaAgenciaAutomotriz.Dominio.Entities;

public class Venta
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    public int? ClienteId { get; set; }

    public int? VehiculoId { get; set; }

    [Required(ErrorMessage = "El usuario es requerido")]
    public int UsuarioId { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El subtotal no puede ser negativo")]
    public decimal Subtotal { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El IVA no puede ser negativo")]
    public decimal IVA { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor a 0")]
    public decimal Total { get; set; }

    public MetodoPago MetodoPago { get; set; }
    public EstatusVenta Estatus { get; set; } = EstatusVenta.Completada;

    public TipoPago TipoPagoVEH { get; set; } = TipoPago.Contado;

    [Range(0, double.MaxValue, ErrorMessage = "El enganche no puede ser negativo")]
    public decimal Enganche { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El monto financiado no puede ser negativo")]
    public decimal MontoFinanciado { get; set; }

    [Range(0, 120, ErrorMessage = "El plazo debe estar entre 0 y 120 meses")]
    public int PlazoMeses { get; set; }

    [Range(0, 100, ErrorMessage = "La tasa de interés debe estar entre 0% y 100%")]
    public decimal TasaInteres { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "La mensualidad no puede ser negativa")]
    public decimal Mensualidad { get; set; }

    public bool RequiereSeguro { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El costo del seguro no puede ser negativo")]
    public decimal CostoSeguro { get; set; }

    public Cliente? Cliente { get; set; }
    public Vehiculo? Vehiculo { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public ICollection<VentaDetalle> Detalles { get; set; } = new List<VentaDetalle>();
    public CuentaPorCobrar? CuentaPorCobrar { get; set; }
}