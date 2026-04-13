using Microsoft.EntityFrameworkCore;
using SistemaAgenciaAutomotriz.Datos.Context;
using SistemaAgenciaAutomotriz.Dominio.Entities;

namespace SistemaAgenciaAutomotriz.Datos.Servicios;

public interface IClienteServicio
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(int id);
    Task<Cliente?> GetByRFCAsync(string rfc);
    Task<Cliente> CreateAsync(Cliente cliente);
    Task<Cliente> UpdateAsync(Cliente cliente);
    Task<bool> DeleteAsync(int id);
    Task<List<Venta>> GetHistorialComprasAsync(int clienteId);
}

public class ClienteServicio : IClienteServicio
{
    private readonly ApplicationDbContext _context;

    public ClienteServicio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .Where(c => c.Activo)
            .OrderBy(c => c.Nombre)
            .ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<Cliente?> GetByRFCAsync(string rfc)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.RFC == rfc && c.Activo);
    }

    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        cliente.FechaAlta = DateTime.Now;
        cliente.Activo = true;
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> UpdateAsync(Cliente cliente)
    {
        var existing = await _context.Clientes.FindAsync(cliente.Id);
        if (existing == null)
            throw new InvalidOperationException("Cliente no encontrado");

        existing.Nombre = cliente.Nombre;
        existing.RFC = cliente.RFC;
        existing.Email = cliente.Email;
        existing.Telefono = cliente.Telefono;
        existing.Direccion = cliente.Direccion;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null) return false;

        cliente.Activo = false;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Venta>> GetHistorialComprasAsync(int clienteId)
    {
        return await _context.Ventas
            .Include(v => v.Usuario)
            .Include(v => v.Detalles)
            .ThenInclude(d => d.Producto)
            .Where(v => v.ClienteId == clienteId)
            .OrderByDescending(v => v.Fecha)
            .ToListAsync();
    }
}