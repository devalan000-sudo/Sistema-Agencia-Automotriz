using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;

namespace SistemaAgenciaAutomotriz.Presentacion.Helpers;

public static class SesionActual
{
    public static Usuario? UsuarioLogueado { get; set; }

    public static bool EstaLogueado => UsuarioLogueado != null;

    public static string NombreUsuario => UsuarioLogueado?.Nombre ?? "Invitado";

    public static RolUsuario Rol => UsuarioLogueado?.Rol ?? RolUsuario.Cajero;

    public static bool EsAdmin => Rol == RolUsuario.Admin;

    public static bool EsSupervisor => Rol == RolUsuario.Supervisor;

    public static bool EsCajero => Rol == RolUsuario.Cajero;

    public static bool EsAdminOSupervisor => EsAdmin || EsSupervisor;

    public static bool PuedeCrear => EsAdminOSupervisor;

    public static bool PuedeEditar => EsAdminOSupervisor;

    public static bool PuedeEliminar => EsAdminOSupervisor;

    public static bool PuedeCrearUsuario => EsAdmin;

    public static bool PuedeGestionarClientes => EsAdminOSupervisor || EsCajero;

    public static bool PuedeGestionarVentas => EsAdminOSupervisor || EsCajero;

    public static void CerrarSesion()
    {
        UsuarioLogueado = null;
    }
}