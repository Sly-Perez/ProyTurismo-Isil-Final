using ProyTurismo_BE;
using ProyTurismo_BL;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace SitioWEB_TurismoGUI.consultas
{
    public partial class WebCliente : System.Web.UI.Page
    {
        ClienteBL objClienteBL = new ClienteBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grvFacturacion.DataSource = null;
                grvFacturacion.DataBind();
                lblCantidadFacturas.Text = "";
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCliente = int.Parse(txtCodigoCliente.Text.Trim());
                DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text.Trim());
                DateTime fechaFin = DateTime.Parse(txtFechaFin.Text.Trim());
                string estado = ddlEstado.SelectedValue;

                List<FacturaClienteBE> facturas = new List<FacturaClienteBE>();

                if (estado == "Activo" || estado == "Inactivo")
                {
                    facturas = objClienteBL.ListarFacturacionClienteEntreFechasYEstado(idCliente, fechaInicio, fechaFin, estado);
                }
                else
                {
                    facturas = objClienteBL.ListarFacturacionClienteEntreFechas(idCliente, fechaInicio, fechaFin);
                }

                if (facturas.Count > 0)
                {
                    grvFacturacion.DataSource = facturas;
                    grvFacturacion.DataBind();
                    lblCantidadFacturas.Text = $"El cliente con ID {idCliente} tiene {facturas.Count} factura(s).";
                }
                else
                {
                    lblCantidadFacturas.Text = $"El cliente con ID {idCliente} no tiene facturas en el rango de fechas seleccionado.";
                    grvFacturacion.DataSource = null;
                    grvFacturacion.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblCantidadFacturas.Text = "Error: " + ex.Message;
                grvFacturacion.DataSource = null;
                grvFacturacion.DataBind();
            }
        }

        protected void grvFacturacion_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            grvFacturacion.PageIndex = e.NewPageIndex;
            btnConsultar_Click(sender, e);
        }
    }
}
