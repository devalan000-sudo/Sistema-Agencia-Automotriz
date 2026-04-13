using Microsoft.EntityFrameworkCore;
using SistemaAgenciaAutomotriz.Datos.Context;
using SistemaAgenciaAutomotriz.Dominio.Entities;

namespace SistemaAgenciaAutomotriz.Datos.Servicios;

public interface IAuthServicio
{
    Task<Usuario?> ValidarLoginAsync(string username, string password);
}

public class AuthServicio : IAuthServicio
{
    private readonly ApplicationDbContext _context;

    public AuthServicio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ValidarLoginAsync(string username, string password)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Username == username && u.Activo);

        if (usuario == null)
            return null;

        if (VerificarPassword(password, usuario.PasswordHash))
            return usuario;

        return null;
    }

    private bool VerificarPassword(string password, string passwordHash)
    {
        return password == passwordHash;
    }
}