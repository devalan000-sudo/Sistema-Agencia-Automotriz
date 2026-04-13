using Microsoft.EntityFrameworkCore;
using SistemaAgenciaAutomotriz.Datos.Context;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;

namespace SistemaAgenciaAutomotriz.Datos.Servicios;

public interface ICuentaPorCobrarServicio
{
    Task<List<CuentaPorCobrar>> GetAllAsync();
    Task<List<CuentaPorCobrar>> GetActivasAsync();
    Task<CuentaPorCobrar?> GetByIdAsync(int id);
    Task<CuentaPorCobrar> CrearAsync(CuentaPorCobrar cuenta);
    Task<CuentaPorCobrar> ActualizarAsync(CuentaPorCobrar cuenta);
    Task<Abono> RegistrarAbonoAsync(Abono abono);
    Task<List<Abono>> GetAbonosAsync(int cuentaId);
    Task<List<CuentaPorCobrar>> GetVencidasAsync();
    Task<decimal> GetTotalPendienteAsync();
}

public class CuentaPorCobrarServicio : ICuentaPorCobrarServicio
{
    private readonly ApplicationDbContext _context;

    public CuentaPorCobrarServicio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CuentaPorCobrar>> GetAllAsync()
    {
        return await _context.CuentasPorCobrar
            .Include(c => c.Cliente)
            .Include(c => c.Venta)
            .OrderByDescending(c => c.FechaCreacion)
            .ToListAsync();
    }

    public async Task<List<CuentaPorCobrar>> GetActivasAsync()
    {
        return await _context.CuentasPorCobrar
            .Include(c => c.Cliente)
            .Include(c => c.Venta)
            .Where(c => c.Estatus != EstatusCuentaPorCobrar.Liquidada)
            .OrderByDescending(c => c.FechaCreacion)
            .ToListAsync();
    }

    public async Task<CuentaPorCobrar?> GetByIdAsync(int id)
    {
        return await _context.CuentasPorCobrar
            .Include(c => c.Cliente)
            .Include(c => c.Venta)
            .Include(c => c.Abonos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<CuentaPorCobrar> CrearAsync(CuentaPorCobrar cuenta)
    {
        cuenta.FechaCreacion = DateTime.Now;
        cuenta.Pagado = 0;
        cuenta.Estatus = EstatusCuentaPorCobrar.Pendiente;
        _context.CuentasPorCobrar.Add(cuenta);
        await _context.SaveChangesAsync();
        return cuenta;
    }

    public async Task<CuentaPorCobrar> ActualizarAsync(CuentaPorCobrar cuenta)
    {
        var existing = await _context.CuentasPorCobrar.FindAsync(cuenta.Id);
        if (existing == null)
            throw new InvalidOperationException("Cuenta no encontrada");

        existing.FechaVencimiento = cuenta.FechaVencimiento;
        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<Abono> RegistrarAbonoAsync(Abono abono)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            abono.Fecha = DateTime.Now;
            _context.Abonos.Add(abono);

            var cuenta = await _context.CuentasPorCobrar.FindAsync(abono.CuentaPorCobrarId);
            if (cuenta == null)
                throw new InvalidOperationException("Cuenta no encontrada");

            cuenta.Pagado += abono.Monto;

            if (cuenta.Pagado >= cuenta.Total)
            {
                cuenta.Estatus = EstatusCuentaPorCobrar.Liquidada;
                cuenta.Pagado = cuenta.Total;
            }
            else if (cuenta.Pagado > 0)
            {
                cuenta.Estatus = EstatusCuentaPorCobrar.Parcial;
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return abono;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<List<Abono>> GetAbonosAsync(int cuentaId)
    {
        return await _context.Abonos
            .Include(a => a.Usuario)
            .Where(a => a.CuentaPorCobrarId == cuentaId)
            .OrderByDescending(a => a.Fecha)
            .ToListAsync();
    }

    public async Task<List<CuentaPorCobrar>> GetVencidasAsync()
    {
        return await _context.CuentasPorCobrar
            .Include(c => c.Cliente)
            .Where(c => c.Estatus != EstatusCuentaPorCobrar.Liquidada && c.FechaVencimiento < DateTime.Now)
            .ToListAsync();
    }

    public async Task<decimal> GetTotalPendienteAsync()
    {
        return await _context.CuentasPorCobrar
            .Where(c => c.Estatus != EstatusCuentaPorCobrar.Liquidada)
            .SumAsync(c => c.Total - c.Pagado);
    }
}