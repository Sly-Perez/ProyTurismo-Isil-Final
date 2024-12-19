using ProyTurismo_ADO;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.DataVisualization.Charting;

namespace SitioWEB_TurismoGUI.consultas
{
    public partial class WebClientesGrafico : System.Web.UI.Page
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
                // Usar el contexto de Entity Framework
                using (ProyectoTurismoEntities db = new ProyectoTurismoEntities())
                {
                    // Ejecutar el procedimiento almacenado y obtener los resultados
                    var resultados = db.Database.SqlQuery<ResultadoCliente>(
                        "EXEC ObtenerClientesConReservasYMontoTotal").ToList();

                    // Limitar los resultados a los primeros 5 registros
                    var resultadosLimitados = resultados.Take(5).ToList();

                    // Verificar si hay datos
                    if (resultadosLimitados.Any())
                    {
                        // Enlazar datos al GridView
                        grvResultado.DataSource = resultadosLimitados;
                        grvResultado.DataBind();

                        // Configurar gráfico de Monto Total Generado
                        grafMontoTotal.Series.Clear();
                        grafMontoTotal.Series.Add("MontoTotal");

                        // Asegurarse de que ID_Cliente sea un string (es común que los gráficos necesiten un tipo string en el eje X)
                        var idClientes = resultadosLimitados.Select(r => r.ID_Cliente.ToString()).ToList();
                        var montoTotalGenerado = resultadosLimitados.Select(r => r.MontoTotalGenerado).ToList();

                        grafMontoTotal.Series["MontoTotal"].Points.DataBindXY(idClientes, montoTotalGenerado);
                        grafMontoTotal.Series["MontoTotal"].IsValueShownAsLabel = true;
                        grafMontoTotal.Series["MontoTotal"].ChartType = SeriesChartType.Column;
                        grafMontoTotal.Titles.Clear();
                        grafMontoTotal.Titles.Add("Monto Total Generado por Cliente");

                        // Configurar gráfico de Número de Reservas
                        grafCantidadReservas.Series.Clear();
                        grafCantidadReservas.Series.Add("NumeroReservas");

                        var numeroReservas = resultadosLimitados.Select(r => r.NumeroReservas).ToList();

                        grafCantidadReservas.Series["NumeroReservas"].Points.DataBindXY(idClientes, numeroReservas);
                        grafCantidadReservas.Series["NumeroReservas"].IsValueShownAsLabel = true;
                        grafCantidadReservas.Series["NumeroReservas"].ChartType = SeriesChartType.Bar;
                        grafCantidadReservas.Titles.Clear();
                        grafCantidadReservas.Titles.Add("Número de Reservas por Cliente");
                    }
                    else
                    {
                        lblMensajeError.Text = "No se encontraron datos para mostrar.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error al cargar los datos: " + ex.Message;
            }
        }

        protected void grafMontoTotal_Load(object sender, EventArgs e)
        {

        }
    }


    // Clase para mapear los resultados del procedimiento almacenado
    public class ResultadoCliente
    {
        public int ID_Cliente { get; set; }
        public int NumeroReservas { get; set; }
        public decimal MontoTotalGenerado { get; set; }
    }
}

     

