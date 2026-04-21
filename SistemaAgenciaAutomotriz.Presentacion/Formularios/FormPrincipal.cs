using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;
using SistemaAgenciaAutomotriz.Dominio.Enumeradores;
using SistemaAgenciaAutomotriz.Dominio.Services;
using SistemaAgenciaAutomotriz.Dominio.Interfaces;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormPrincipal : Form
{
    private readonly IUsuarioServicio _usuarioServicio;
    private readonly ICategoriaServicio _categoriaServicio;
    private readonly IProductoServicio _productoServicio;
    private readonly IVehiculoServicio _vehiculoServicio;
    private readonly IVentaServicio _ventaServicio;
    private readonly IClienteServicio _clienteServicio;
    private readonly ICuentaPorCobrarServicio _cuentaPorCobrarServicio;
    private readonly IValidadorService _validadorService;
    private readonly IVentaCalculadora _ventaCalculadora;
    private Form? _formActivo;

    public FormPrincipal(
        IUsuarioServicio usuarioServicio, 
        ICategoriaServicio categoriaServicio,
        IProductoServicio productoServicio,
        IVehiculoServicio vehiculoServicio,
        IVentaServicio ventaServicio,
        IClienteServicio clienteServicio,
        ICuentaPorCobrarServicio cuentaPorCobrarServicio,
        IValidadorService validadorService,
        IVentaCalculadora ventaCalculadora)
    {
        InitializeComponent();
        this.menuStrip1.Renderer = new CustomMenuRenderer();
        _usuarioServicio = usuarioServicio;
        _categoriaServicio = categoriaServicio;
        _productoServicio = productoServicio;
        _vehiculoServicio = vehiculoServicio;
        _ventaServicio = ventaServicio;
        _clienteServicio = clienteServicio;
        _cuentaPorCobrarServicio = cuentaPorCobrarServicio;
        _validadorService = validadorService;
        _ventaCalculadora = ventaCalculadora;
        this.IsMdiContainer = true;
        // Mantener tamaño adaptable (quitar bloqueo de maximizar) para MVP y pruebas
        // No fijamos tamaño mínimo ni máximo; permitir maximizar
        ConfigurarPermisos();
        ActualizarInfoUsuario();
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {
    }

    private void ConfigurarPermisos()
    {
        bool esAdmin = SesionActual.EsAdmin;
        bool esSupervisor = SesionActual.EsSupervisor;
        bool esCajero = SesionActual.EsCajero;

        bool puedeVerUsuarios = esAdmin || esSupervisor;

        usuariosToolStripMenuItem.Visible = puedeVerUsuarios;
    }

    private void ActualizarInfoUsuario()
    {
        lblUsuario.Text = $"Usuario: {SesionActual.NombreUsuario} ({SesionActual.Rol})";
        lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
    }

    private void CerrarFormActivo()
    {
        if (_formActivo != null && !_formActivo.IsDisposed)
        {
            _formActivo.Close();
            _formActivo = null;
        }
    }

    private void MostrarFormActivo()
    {
        if (_formActivo == null) return;
        _formActivo.MdiParent = this;
        // Hacer que la ventana hija luzca y se comporte como un panel fijo integrado:
        _formActivo.ControlBox = false; 
        _formActivo.FormBorderStyle = FormBorderStyle.None; 
        _formActivo.Dock = DockStyle.Fill; 
        _formActivo.Show();
    }

    private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormVenta(_vehiculoServicio, _ventaServicio, _ventaCalculadora, _clienteServicio);
        MostrarFormActivo();
    }

    private void ventaAccesoriosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormVentaAccesorios(_productoServicio, _ventaServicio, _ventaCalculadora, _clienteServicio);
        MostrarFormActivo();
    }

    private void historialVentasToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormVentaList(_ventaServicio);
        MostrarFormActivo();
    }

    private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormClienteList(_clienteServicio, _validadorService);
        MostrarFormActivo();
    }

    private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormProductoList(_productoServicio, _categoriaServicio);
        MostrarFormActivo();
    }

    private void vehículosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormVehiculoList(_vehiculoServicio, _validadorService);
        MostrarFormActivo();
    }

    private void historialVehiculosVendidosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormVehiculoVendidoList(_ventaServicio);
        MostrarFormActivo();
    }

    private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormCategoriaList(_categoriaServicio);
        MostrarFormActivo();
    }

    private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormReportes(_ventaServicio, _cuentaPorCobrarServicio, _productoServicio);
        MostrarFormActivo();
    }

    private void cuentasPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormCuentaPorCobrarList(_cuentaPorCobrarServicio, _clienteServicio);
        MostrarFormActivo();
    }

    private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CerrarFormActivo();
        _formActivo = new FormUsuarioList(_usuarioServicio);
        MostrarFormActivo();
    }


    private void salirToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("¿Salir del sistema?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            SesionActual.CerrarSesion();
            Application.Exit();
        }
    }
}
