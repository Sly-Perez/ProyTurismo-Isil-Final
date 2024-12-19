using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

namespace TuProyecto
{
    public partial class WebGraficoCategoria : System.Web.UI.Page
    {
        private readonly string connectionString = "Server=localhost;Database=ProyectoTurismo;Trusted_Connection=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla(); 
                CargarGraficoTarifa(); 
                CargarGraficoCaracteristicas(); 
            }
        }

        private void CargarTabla()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Des_Cat, Tar_Por_Noc, Caracteristicas FROM Tb_Categoria";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptDatos.DataSource = dt;
                rptDatos.DataBind();
            }
        }

       private void CargarGraficoTarifa()
{
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        string query = "SELECT Des_Cat, Tar_Por_Noc FROM Tb_Categoria";
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataTable dt = new DataTable();
        da.Fill(dt);

        chartTarifaPorNoche.Series["Tarifas"].Points.Clear();

        foreach (DataRow row in dt.Rows)
        {
            string categoria = row["Des_Cat"].ToString();
            decimal tarifa = Convert.ToDecimal(row["Tar_Por_Noc"]);

            chartTarifaPorNoche.Series["Tarifas"].Points.AddXY(categoria, tarifa);
        }
    }
}

        private void CargarGraficoCaracteristicas()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Caracteristicas FROM Tb_Categoria";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Dictionary<string, int> caracteristicasCount = new Dictionary<string, int>();

                foreach (DataRow row in dt.Rows)
                {
                    string caracteristicas = row["Caracteristicas"].ToString();
                    if (!string.IsNullOrEmpty(caracteristicas))
                    {
                        string[] caracteristicasArray = caracteristicas.Split(',');

                        foreach (string caracteristica in caracteristicasArray)
                        {
                            string trimmedCaracteristica = caracteristica.Trim();

                            if (caracteristicasCount.ContainsKey(trimmedCaracteristica))
                            {
                                caracteristicasCount[trimmedCaracteristica]++;
                            }
                            else
                            {
                                caracteristicasCount[trimmedCaracteristica] = 1;
                            }
                        }
                    }
                }

                chartCaracteristicas.Series["Caracteristicas"].Points.Clear();

                foreach (var item in caracteristicasCount)
                {
                    DataPoint point = new DataPoint();
                    point.AxisLabel = string.Empty; 
                    point.YValues = new double[] { item.Value }; 
                    point.LegendText = item.Key; 
                    chartCaracteristicas.Series["Caracteristicas"].Points.Add(point);
                }
            }
        }

    }
}
