using Microsoft.EntityFrameworkCore;
using SistemaAgenciaAutomotriz.Datos.Context;
using SistemaAgenciaAutomotriz.Dominio.Entities;

namespace SistemaAgenciaAutomotriz.Datos.Servicios;

public interface ICategoriaServicio
{
    Task<List<Categoria>> GetAllAsync();
    Task<Categoria?> GetByIdAsync(int id);
    Task<Categoria> CreateAsync(Categoria categoria);
    Task<Categoria> UpdateAsync(Categoria categoria);
    Task<bool> DeleteAsync(int id);
}

public class CategoriaServicio : ICategoriaServicio
{
    private readonly ApplicationDbContext _context;

    public CategoriaServicio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> GetAllAsync()
    {
        return await _context.Categorias
            .Where(c => c.Activo)
            .OrderBy(c => c.Nombre)
            .ToListAsync();
    }

    public async Task<Categoria?> GetByIdAsync(int id)
    {
        return await _context.Categorias.FindAsync(id);
    }

    public async Task<Categoria> CreateAsync(Categoria categoria)
    {
        categoria.Activo = true;
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> UpdateAsync(Categoria categoria)
    {
        var existing = await _context.Categorias.FindAsync(categoria.Id);
        if (existing == null)
            throw new InvalidOperationException("Categoría no encontrada");

        existing.Nombre = categoria.Nombre;
        existing.Descripcion = categoria.Descripcion;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null) return false;

        var tieneProductos = await _context.Productos.AnyAsync(p => p.CategoriaId == id && p.Activo);
        if (tieneProductos)
        {
            throw new InvalidOperationException("No se puede eliminar la categoría porque tiene productos asociados");
        }

        categoria.Activo = false;
        await _context.SaveChangesAsync();
        return true;
    }
}