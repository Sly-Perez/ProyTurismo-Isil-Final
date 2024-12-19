using ProyTurismo_BE;
using ProyTurismo_BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using OfficeOpenXml;

namespace SitioWEB_TurismoGUI.consultas
{
    public partial class WebReservaPorDistrito : System.Web.UI.Page
    {
        ReservaBE objReservaBE = new ReservaBE();

        ReservaBL objReservaBL = new ReservaBL();
        UbicacionBL objUbicacionBL = new UbicacionBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                }
            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(txtCodigoTour.Text) <= 0)
                {
                    throw new Exception("El código ingresado debe ser mayor a 0");
                }

                if (txtFechaIni.Text.Trim() == "" || txtFechaFin.Text.Trim() == "")
                {
                    throw new Exception("La fecha de Inicio y/o Fin se deben ingresar");
                }

                CargarDatos();
            }
            catch (Exception ex)
            {
                grvReservas.DataSource = null;
                grvReservas.DataBind();
                txtCantidadReg.Text = "";

                lblMensajePopup.Text = "Error: " + ex.Message;
                PopMensaje.Show();
            }
        }


        protected void CargarDatos()
        {
            List<ReservaBE> objListaReservaBE;
            Int16 codigo = Convert.ToInt16(txtCodigoTour.Text);
            DateTime fecInicio = Convert.ToDateTime(txtFechaIni.Text);
            DateTime fecFin = Convert.ToDateTime(txtFechaFin.Text);                
                
            if (fecInicio > fecFin)
            {
                throw new Exception("La fecha Inicial no puede ser mayor que la fecha final");
            }

            else
            {
                objListaReservaBE = objReservaBL.ListarReservasFechas(codigo, fecInicio, fecFin);
            }

            grvReservas.DataSource = objListaReservaBE;
            grvReservas.DataBind();

            txtCantidadReg.Text = objListaReservaBE.Count().ToString();
        }

        protected void grvReservas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvReservas.PageIndex = e.NewPageIndex;
            CargarDatos();
        }

        protected void btnDescargarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                String rutaPlantilla = Server.MapPath("/") + @"Documentos\ListadoFactuReservaTour.xlsx";

                //obtenemos las facturas a descargar
                List<ReservaBE> objListaReservaBE = objReservaBL.ListarReservasFechas(
                                                    Convert.ToInt16(txtCodigoTour.Text.Trim()),
                                                    Convert.ToDateTime(txtFechaIni.Text.Trim()),
                                                    Convert.ToDateTime(txtFechaFin.Text.Trim())
                                                    );
                Int16 CanRegistros = Convert.ToInt16(txtCantidadReg.Text);

                if (CanRegistros == 0)
                {
                    throw new Exception("No hay facturas registradas para realizar un reporte Excel.");
                }

                
                Int16 fila1 = 5;
                using (var pck = new OfficeOpenXml.ExcelPackage(new FileInfo(rutaPlantilla)))
                {
                    
                    String filename = "ListadoFactuReservaTour_" + DateTime.Today.ToShortDateString();
                    
                    ExcelWorksheet ws = pck.Workbook.Worksheets["Hoja1"];

                    
                    ws.Cells[2, 4].Value = txtCodigoTour.Text.Trim();
                    ws.Cells[2, 7].Value = txtFechaIni.Text + " y " + txtFechaFin.Text;

                    
                    foreach (ReservaBE miReserva in objListaReservaBE)
                    {
                        ws.Cells[fila1, 1].Value = miReserva.Id_Factura;
                        ws.Cells[fila1, 2].Value = Convert.ToDateTime(miReserva.Fec_Emi);
                        ws.Cells[fila1, 3].Value = miReserva.Total.ToString("#,###,##0.00");
                        ws.Cells[fila1, 4].Value = miReserva.Met_Pag;
                        ws.Cells[fila1, 5].Value = miReserva.Id_Tour;
                        ws.Cells[fila1, 6].Value = miReserva.Est_Tour;
                        ws.Cells[fila1, 7].Value = miReserva.Departamento;
                        ws.Cells[fila1, 8].Value = miReserva.Provincia;
                        ws.Cells[fila1, 9].Value = miReserva.Distrito;

                        fila1 += 1;
                    }

                    ws.Column(1).Width = 20;
                    ws.Column(2).Width = 30;
                    ws.Column(3).Width = 30;
                    ws.Column(4).Width = 30;
                    ws.Column(5).Width = 20;
                    ws.Column(6).Width = 30;
                    ws.Column(7).Width = 25;
                    ws.Column(8).Width = 25;
                    ws.Column(9).Width = 25;

                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment; filename=" + filename + ".xlsx");

                    using (var memoryStream = new MemoryStream())
                    {
                        pck.SaveAs(memoryStream);
                        memoryStream.WriteTo(Response.OutputStream);
                    }
                    Response.End();

                }

            }
            catch (Exception ex)
            {
                lblMensajePopup.Text = ex.Message;
                PopMensaje.Show();
            }
        }



    }
}