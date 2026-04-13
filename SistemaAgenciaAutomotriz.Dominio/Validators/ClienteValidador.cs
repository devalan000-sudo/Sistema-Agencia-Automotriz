using System.Text.RegularExpressions;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Interfaces;

namespace SistemaAgenciaAutomotriz.Dominio.Validators;

public class ClienteValidador : IValidador<Cliente>
{
    private static readonly Regex RegexRFC = new(@"^[A-Z&Ñ]{3,4}[0-9]{6}[A-Z0-9]{2,3}$", RegexOptions.Compiled);
    private static readonly Regex RegexTelefono = new(@"^[\d\s\-\+\(\)]+$", RegexOptions.Compiled);
    private static readonly Regex RegexEmail = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public ResultadoValidacion Validar(Cliente entidad)
    {
        var errores = new List<string>();

        if (!string.IsNullOrWhiteSpace(entidad.RFC) && entidad.RFC.Length < 10)
            errores.Add("RFC: El RFC debe tener al menos 10 caracteres");
        
        if (!string.IsNullOrWhiteSpace(entidad.RFC) && entidad.RFC.Length > 13)
            errores.Add("RFC: El RFC no puede exceder 13 caracteres");

        if (!string.IsNullOrWhiteSpace(entidad.RFC) && !RegexRFC.IsMatch(entidad.RFC))
            errores.Add("RFC: Formato de RFC inválido (ej: ABCD123456ABC)");

        if (!string.IsNullOrWhiteSpace(entidad.Telefono) && !RegexTelefono.IsMatch(entidad.Telefono))
            errores.Add("Telefono: Formato de teléfono inválido");

        if (!string.IsNullOrWhiteSpace(entidad.TelefonoEmergencia) && !RegexTelefono.IsMatch(entidad.TelefonoEmergencia))
            errores.Add("TelefonoEmergencia: Formato de teléfono inválido");

        if (!string.IsNullOrWhiteSpace(entidad.Email) && !RegexEmail.IsMatch(entidad.Email))
            errores.Add("Email: Formato de email inválido");

        if (!string.IsNullOrWhiteSpace(entidad.Nombre) && entidad.Nombre.Length > 100)
            errores.Add("Nombre: El nombre no puede exceder 100 caracteres");

        return errores.Count == 0 
            ? ResultadoValidacion.Exitoso() 
            : ResultadoValidacion.Fallido(errores);
    }
}