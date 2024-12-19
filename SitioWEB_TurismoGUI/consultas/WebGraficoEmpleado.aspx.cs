using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using ProyTurismo_ADO; // Asegúrate de que el ADO esté referenciado correctamente

namespace SitioWEB_TurismoGUI.consultas
{
    public partial class WebGraficoEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            try
            {
                EmpleadoADO empleadoADO = new EmpleadoADO();

                int empleadosActivos = empleadoADO.ContarEmpleadosPorEstado("Activo");
                int empleadosInactivos = empleadoADO.ContarEmpleadosPorEstado("Inactivo");

                var listaRoles = empleadoADO.ListarEmpleados("", "", "", "", "").GroupBy(x => x.Rol_Emp)
                    .Select(g => new { Rol = g.Key, Cantidad = g.Count() }).ToList();

                gvEmpleadosEstadisticas.DataSource = listaRoles;
                gvEmpleadosEstadisticas.DataBind();

                grafEmpleadosPorEstado.Series["Empleados"].Points.AddXY("Activos", empleadosActivos);
                grafEmpleadosPorEstado.Series["Empleados"].Points.AddXY("Inactivos", empleadosInactivos);

                for (int i = 0; i < listaRoles.Count; i++)
                {
                    var rol = listaRoles[i];
                    var point = grafEmpleadosPorRol.Series["Roles"].Points.AddXY(rol.Rol, rol.Cantidad);

                    if (rol.Rol == "Gerente")
                    {
                        grafEmpleadosPorRol.Series["Roles"].Points[i].Color = System.Drawing.Color.Blue;
                    }
                    else if (rol.Rol == "Supervisor")
                    {
                        grafEmpleadosPorRol.Series["Roles"].Points[i].Color = System.Drawing.Color.Orange;
                    }
                    else if (rol.Rol == "Empleado")
                    {
                        grafEmpleadosPorRol.Series["Roles"].Points[i].Color = System.Drawing.Color.Green;
                    }
                    else
                    {
                        grafEmpleadosPorRol.Series["Roles"].Points[i].Color = System.Drawing.Color.Gray;
                    }

                  
                    grafEmpleadosPorRol.Series["Roles"].Points[i].Label = rol.Cantidad.ToString();
                }

              
                foreach (var point in grafEmpleadosPorEstado.Series["Empleados"].Points)
                {
                    point.Label = string.Format("{0}: {1} ({2}%)", point.AxisLabel, point.YValues[0],
                        (point.YValues[0] / (empleadosActivos + empleadosInactivos) * 100).ToString("0.00"));
                }

                grafEmpleadosPorRol.Legends["Legend1"].CustomItems.Clear();

                foreach (var rol in listaRoles)
                {
                    System.Drawing.Color color = System.Drawing.Color.Gray;
                    string description = string.Empty;

                    if (rol.Rol == "Gerente")
                    {
                        color = System.Drawing.Color.Blue;
                        description = "Gerente";
                    }
                    else if (rol.Rol == "Supervisor")
                    {
                        color = System.Drawing.Color.Orange;
                        description = "Supervisor";
                    }
                    else if (rol.Rol == "Empleado")
                    {
                        color = System.Drawing.Color.Green;
                        description = "Empleado";
                    }

                    grafEmpleadosPorRol.Legends["Legend1"].CustomItems.Add(color, description + ": " + rol.Cantidad.ToString());
                }

            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error al cargar los datos: " + ex.Message;
            }
        }


    }
}

