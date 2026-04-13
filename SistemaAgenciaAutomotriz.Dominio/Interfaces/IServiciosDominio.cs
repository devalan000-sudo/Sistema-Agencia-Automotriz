using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Dominio.ValueObjects;

namespace SistemaAgenciaAutomotriz.Dominio.Interfaces;

public interface IVentaDominio
{
    Venta CrearVenta(
        int? clienteId,
        int vehiculoId,
        int usuarioId,
        MetodoPago metodoPago,
        TipoPago tipoPago,
        IEnumerable<VentaDetalle> accesorios,
        DatosFinanciamiento? financiamiento);

    void Cancelar(Venta venta);
    bool PuedeCancelar(Venta venta);
}

public interface IInventarioDominio
{
    bool ValidarStock(Producto producto, int cantidad);
    List<MovimientoInventario> GenerarMovimientosVenta(Venta venta);
    List<MovimientoInventario> GenerarMovimientosCancelacion(Venta venta);
}

public interface ICuentaPorCobrarDominio
{
    EstatusCuentaPorCobrar CalcularEstado(decimal total, decimal pagado);
    bool RequiereAbono(decimal total, decimal pagado);
    (decimal nuevoPagado, EstatusCuentaPorCobrar nuevoEstado) ProcesarAbono(decimal totalActual, decimal pagadoActual, decimal montoAbono);
}