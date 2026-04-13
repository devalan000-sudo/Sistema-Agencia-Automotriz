using System;
using System.Linq;
using System.Windows.Forms;
using SistemaAgenciaAutomotriz.Datos.Servicios;
using SistemaAgenciaAutomotriz.Presentacion.Helpers;
using SistemaAgenciaAutomotriz.Dominio.Interfaces;

namespace SistemaAgenciaAutomotriz.Presentacion.Formularios;

public partial class FormReportes : Form
{
    private readonly IVentaServicio _ventaServicio;
    private readonly ICuentaPorCobrarServicio _cuentaPorCobrarServicio;
    private readonly IProductoServicio _productoServicio;

    public FormReportes(
        IVentaServicio ventaServicio,
        ICuentaPorCobrarServicio cuentaPorCobrarServicio,
        IProductoServicio productoServicio)
    {
        _ventaServicio = ventaServicio;
        _cuentaPorCobrarServicio = cuentaPorCobrarServicio;
        _productoServicio = productoServicio;
        InitializeComponent();
    }

    private async void BtnGenerar_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime fechaLimite = DateTime.Now;
            string tipoPeriodoStr = "Semanal";
            
            // Determinar dias atras
            if (cmbRangoTiempo.SelectedIndex == 0)
            {
                fechaLimite = DateTime.Now.AddDays(-8);
                tipoPeriodoStr = "últimos 8 días";
            }
            else
            {
                fechaLimite = DateTime.Now.AddDays(-30);
                tipoPeriodoStr = "últimos 30 días";
            }

            using var sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.Title = "Guardar Reporte";
            sfd.FileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                btnGenerar.Enabled = false;
                btnGenerar.Text = "Generando...";

                // Generar de acuerdo al tipo
                switch (cmbTipoReporte.SelectedIndex)
                {
                    case 0: // Ventas Generales
                        var todasVentas = await _ventaServicio.GetAllAsync();
                        var filtradas = todasVentas.Where(x => x.Fecha >= fechaLimite).ToList();
                        GeneradorReportesExcel.GenerarReporteVentas(sfd.FileName, tipoPeriodoStr, filtradas);
                        break;
                    case 1: // Ventas Exclusivas Accesorios (VehiculoId null)
                        var todasVentasAcc = await _ventaServicio.GetAllAsync();
                        var filtradasAcc = todasVentasAcc.Where(x => x.Fecha >= fechaLimite && x.VehiculoId == null).ToList();
                        GeneradorReportesExcel.GenerarReporteVentas(sfd.FileName, tipoPeriodoStr + " (Solo Accesorios)", filtradasAcc);
                        break;
                    case 2: // Cuentas por cobrar
                        var cuentas = await _cuentaPorCobrarServicio.GetAllAsync();
                        // Asumimos que queremos ver cuentas asociadas a ventas recientes o simplemente todas las pendientes.
                        // Filtraremos por ID para simular tiempo, ya que Cuentas no tiene Fecha propia aparente en Dominio, se guian por Venta.
                        // Pero tomaremos solo las activas en general como valor de negocio, o usando LINQ.
                        // Para evitar fallas, pasamos todas las pendientes o las ligadas a ventas recientes
                        var cuentasRecientes = cuentas.ToList(); 
                        GeneradorReportesExcel.GenerarReporteCuentas(sfd.FileName, tipoPeriodoStr, cuentasRecientes);
                        break;
                    case 3: // Inventario
                        var productos = await _productoServicio.GetAllConCategoriaAsync();
                        GeneradorReportesExcel.GenerarReporteInventario(sfd.FileName, "Inventario Físico Actual", productos); // El inventario es la foto actual
                        break;
                }

                MessageBox.Show("¡Reporte generado y guardado exitosamente!", "Reporte Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocurrió un error al generar el reporte:\n\n{ex.Message}", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnGenerar.Enabled = true;
            btnGenerar.Text = "Generar Reporte Excel";
        }
    }
}
