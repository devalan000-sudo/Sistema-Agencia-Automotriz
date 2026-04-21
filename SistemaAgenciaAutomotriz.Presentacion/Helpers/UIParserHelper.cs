using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaAgenciaAutomotriz.Dominio.Entities;

namespace SistemaAgenciaAutomotriz.Presentacion.Helpers;

public static class UIParserHelper
{
    /// <summary>
    /// Intenta parsear la entrada y retorna el valor válido o cero por defecto.
    /// </summary>
    public static decimal ParseDecimal(string input)
    {
        return decimal.TryParse(input?.Trim(), out var result) ? result : 0m;
    }

    /// <summary>
    /// Intenta parsear la entrada y retorna el valor válido o cero por defecto.
    /// </summary>
    public static int ParseInt(string input)
    {
        return int.TryParse(input?.Trim(), out var result) ? result : 0;
    }

    /// <summary>
    /// Intenta parsear la entrada y devuelve un nulo si falla.
    /// </summary>
    public static int? ParseIntNullable(string input)
    {
        if (int.TryParse(input?.Trim(), out var result))
            return result;
        return null;
    }

    /// <summary>
    /// Unifica y encapsula la lógica visual utilizada en diferentes formularios para buscar dinámicamente clientes a medida que se teclea el ID.
    /// </summary>
    public static int? BuscarYMostrarClienteVisualmente(string idText, IEnumerable<Cliente> clientesLista, Label lblNombre, TextBox? txtRFC = null)
    {
        if (int.TryParse(idText?.Trim(), out int id))
        {
            var cliente = clientesLista.FirstOrDefault(x => x.Id == id);
            if (cliente != null)
            {
                lblNombre.Text = $"{cliente.Nombre} (RFC: {cliente.RFC})";
                lblNombre.ForeColor = System.Drawing.Color.Green;
                if (txtRFC != null) txtRFC.Text = cliente.RFC;
                return cliente.Id;
            }
        }
        
        lblNombre.Text = "Cliente no encontrado";
        lblNombre.ForeColor = System.Drawing.Color.Red;
        if (txtRFC != null) txtRFC.Text = "--";
        
        return null;
    }
}
