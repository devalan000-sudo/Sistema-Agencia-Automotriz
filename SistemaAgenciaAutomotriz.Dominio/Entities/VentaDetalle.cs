using System.ComponentModel.DataAnnotations;

namespace SistemaAgenciaAutomotriz.Dominio.Entities;

public class VentaDetalle
{
    public int Id { get; set; }

    public int VentaId { get; set; }

    public int ProductoId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public int Cantidad { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor a 0")]
    public decimal PrecioUnitario { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El importe debe ser mayor a 0")]
    public decimal Importe { get; set; }

    public Venta Venta { get; set; } = null!;
    public Producto Producto { get; set; } = null!;
}