using Microsoft.EntityFrameworkCore;
using SistemaAgenciaAutomotriz.Datos.Context;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;

namespace SistemaAgenciaAutomotriz.Datos.Servicios;

public interface IUsuarioServicio
{
    Task<List<Usuario>> GetAllAsync();
    Task<Usuario?> GetByIdAsync(int id);
    Task<Usuario> CreateAsync(Usuario usuario);
    Task<Usuario> UpdateAsync(Usuario usuario);
    Task<bool> DeleteAsync(int id);
    Task<bool> ExisteUsername(string username, int? excludeId = null);
}

public class UsuarioServicio : IUsuarioServicio
{
    private readonly ApplicationDbContext _context;

    public UsuarioServicio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios
            .Where(u => u.Activo)
            .OrderBy(u => u.Nombre)
            .ToListAsync();
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario> CreateAsync(Usuario usuario)
    {
        usuario.FechaAlta = DateTime.Now;
        usuario.Activo = true;
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> UpdateAsync(Usuario usuario)
    {
        var existing = await _context.Usuarios.FindAsync(usuario.Id);
        if (existing == null)
            throw new InvalidOperationException("Usuario no encontrado");

        existing.Nombre = usuario.Nombre;
        existing.Username = usuario.Username;
        existing.Rol = usuario.Rol;
        if (!string.IsNullOrEmpty(usuario.PasswordHash))
            existing.PasswordHash = usuario.PasswordHash;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null) return false;

        usuario.Activo = false;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExisteUsername(string username, int? excludeId = null)
    {
        return await _context.Usuarios
            .AnyAsync(u => u.Username == username && u.Id != excludeId && u.Activo);
    }
}