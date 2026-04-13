using System.Drawing;
using System.Windows.Forms;

namespace SistemaAgenciaAutomotriz.Presentacion.Helpers;

public class CustomMenuRenderer : ToolStripProfessionalRenderer
{
    public CustomMenuRenderer() : base(new CustomColorTable())
    {
    }
}

public class CustomColorTable : ProfessionalColorTable
{
    private Color MenuBackgroundColor = Color.FromArgb(30, 30, 30);      // Fondo oscuro negro del menu raiz
    private Color DropdownBackgroundColor = Color.FromArgb(40, 40, 40);  // Fondo negro para los dropdowns
    private Color SelectionColor = Color.FromArgb(0, 120, 215);        // Azul Windows de selección
    private Color BorderColor = Color.FromArgb(50, 50, 50);            // Borde muy sutil o casi invisible

    public override Color ToolStripDropDownBackground => DropdownBackgroundColor;
    
    public override Color MenuBorder => BorderColor;
    
    public override Color MenuItemBorder => SelectionColor;

    public override Color MenuItemSelected => SelectionColor;

    public override Color MenuItemSelectedGradientBegin => SelectionColor;
    public override Color MenuItemSelectedGradientEnd => SelectionColor;

    public override Color MenuItemPressedGradientBegin => SelectionColor;
    public override Color MenuItemPressedGradientMiddle => SelectionColor;
    public override Color MenuItemPressedGradientEnd => SelectionColor;
    
    // Para el estado seleccionado pero cuando es menú padre (como "Vehículos" antes de expandir el dropdown)
    public override Color ImageMarginGradientBegin => DropdownBackgroundColor;
    public override Color ImageMarginGradientMiddle => DropdownBackgroundColor;
    public override Color ImageMarginGradientEnd => DropdownBackgroundColor;
}
