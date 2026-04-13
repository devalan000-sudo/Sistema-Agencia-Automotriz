using Microsoft.EntityFrameworkCore;
using SistemaAgenciaAutomotriz.Datos.Context;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;

namespace SistemaAgenciaAutomotriz.Datos.Servicios;

public interface IVehiculoServicio
{
    Task<List<Vehiculo>> GetAllAsync();
    Task<List<Vehiculo>> GetDisponiblesAsync();
    Task<List<Vehiculo>> GetByMarcaAsync(string marca);
    Task<List<Vehiculo>> GetByYearAsync(int year);
    Task<List<Vehiculo>> GetByTipoAsync(TipoVehiculo tipo);
    Task<Vehiculo?> GetByIdAsync(int id);
    Task<Vehiculo?> GetByVINAsync(string vin);
    Task<Vehiculo> CreateAsync(Vehiculo vehiculo);
    Task<Vehiculo> UpdateAsync(Vehiculo vehiculo);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateEstadoAsync(int id, EstatusVehiculo estado);
    Task<bool> ExisteVIN(string vin, int? excludeId = null);
}

public class VehiculoServicio : IVehiculoServicio
{
    private readonly ApplicationDbContext _context;

    public VehiculoServicio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vehiculo>> GetAllAsync()
    {
        return await _context.Vehiculos
            .Where(v => v.Activo)
            .OrderBy(v => v.Marca)
            .ThenBy(v => v.Modelo)
            .ToListAsync();
    }

    public async Task<List<Vehiculo>> GetDisponiblesAsync()
    {
        return await _context.Vehiculos
            .Where(v => v.Activo && v.Estatus == (int)EstatusVehiculo.Disponible)
            .OrderBy(v => v.Marca)
            .ThenBy(v => v.Modelo)
            .ToListAsync();
    }

    public async Task<List<Vehiculo>> GetByMarcaAsync(string marca)
    {
        return await _context.Vehiculos
            .Where(v => v.Activo && v.Marca.Contains(marca))
            .OrderBy(v => v.Marca)
            .ThenBy(v => v.Modelo)
            .ToListAsync();
    }

    public async Task<List<Vehiculo>> GetByYearAsync(int year)
    {
        return await _context.Vehiculos
            .Where(v => v.Activo && v.Year == year)
            .OrderBy(v => v.Marca)
            .ThenBy(v => v.Modelo)
            .ToListAsync();
    }

    public async Task<List<Vehiculo>> GetByTipoAsync(TipoVehiculo tipo)
    {
        return await _context.Vehiculos
            .Where(v => v.Activo && v.Tipo == (int)tipo)
            .OrderBy(v => v.Marca)
            .ThenBy(v => v.Modelo)
            .ToListAsync();
    }

    public async Task<Vehiculo?> GetByIdAsync(int id)
    {
        return await _context.Vehiculos.FindAsync(id);
    }

    public async Task<Vehiculo?> GetByVINAsync(string vin)
    {
        return await _context.Vehiculos
            .FirstOrDefaultAsync(v => v.VIN == vin && v.Activo);
    }

    public async Task<Vehiculo> CreateAsync(Vehiculo vehiculo)
    {
        vehiculo.Activo = true;
        vehiculo.Estatus = (int)EstatusVehiculo.Disponible;
        vehiculo.FechaAlta = DateTime.Now;
        _context.Vehiculos.Add(vehiculo);
        await _context.SaveChangesAsync();
        return vehiculo;
    }

    public async Task<Vehiculo> UpdateAsync(Vehiculo vehiculo)
    {
        var existing = await _context.Vehiculos.FindAsync(vehiculo.Id);
        if (existing == null)
            throw new InvalidOperationException("Vehículo no encontrado");

        existing.VIN = vehiculo.VIN;
        existing.Marca = vehiculo.Marca;
        existing.Modelo = vehiculo.Modelo;
        existing.Year = vehiculo.Year;
        existing.Color = vehiculo.Color;
        existing.Kilometraje = vehiculo.Kilometraje;
        existing.Precio = vehiculo.Precio;
        existing.Costo = vehiculo.Costo;
        existing.Tipo = vehiculo.Tipo;
        existing.Descripcion = vehiculo.Descripcion;
        existing.ImagenPath = vehiculo.ImagenPath;
        existing.Motor = vehiculo.Motor;
        existing.Transmision = vehiculo.Transmision;
        existing.Combustible = vehiculo.Combustible;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var vehiculo = await _context.Vehiculos.FindAsync(id);
        if (vehiculo == null) return false;

        vehiculo.Activo = false;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateEstadoAsync(int id, EstatusVehiculo estado)
    {
        var vehiculo = await _context.Vehiculos.FindAsync(id);
        if (vehiculo == null) return false;

        vehiculo.Estatus = (int)estado;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExisteVIN(string vin, int? excludeId = null)
    {
        return await _context.Vehiculos
            .AnyAsync(v => v.VIN == vin && v.Id != excludeId && v.Activo);
    }
}