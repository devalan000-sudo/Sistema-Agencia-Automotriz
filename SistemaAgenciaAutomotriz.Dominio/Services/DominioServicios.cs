using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Dominio.Interfaces;
using SistemaAgenciaAutomotriz.Dominio.ValueObjects;

namespace SistemaAgenciaAutomotriz.Dominio.Services;

public class VentaDominio : IVentaDominio
{
    private readonly IVentaCalculadora _calculadora;

    public VentaDominio(IVentaCalculadora calculadora)
    {
        _calculadora = calculadora;
    }

    public Venta CrearVenta(
        int? clienteId,
        int vehiculoId,
        int usuarioId,
        MetodoPago metodoPago,
        TipoPago tipoPago,
        IEnumerable<VentaDetalle> accesorios,
        DatosFinanciamiento? financiamiento)
    {
        decimal precioVehiculo = 0;
        decimal totalAccesorios = accesorios.Sum(a => a.Importe);
        decimal subtotal = precioVehiculo + totalAccesorios;
        decimal iva = _calculadora.CalcularIVA(subtotal);
        decimal total = subtotal + iva;

        var venta = new Venta
        {
            ClienteId = clienteId,
            VehiculoId = vehiculoId,
            UsuarioId = usuarioId,
            MetodoPago = metodoPago,
            TipoPagoVEH = tipoPago,
            Subtotal = subtotal,
            IVA = iva,
            Total = total,
            Estatus = EstatusVenta.Completada,
            Fecha = DateTime.Now
        };

        if (financiamiento != null && tipoPago == TipoPago.Financiamiento)
        {
            venta.Enganche = financiamiento.Enganche;
            venta.MontoFinanciado = financiamiento.MontoFinanciado;
            venta.PlazoMeses = financiamiento.PlazoMeses;
            venta.TasaInteres = financiamiento.TasaAnual;
            venta.RequiereSeguro = financiamiento.RequiereSeguro;
            
            if (financiamiento.PlazoMeses > 0 && financiamiento.TasaAnual > 0)
            {
                venta.Mensualidad = _calculadora.CalcularMensualidad(
                    financiamiento.MontoFinanciado,
                    financiamiento.PlazoMeses,
                    financiamiento.TasaAnual);
            }
        }

        return venta;
    }

    public void Cancelar(Venta venta)
    {
        if (!PuedeCancelar(venta))
            throw new InvalidOperationException("La venta no puede ser cancelada");

        venta.Estatus = EstatusVenta.Cancelada;
    }

    public bool PuedeCancelar(Venta venta)
    {
        return venta.Estatus == EstatusVenta.Completada;
    }
}

public class InventarioDominio : IInventarioDominio
{
    private readonly IVentaCalculadora _calculadora;

    public InventarioDominio(IVentaCalculadora calculadora)
    {
        _calculadora = calculadora;
    }

    public bool ValidarStock(Producto producto, int cantidad)
    {
        return producto != null && producto.Stock >= cantidad;
    }

    public List<MovimientoInventario> GenerarMovimientosVenta(Venta venta)
    {
        var movimientos = new List<MovimientoInventario>();

        if (venta.Detalles != null)
        {
            foreach (var detalle in venta.Detalles)
            {
                movimientos.Add(new MovimientoInventario
                {
                    ProductoId = detalle.ProductoId,
                    Tipo = TipoMovimiento.Salida,
                    Cantidad = detalle.Cantidad,
                    Motivo = $"Venta #{venta.Id}",
                    Fecha = DateTime.Now,
                    UsuarioId = venta.UsuarioId
                });
            }
        }

        return movimientos;
    }

    public List<MovimientoInventario> GenerarMovimientosCancelacion(Venta venta)
    {
        var movimientos = new List<MovimientoInventario>();

        if (venta.Detalles != null)
        {
            foreach (var detalle in venta.Detalles)
            {
                movimientos.Add(new MovimientoInventario
                {
                    ProductoId = detalle.ProductoId,
                    Tipo = TipoMovimiento.Entrada,
                    Cantidad = detalle.Cantidad,
                    Motivo = $"Cancelación Venta #{venta.Id}",
                    Fecha = DateTime.Now,
                    UsuarioId = venta.UsuarioId
                });
            }
        }

        return movimientos;
    }
}

public class CuentaPorCobrarDominio : ICuentaPorCobrarDominio
{
    public EstatusCuentaPorCobrar CalcularEstado(decimal total, decimal pagado)
    {
        if (pagado >= total)
            return EstatusCuentaPorCobrar.Liquidada;
        
        if (pagado > 0)
            return EstatusCuentaPorCobrar.Parcial;
        
        return EstatusCuentaPorCobrar.Pendiente;
    }

    public bool RequiereAbono(decimal total, decimal pagado)
    {
        return pagado < total;
    }

    public (decimal nuevoPagado, EstatusCuentaPorCobrar nuevoEstado) ProcesarAbono(
        decimal totalActual, 
        decimal pagadoActual, 
        decimal montoAbono)
    {
        decimal nuevoPagado = pagadoActual + montoAbono;
        
        if (nuevoPagado > totalActual)
            nuevoPagado = totalActual;

        EstatusCuentaPorCobrar nuevoEstado = CalcularEstado(totalActual, nuevoPagado);

        return (nuevoPagado, nuevoEstado);
    }
}