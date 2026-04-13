using SistemaAgenciaAutomotriz.Dominio.Interfaces;

namespace SistemaAgenciaAutomotriz.Dominio.Services;

public class ValidadorService : IValidadorService
{
    private readonly IEnumerable<IValidador<object>> _validadores;

    public ValidadorService(IEnumerable<IValidador<object>> validadores)
    {
        _validadores = validadores;
    }

    public ResultadoValidacion Validar<T>(T entidad) where T : class
    {
        var validador = _validadores
            .FirstOrDefault(v => v.GetType().GenericTypeArguments[0] == typeof(T));

        if (validador == null)
            return ResultadoValidacion.Exitoso();

        var metodoValidar = validador.GetType().GetMethod("Validar");
        return (ResultadoValidacion)metodoValidar!.Invoke(validador, new[] { entidad })!;
    }
}

public interface IValidadorService
{
    ResultadoValidacion Validar<T>(T entidad) where T : class;
}