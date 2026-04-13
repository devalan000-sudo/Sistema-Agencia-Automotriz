using Microsoft.EntityFrameworkCore;
using SistemaAgenciaAutomotriz.Datos.Context;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;

namespace SistemaAgenciaAutomotriz.Datos.Servicios;

public interface IVentaServicio
{
    Task<Venta> CrearVentaAsync(Venta venta, List<VentaDetalle> detalles);
    Task<List<Venta>> GetAllAsync();
    Task<List<Venta>> GetAllConVehiculoAsync();
    Task<List<Venta>> GetVentasConVehiculoAsync();
    Task<List<Venta>> GetByFechaAsync(DateTime fecha);
    Task<Venta?> GetByIdAsync(int id);
    Task<bool> CancelarVentaAsync(int id);
}

public class VentaServicio : IVentaServicio
{
    private readonly ApplicationDbContext _context;

    public VentaServicio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Venta> CrearVentaAsync(Venta venta, List<VentaDetalle> detalles)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            venta.Fecha = DateTime.Now;
            venta.Estatus = EstatusVenta.Completada;
            
            if (venta.VehiculoId.HasValue)
            {
                var vehiculo = await _context.Vehiculos.FindAsync(venta.VehiculoId);
                if (vehiculo != null)
                {
                    vehiculo.Estatus = (int)EstatusVehiculo.Vendido;
                }
            }

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            // Crear CuentaPorCobrar si es financiamiento
            if (venta.TipoPagoVEH == TipoPago.Financiamiento && venta.MontoFinanciado > 0)
            {
                var cuentaPorCobrar = new CuentaPorCobrar
                {
                    VentaId = venta.Id,
                    ClienteId = venta.ClienteId ?? 1,
                    Total = venta.MontoFinanciado,
                    Pagado = 0,
                    FechaVencimiento = DateTime.Now.AddMonths(venta.PlazoMeses),
                    Estatus = EstatusCuentaPorCobrar.Pendiente,
                    FechaCreacion = DateTime.Now
                };
                _context.CuentasPorCobrar.Add(cuentaPorCobrar);
                await _context.SaveChangesAsync();
            }

            foreach (var detalle in detalles)
            {
                detalle.VentaId = venta.Id;
                _context.VentaDetalles.Add(detalle);

                var producto = await _context.Productos.FindAsync(detalle.ProductoId);
                if (producto != null)
                {
                    producto.Stock -= detalle.Cantidad;

                    var movimiento = new MovimientoInventario
                    {
                        ProductoId = producto.Id,
                        Tipo = TipoMovimiento.Salida,
                        Cantidad = detalle.Cantidad,
                        Motivo = $"Venta #{venta.Id}",
                        UsuarioId = venta.UsuarioId,
                        Fecha = DateTime.Now
                    };
                    _context.MovimientosInventario.Add(movimiento);
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return venta;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<List<Venta>> GetAllAsync()
    {
        return await _context.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Usuario)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }

    public async Task<List<Venta>> GetAllConVehiculoAsync()
    {
        return await _context.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Usuario)
            .Include(v => v.Vehiculo)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }

    public async Task<List<Venta>> GetVentasConVehiculoAsync()
    {
        return await _context.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Usuario)
            .Include(v => v.Vehiculo)
            .Where(v => v.VehiculoId != null)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }

    public async Task<List<Venta>> GetByFechaAsync(DateTime fecha)
    {
        return await _context.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Usuario)
            .Where(v => v.Fecha.Date == fecha.Date)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }

    public async Task<Venta?> GetByIdAsync(int id)
    {
        return await _context.Ventas
            .Include(v => v.Cliente)
            .Include(v => v.Usuario)
            .Include(v => v.Detalles)
            .ThenInclude(d => d.Producto)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<bool> CancelarVentaAsync(int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var venta = await _context.Ventas
                .Include(v => v.Detalles)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venta == null || venta.Estatus == EstatusVenta.Cancelada)
                return false;

            foreach (var detalle in venta.Detalles)
            {
                var producto = await _context.Productos.FindAsync(detalle.ProductoId);
                if (producto != null)
                {
                    producto.Stock += detalle.Cantidad;

                    var movimiento = new MovimientoInventario
                    {
                        ProductoId = producto.Id,
                        Tipo = TipoMovimiento.Entrada,
                        Cantidad = detalle.Cantidad,
                        Motivo = $"Cancelación Venta #{venta.Id}",
                        UsuarioId = venta.UsuarioId,
                        Fecha = DateTime.Now
                    };
                    _context.MovimientosInventario.Add(movimiento);
                }
            }

            venta.Estatus = EstatusVenta.Cancelada;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
}