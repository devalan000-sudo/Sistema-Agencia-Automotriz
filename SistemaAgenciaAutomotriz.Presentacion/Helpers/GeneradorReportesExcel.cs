using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using SistemaAgenciaAutomotriz.Dominio.Entities;

namespace SistemaAgenciaAutomotriz.Presentacion.Helpers;

public static class GeneradorReportesExcel
{
    public static void GenerarReporteVentas(string rutaSalida, string tipoPeriodo, List<Venta> ventas)
    {
        using var workbook = new XLWorkbook();
        
        // Hoja 1: Resumen General
        var wsResumen = workbook.Worksheets.Add("Resumen General");
        wsResumen.Cell(1, 1).Value = "Reporte de Ventas - " + tipoPeriodo;
        wsResumen.Cell(1, 1).Style.Font.Bold = true;
        wsResumen.Cell(1, 1).Style.Font.FontSize = 14;

        wsResumen.Cell(3, 1).Value = "ID Venta";
        wsResumen.Cell(3, 2).Value = "Fecha";
        wsResumen.Cell(3, 3).Value = "Cliente";
        wsResumen.Cell(3, 4).Value = "Vehículo Asignado";
        wsResumen.Cell(3, 5).Value = "Método de Pago";
        wsResumen.Cell(3, 6).Value = "Total";
        wsResumen.Range(3, 1, 3, 6).Style.Font.Bold = true;
        wsResumen.Range(3, 1, 3, 6).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
        wsResumen.Range(3, 1, 3, 6).Style.Font.FontColor = XLColor.White;

        int row = 4;
        decimal sumaTotal = 0;
        foreach (var v in ventas)
        {
            wsResumen.Cell(row, 1).Value = v.Id;
            wsResumen.Cell(row, 2).Value = v.Fecha.ToString("dd/MM/yyyy HH:mm");
            wsResumen.Cell(row, 3).Value = v.Cliente?.Nombre ?? "Genérico";
            wsResumen.Cell(row, 4).Value = v.Vehiculo != null ? $"{v.Vehiculo.Marca} {v.Vehiculo.Modelo}" : "Sólo Accesorios";
            wsResumen.Cell(row, 5).Value = v.MetodoPago.ToString();
            wsResumen.Cell(row, 6).Value = v.Total;
            wsResumen.Cell(row, 6).Style.NumberFormat.Format = "$ #,##0.00";
            sumaTotal += v.Total;
            row++;
        }
        
        wsResumen.Cell(row + 1, 5).Value = "GRAND TOTAL:";
        wsResumen.Cell(row + 1, 5).Style.Font.Bold = true;
        wsResumen.Cell(row + 1, 6).Value = sumaTotal;
        wsResumen.Cell(row + 1, 6).Style.Font.Bold = true;
        wsResumen.Cell(row + 1, 6).Style.NumberFormat.Format = "$ #,##0.00";
        wsResumen.Columns().AdjustToContents();

        // Hoja 2: Detalles (Producto por Producto)
        var wsDetalle = workbook.Worksheets.Add("Desglose Accesorios");
        wsDetalle.Cell(1, 1).Value = "Desglose por Artículo/Accesorio - " + tipoPeriodo;
        wsDetalle.Cell(1, 1).Style.Font.Bold = true;
        wsDetalle.Cell(1, 1).Style.Font.FontSize = 14;

        wsDetalle.Cell(3, 1).Value = "ID Venta";
        wsDetalle.Cell(3, 2).Value = "Fecha";
        wsDetalle.Cell(3, 3).Value = "Producto / Accesorio";
        wsDetalle.Cell(3, 4).Value = "Cantidad";
        wsDetalle.Cell(3, 5).Value = "Precio Unitario";
        wsDetalle.Cell(3, 6).Value = "Importe";
        wsDetalle.Range("A3:F3").Style.Font.Bold = true;
        wsDetalle.Range("A3:F3").Style.Fill.BackgroundColor = XLColor.AirForceBlue;
        wsDetalle.Range("A3:F3").Style.Font.FontColor = XLColor.White;

        int rowD = 4;
        foreach (var v in ventas)
        {
            if (v.Detalles != null && v.Detalles.Any())
            {
                foreach (var d in v.Detalles)
                {
                    wsDetalle.Cell(rowD, 1).Value = v.Id;
                    wsDetalle.Cell(rowD, 2).Value = v.Fecha.ToString("dd/MM/yyyy HH:mm");
                    wsDetalle.Cell(rowD, 3).Value = d.Producto?.Nombre ?? "Desconocido";
                    wsDetalle.Cell(rowD, 4).Value = d.Cantidad;
                    wsDetalle.Cell(rowD, 5).Value = d.PrecioUnitario;
                    wsDetalle.Cell(rowD, 5).Style.NumberFormat.Format = "$ #,##0.00";
                    wsDetalle.Cell(rowD, 6).Value = d.Importe;
                    wsDetalle.Cell(rowD, 6).Style.NumberFormat.Format = "$ #,##0.00";
                    rowD++;
                }
            }
        }
        wsDetalle.Columns().AdjustToContents();

        workbook.SaveAs(rutaSalida);
    }

    public static void GenerarReporteCuentas(string rutaSalida, string tipoPeriodo, List<CuentaPorCobrar> cuentas)
    {
        using var workbook = new XLWorkbook();
        var ws = workbook.Worksheets.Add("Cuentas por Cobrar");
        ws.Cell(1, 1).Value = "Reporte de Cuentas por Cobrar - " + tipoPeriodo;
        ws.Cell(1, 1).Style.Font.Bold = true;
        ws.Cell(1, 1).Style.Font.FontSize = 14;

        ws.Cell(3, 1).Value = "ID";
        ws.Cell(3, 2).Value = "Cliente";
        ws.Cell(3, 3).Value = "Venta Origen";
        ws.Cell(3, 4).Value = "Deuda Total";
        ws.Cell(3, 5).Value = "Abonos Pagados";
        ws.Cell(3, 6).Value = "Saldo Pendiente";
        ws.Cell(3, 7).Value = "Estatus";
        ws.Range("A3:G3").Style.Font.Bold = true;
        ws.Range("A3:G3").Style.Fill.BackgroundColor = XLColor.DarkOrange;
        ws.Range("A3:G3").Style.Font.FontColor = XLColor.White;

        int row = 4;
        foreach (var c in cuentas)
        {
            ws.Cell(row, 1).Value = c.Id;
            ws.Cell(row, 2).Value = c.Cliente?.Nombre ?? "Genérico";
            ws.Cell(row, 3).Value = c.VentaId;
            ws.Cell(row, 4).Value = c.Total;
            ws.Cell(row, 4).Style.NumberFormat.Format = "$ #,##0.00";
            ws.Cell(row, 5).Value = c.Pagado;
            ws.Cell(row, 5).Style.NumberFormat.Format = "$ #,##0.00";
            ws.Cell(row, 6).Value = c.Restante;
            ws.Cell(row, 6).Style.NumberFormat.Format = "$ #,##0.00";
            ws.Cell(row, 7).Value = c.Estatus.ToString();
            row++;
        }
        ws.Columns().AdjustToContents();

        workbook.SaveAs(rutaSalida);
    }

    public static void GenerarReporteInventario(string rutaSalida, string tipoPeriodo, List<Producto> productos)
    {
        using var workbook = new XLWorkbook();
        var ws = workbook.Worksheets.Add("Inventario General");
        ws.Cell(1, 1).Value = "Reporte de Stock e Inventario Físico - " + tipoPeriodo;
        ws.Cell(1, 1).Style.Font.Bold = true;
        ws.Cell(1, 1).Style.Font.FontSize = 14;

        ws.Cell(3, 1).Value = "Código";
        ws.Cell(3, 2).Value = "Nombre / Accesorio";
        ws.Cell(3, 3).Value = "Categoría";
        ws.Cell(3, 4).Value = "Stock Actual";
        ws.Cell(3, 5).Value = "Precio de Lista";
        ws.Cell(3, 6).Value = "Valor Monetario Estimado";
        ws.Range("A3:F3").Style.Font.Bold = true;
        ws.Range("A3:F3").Style.Fill.BackgroundColor = XLColor.ForestGreen;
        ws.Range("A3:F3").Style.Font.FontColor = XLColor.White;

        int row = 4;
        decimal granTotalValor = 0;
        foreach (var p in productos)
        {
            ws.Cell(row, 1).Value = p.Codigo;
            ws.Cell(row, 2).Value = p.Nombre;
            ws.Cell(row, 3).Value = p.Categoria?.Nombre ?? "S/C";
            ws.Cell(row, 4).Value = p.Stock;
            ws.Cell(row, 5).Value = p.Precio;
            ws.Cell(row, 5).Style.NumberFormat.Format = "$ #,##0.00";
            
            decimal valorEstimado = p.Stock * p.Precio;
            ws.Cell(row, 6).Value = valorEstimado;
            ws.Cell(row, 6).Style.NumberFormat.Format = "$ #,##0.00";
            granTotalValor += valorEstimado;
            row++;
        }
        
        ws.Cell(row + 1, 5).Value = "VALOR TOTAL STOCK:";
        ws.Cell(row + 1, 5).Style.Font.Bold = true;
        ws.Cell(row + 1, 6).Value = granTotalValor;
        ws.Cell(row + 1, 6).Style.Font.Bold = true;
        ws.Cell(row + 1, 6).Style.NumberFormat.Format = "$ #,##0.00";
        ws.Columns().AdjustToContents();

        workbook.SaveAs(rutaSalida);
    }
}
