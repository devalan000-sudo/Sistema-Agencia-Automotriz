namespace SistemaAgenciaAutomotriz.Dominio.ValueObjects;

public record TotalesVenta
{
    public decimal Subtotal { get; init; }
    public decimal IVA { get; init; }
    public decimal Total { get; init; }
    public decimal? Mensualidad { get; init; }
    public int? PlazoMeses { get; init; }

    public TotalesVenta(decimal subtotal, decimal iva, decimal total, decimal? mensualidad = null, int? plazoMeses = null)
    {
        Subtotal = subtotal;
        IVA = iva;
        Total = total;
        Mensualidad = mensualidad;
        PlazoMeses = plazoMeses;
    }
}