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
    public partial class WebReservaPorDistrito : System.Web.UI.Page
    {
        ReservaBE objReservaBE = new ReservaBE();

        ReservaBL objReservaBL = new ReservaBL();
        UbicacionBL objUbicacionBL = new UbicacionBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                try
                {
                    List<String> Departamentos = objUbicacionBL.ListarDepartamentosUbicaciones();

                    cboDepartamentos.DataSource = Departamentos;
                    cboDepartamentos.DataBind();

                    txtTotal.Text = "";
                }
                catch(Exception ex){
                    grvReservas.DataSource = null;
                    grvReservas.DataBind();
                    txtCantidadReg.Text = "";
                    txtTotal.Text = "";

                    lblMensajePopup.Text = "Error: " + ex.Message;
                    PopMensaje.Show();
                }
                
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboDepartamentos.SelectedValue == "")
                {
                    throw new Exception("El departamento a buscar se debe seleccionar");
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
                txtTotal.Text = "";

                lblMensajePopup.Text = "Error: " + ex.Message;
                PopMensaje.Show();
            }
        }


        protected void CargarDatos()
        {
            List<ReservaBE> objListaReservaBE;
            DateTime fecInicio = Convert.ToDateTime(txtFechaIni.Text);
            DateTime fecFin = Convert.ToDateTime(txtFechaFin.Text);                
                
            if (fecInicio > fecFin)
            {
                throw new Exception("La fecha Inicial no puede ser mayor que la fecha final");
            }

            if (cboDepartamentos.SelectedValue == "Todos")
            {
                objListaReservaBE = objReservaBL.ListarReservasFechas(fecInicio, fecFin);
            }
            else
            {
                objListaReservaBE = objReservaBL.ListarReservasDepartamentoFechas(cboDepartamentos.SelectedValue, fecInicio, fecFin);
            }

            //cargar monto total en lblTotal
            if (objListaReservaBE.Count() > 0)
            {
                txtTotal.Text = objReservaBL.CalcularTotalDepartamentoFechas(cboDepartamentos.SelectedValue, fecInicio, fecFin).ToString("s/###,###.00");
            }
            else
            {
                txtTotal.Text = "s/000.00";
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
    }
}