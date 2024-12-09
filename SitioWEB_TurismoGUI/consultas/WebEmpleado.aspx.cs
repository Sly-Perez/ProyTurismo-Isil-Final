using System;
using System.Web.UI;
using SitioWEB_TurismoGUI.consultas; // Asegúrate de que el espacio de nombres sea correcto
using ProyTurismo_ADO;
using ProyTurismo_BE;

namespace SitioWEB_TurismoGUI.consultas
{
    public partial class WebEmpleado : Page
    {
        // Se ejecuta cuando la página se carga
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los empleados al iniciar la página
                CargarEmpleados();
            }
        }

        // Método para cargar todos los empleados en el GridView
        private void CargarEmpleados()
        {
            try
            {
                EmpleadoADO empleadoADO = new EmpleadoADO();
                var empleados = empleadoADO.ListarEmpleados(null, null, null, null, null);  // No se aplican filtros
                gvEmpleados.DataSource = empleados;
                gvEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al cargar los empleados: {ex.Message}');", true);
            }
        }

        // Método que se ejecuta cuando se hace clic en el botón de búsqueda
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string idEmpleado = txtIdEmpleado.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string dni = txtDni.Text.Trim();
                string estado = ddlEstado.SelectedValue;

                EmpleadoADO empleadoADO = new EmpleadoADO();
                var empleados = empleadoADO.ListarEmpleados(idEmpleado, nombre, apellido, dni, estado);
                gvEmpleados.DataSource = empleados;
                gvEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al buscar los empleados: {ex.Message}');", true);
            }
        }
    }
}
