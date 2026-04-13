namespace SistemaAgenciaAutomotriz.Dominio.ValueObjects;

public record DatosFinanciamiento
{
    public decimal Enganche { get; init; }
    public int PlazoMeses { get; init; }
    public decimal TasaAnual { get; init; }
    public bool RequiereSeguro { get; init; }
    public decimal MontoTotal { get; init; }

    public DatosFinanciamiento(decimal enganche, int plazoMeses, decimal tasaAnual, bool requiereSeguro, decimal montoTotal)
    {
        Enganche = enganche;
        PlazoMeses = plazoMeses;
        TasaAnual = tasaAnual;
        RequiereSeguro = requiereSeguro;
        MontoTotal = montoTotal;
    }

    public decimal MontoFinanciado => MontoTotal - Enganche;
}