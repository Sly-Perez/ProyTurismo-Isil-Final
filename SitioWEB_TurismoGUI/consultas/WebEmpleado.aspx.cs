using ProyTurismo_ADO;
using ProyTurismo_BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWEB_TurismoGUI.consultas
{
    public partial class WebEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private List<EmpleadoBE> ObtenerEmpleados()
        {

            EmpleadoADO empleadoADO = new EmpleadoADO();


            return empleadoADO.ListarEmpleados("", "", "", "", "");
        }

        protected void btnDescargarExcel_Click(object sender, EventArgs e)

        {

            List<EmpleadoBE> empleados = ObtenerEmpleados(); 

            if (empleados.Count > 0)
            {
                EmpleadoBE empleadoBE = new EmpleadoBE();

                empleadoBE.ExportarExcel(empleados);

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Empleados.xlsx");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                string filePath = Server.MapPath("~/Empleados.xlsx");

                if (File.Exists(filePath))
                {
                    Response.TransmitFile(filePath);
                    Response.End();
                }
                else
                {
                    Response.Write("El archivo no existe.");
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No hay datos para exportar a Excel.');", true);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            string idEmpleado = txtIdEmpleado.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDni.Text;
            string estado = ddlEstado.SelectedValue;

            try
            {
                EmpleadoADO empleadoADO = new EmpleadoADO();

                List<EmpleadoBE> listaEmpleados = empleadoADO.ListarEmpleados(idEmpleado, nombre, apellido, dni, estado);

                gvEmpleados.DataSource = listaEmpleados;
                gvEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al realizar la búsqueda: " + ex.Message;
            }
        }

    }
}
