using OfficeOpenXml;
using ProyTurismo_BE;
using ProyTurismo_BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWEB_TurismoGUI.consultas
{
    public partial class WebCliente : System.Web.UI.Page
    {
        
        ClienteBL objClienteBL = new ClienteBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                grvFacturacion.DataSource = null;
                grvFacturacion.DataBind();
                lblCantidadFacturas.Text = string.Empty;
            }
        }

        
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (string.IsNullOrWhiteSpace(txtFechaInicio.Text) || string.IsNullOrWhiteSpace(txtFechaFin.Text))
                {
                    throw new Exception("Debe ingresar tanto la fecha de inicio como la fecha de fin.");
                }

              
                DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text.Trim());
                DateTime fechaFin = DateTime.Parse(txtFechaFin.Text.Trim());

                
                if (fechaInicio > fechaFin)
                {
                    throw new Exception("La fecha de inicio no puede ser mayor a la fecha de fin.");
                }

                
                List<ClienteBE> reservas = objClienteBL.ListarReservasEntreFechas(fechaInicio, fechaFin);

                
                if (reservas != null && reservas.Count > 0)
                {
                    grvFacturacion.DataSource = reservas;
                    grvFacturacion.DataBind();

                   
                    lblCantidadFacturas.Text = $"Se encontraron {reservas.Count} reservas en el rango de fechas seleccionado.";
                }
                else
                {
                    grvFacturacion.DataSource = null;
                    grvFacturacion.DataBind();

                    lblCantidadFacturas.Text = "No se encontraron reservas en el rango de fechas seleccionado.";
                }
            }
            catch (Exception ex)
            {
               
                lblCantidadFacturas.Text = "Error: " + ex.Message;

                grvFacturacion.DataSource = null;
                grvFacturacion.DataBind();
            }
        }

        protected void grvFacturacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grvFacturacion.PageIndex = e.NewPageIndex;
                btnConsultar_Click(sender, e); 
            }
            catch (Exception ex)
            {
                lblCantidadFacturas.Text = "Error al cambiar de página: " + ex.Message;
            }
        }

        protected void btnDescargarExcel_Click(object sender, EventArgs e)
        {
            try
            {
            
                if (grvFacturacion.Rows.Count > 0)
                {
                    
                    using (var pck = new ExcelPackage())
                    {
                       
                        var ws = pck.Workbook.Worksheets.Add("Clientes");

                        
                        for (int i = 0; i < grvFacturacion.Columns.Count; i++)
                        {
                            ws.Cells[1, i + 1].Value = grvFacturacion.Columns[i].HeaderText;
                        }

                        
                        for (int row = 0; row < grvFacturacion.Rows.Count; row++)
                        {
                            for (int col = 0; col < grvFacturacion.Columns.Count; col++)
                            {
                                ws.Cells[row + 2, col + 1].Value = grvFacturacion.Rows[row].Cells[col].Text;
                            }
                        }

                        
                        ws.Cells.AutoFitColumns();

                       
                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment; filename=FacturasClientes.xlsx");

                        using (var memoryStream = new MemoryStream())
                        {
                            pck.SaveAs(memoryStream);
                            memoryStream.WriteTo(Response.OutputStream);
                        }

                        Response.End();
                    }
                }
                else
                {
                    lblCantidadFacturas.Text = "No hay datos para exportar.";
                }
            }
            catch (Exception ex)
            {
                lblCantidadFacturas.Text = "Error al generar el archivo Excel: " + ex.Message;
            }
        }
    }
}
