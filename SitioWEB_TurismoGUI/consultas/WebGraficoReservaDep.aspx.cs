using ProyTurismo_BE;
using ProyTurismo_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWEB_TurismoGUI.consultas
{
    public partial class WebGraficoReservaDep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    UbicacionBL objUbicacionBL = new UbicacionBL();
                    grvResultado.DataSource = objUbicacionBL.ListarFacturacionUbicacion();
                    grvResultado.DataBind();

                    grafMontoTotal.Series.Add("TotalGenerado");
                    grafMontoTotal.Series["TotalGenerado"].Points.DataBindXY(objUbicacionBL.ListarFacturacionUbicacion(), "Departamento", objUbicacionBL.ListarFacturacionUbicacion(), "MontoTotalGenerado");
                    grafMontoTotal.Series["TotalGenerado"].IsValueShownAsLabel = true;
                    grafMontoTotal.Series["TotalGenerado"].LabelFormat = "c";

                    grafCantidadReservas.Series.Add("Cantidades");
                    grafCantidadReservas.Series["Cantidades"].Points.DataBindXY(objUbicacionBL.ListarFacturacionUbicacion(), "Departamento", objUbicacionBL.ListarFacturacionUbicacion(), "CantidadReservas");
                    grafCantidadReservas.Series["Cantidades"].IsValueShownAsLabel = true;

                }
            }
            catch(Exception ex)
            {
                lblMensajeError.Text = "Error: " + ex.Message;
            }
        }
    }
}