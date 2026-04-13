using System.Text.RegularExpressions;
using SistemaAgenciaAutomotriz.Dominio.Entities;
using SistemaAgenciaAutomotriz.Dominio.Interfaces;

namespace SistemaAgenciaAutomotriz.Dominio.Validators;

public class VehiculoValidador : IValidador<Vehiculo>
{
    private static readonly Regex RegexVIN = new(@"^[A-HJ-NPR-Z0-9]{17}$", RegexOptions.Compiled);

    public ResultadoValidacion Validar(Vehiculo entidad)
    {
        var errores = new List<string>();

        if (string.IsNullOrWhiteSpace(entidad.VIN))
        {
            errores.Add("VIN: El VIN es requerido");
        }
        else if (entidad.VIN.Length != 17)
        {
            errores.Add("VIN: El VIN debe tener exactamente 17 caracteres");
        }
        else if (!RegexVIN.IsMatch(entidad.VIN))
        {
            errores.Add("VIN: Formato de VIN inválido (solo letras A-Z excepto I,O,Q y números)");
        }

        int anioMinimo = DateTime.Now.Year - 20;
        int anioMaximo = DateTime.Now.Year + 5;

        if (entidad.Year < anioMinimo)
            errores.Add($"Year: El año no puede ser menor a {anioMinimo}");

        if (entidad.Year > anioMaximo)
            errores.Add($"Year: El año no puede ser mayor a {anioMaximo}");

        if (entidad.Precio < 0)
            errores.Add("Precio: El precio no puede ser negativo");

        if (entidad.Costo < 0)
            errores.Add("Costo: El costo no puede ser negativo");

        if (entidad.Kilometraje < 0)
            errores.Add("Kilometraje: El kilometraje no puede ser negativo");

        if (entidad.Tipo < 1 || entidad.Tipo > 3)
            errores.Add("Tipo: El tipo de vehículo debe ser 1=Nuevo, 2=Seminuevo, o 3=Usado");

        if (entidad.Estatus < 1 || entidad.Estatus > 3)
            errores.Add("Estatus: El estatus debe ser 1=Disponible, 2=Reservado, o 3=Vendido");

        return errores.Count == 0 
            ? ResultadoValidacion.Exitoso() 
            : ResultadoValidacion.Fallido(errores);
    }
}