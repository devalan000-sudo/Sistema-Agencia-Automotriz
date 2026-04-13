using SistemaAgenciaAutomotriz.Dominio.Interfaces;
using SistemaAgenciaAutomotriz.Dominio.ValueObjects;

namespace SistemaAgenciaAutomotriz.Dominio.Services;

public class VentaCalculadora : IVentaCalculadora
{
    public const decimal IVA_TASA = 0.16m;

    public decimal CalcularIVA(decimal subtotal)
    {
        return subtotal * IVA_TASA;
    }

    public decimal CalcularMensualidad(decimal monto, int plazo, decimal tasaAnual)
    {
        if (plazo <= 0 || tasaAnual <= 0 || monto <= 0)
            return 0;

        decimal tasaMensual = tasaAnual / 12 / 100;
        double factor = Math.Pow(1 + (double)tasaMensual, plazo);
        return monto * tasaMensual * (decimal)factor / ((decimal)factor - 1);
    }

    public TotalesVenta CalcularTotales(decimal precioVehiculo, IEnumerable<Entities.VentaDetalle> accesorios)
    {
        decimal subtotal = precioVehiculo + accesorios.Sum(a => a.Importe);
        decimal iva = CalcularIVA(subtotal);
        decimal total = subtotal + iva;

        return new TotalesVenta(subtotal, iva, total);
    }

    public TotalesVenta CalcularTotalesConFinanciamiento(
        decimal precioVehiculo, 
        IEnumerable<Entities.VentaDetalle> accesorios, 
        DatosFinanciamiento financiamiento)
    {
        decimal subtotal = precioVehiculo + accesorios.Sum(a => a.Importe);
        decimal iva = CalcularIVA(subtotal);
        decimal total = subtotal + iva;

        decimal? mensualidad = null;
        if (financiamiento.PlazoMeses > 0 && financiamiento.TasaAnual > 0)
        {
            mensualidad = CalcularMensualidad(
                financiamiento.MontoFinanciado, 
                financiamiento.PlazoMeses, 
                financiamiento.TasaAnual);
        }

        return new TotalesVenta(subtotal, iva, total, mensualidad, financiamiento.PlazoMeses);
    }
}