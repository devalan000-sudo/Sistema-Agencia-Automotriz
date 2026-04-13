using Microsoft.EntityFrameworkCore;
using SistemaAgenciaAutomotriz.Datos.Context;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;

namespace SistemaAgenciaAutomotriz.Datos.Servicios;

public interface IProductoServicio
{
    Task<List<Producto>> GetAllAsync();
    Task<List<Producto>> GetAllConCategoriaAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task<Producto?> GetByCodigoAsync(string codigo);
    Task<Producto> CreateAsync(Producto producto);
    Task<Producto> UpdateAsync(Producto producto);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExisteCodigo(string codigo, int? excludeId = null);
    Task<List<Producto>> GetConStockMinimoAsync();
    Task<bool> DescontarStockAsync(int productoId, int cantidad);
    Task<bool> AumentarStockAsync(int productoId, int cantidad);
}

public class ProductoServicio : IProductoServicio
{
    private readonly ApplicationDbContext _context;

    public ProductoServicio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Producto>> GetAllAsync()
    {
        return await _context.Productos
            .Where(p => p.Activo)
            .OrderBy(p => p.Nombre)
            .ToListAsync();
    }

    public async Task<List<Producto>> GetAllConCategoriaAsync()
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .Where(p => p.Activo)
            .OrderBy(p => p.Nombre)
            .ToListAsync();
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Producto?> GetByCodigoAsync(string codigo)
    {
        return await _context.Productos
            .FirstOrDefaultAsync(p => p.Codigo == codigo && p.Activo);
    }

    public async Task<Producto> CreateAsync(Producto producto)
    {
        producto.Activo = true;
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<Producto> UpdateAsync(Producto producto)
    {
        var existing = await _context.Productos.FindAsync(producto.Id);
        if (existing == null)
            throw new InvalidOperationException("Producto no encontrado");

        existing.Codigo = producto.Codigo;
        existing.Nombre = producto.Nombre;
        existing.Descripcion = producto.Descripcion;
        existing.Precio = producto.Precio;
        existing.Costo = producto.Costo;
        existing.Stock = producto.Stock;
        existing.StockMinimo = producto.StockMinimo;
        existing.CategoriaId = producto.CategoriaId;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return false;

        producto.Activo = false;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExisteCodigo(string codigo, int? excludeId = null)
    {
        return await _context.Productos
            .AnyAsync(p => p.Codigo == codigo && p.Id != excludeId && p.Activo);
    }

    public async Task<List<Producto>> GetConStockMinimoAsync()
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .Where(p => p.Activo && p.Stock <= p.StockMinimo)
            .OrderBy(p => p.Stock)
            .ToListAsync();
    }

    public async Task<bool> DescontarStockAsync(int productoId, int cantidad)
    {
        var producto = await _context.Productos.FindAsync(productoId);
        if (producto == null || producto.Stock < cantidad)
            return false;

        producto.Stock -= cantidad;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AumentarStockAsync(int productoId, int cantidad)
    {
        var producto = await _context.Productos.FindAsync(productoId);
        if (producto == null)
            return false;

        producto.Stock += cantidad;
        await _context.SaveChangesAsync();
        return true;
    }
}