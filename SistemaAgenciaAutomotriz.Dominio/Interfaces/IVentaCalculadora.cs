using SistemaAgenciaAutomotriz.Dominio.ValueObjects;

namespace SistemaAgenciaAutomotriz.Dominio.Interfaces;

public interface IVentaCalculadora
{
    decimal CalcularIVA(decimal subtotal);
    decimal CalcularMensualidad(decimal monto, int plazo, decimal tasaAnual);
    TotalesVenta CalcularTotales(decimal precioVehiculo, IEnumerable<Entities.VentaDetalle> accesorios);
    TotalesVenta CalcularTotalesConFinanciamiento(decimal precioVehiculo, IEnumerable<Entities.VentaDetalle> accesorios, DatosFinanciamiento financiamiento);
}