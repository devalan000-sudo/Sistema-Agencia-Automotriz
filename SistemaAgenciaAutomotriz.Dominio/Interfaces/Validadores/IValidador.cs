namespace SistemaAgenciaAutomotriz.Dominio.Interfaces;

public interface IValidador<T> where T : class
{
    ResultadoValidacion Validar(T entidad);
}

public class ResultadoValidacion
{
    public bool EsValido { get; set; }
    public List<string> Errores { get; set; } = new();
    public Dictionary<string, string> ErroresPorCampo { get; set; } = new();

    public static ResultadoValidacion Exitoso() => new() { EsValido = true };
    public static ResultadoValidacion Fallido(List<string> errores)
    {
        var resultado = new ResultadoValidacion { EsValido = false, Errores = errores };
        foreach (var error in errores)
        {
            var partes = error.Split(':');
            if (partes.Length == 2)
            {
                resultado.ErroresPorCampo[partes[0].Trim()] = partes[1].Trim();
            }
        }
        return resultado;
    }
}