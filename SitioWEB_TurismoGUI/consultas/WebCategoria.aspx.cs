using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace TuProyecto
{
    public partial class CategoriaConsulta : Page
    {
        private readonly string connectionString = "Server=localhost;Database=ProyectoTurismo;Trusted_Connection=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        private void CargarCategorias(int? idCategoria = null, string descripcion = "", decimal? tarifa = null, string caracteristicas = "", string estado = "")
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tb_Categoria WHERE 1=1";

                if (idCategoria.HasValue)
                {
                    query += " AND ID_Categoria = @ID_Categoria";
                }

                if (!string.IsNullOrEmpty(descripcion))
                {
                    query += " AND Des_Cat LIKE @Descripcion";
                }

                if (tarifa.HasValue)
                {
                    query += " AND Tar_Por_Noc = @Tarifa";
                }

                if (!string.IsNullOrEmpty(caracteristicas))
                {
                    query += " AND Caracteristicas LIKE @Caracteristicas";
                }

                if (!string.IsNullOrEmpty(estado))
                {
                    query += " AND Estado = @Estado";
                }

                SqlCommand cmd = new SqlCommand(query, con);

                if (idCategoria.HasValue)
                {
                    cmd.Parameters.AddWithValue("@ID_Categoria", idCategoria.Value);
                }

                if (!string.IsNullOrEmpty(descripcion))
                {
                    cmd.Parameters.AddWithValue("@Descripcion", "%" + descripcion + "%"); 
                }

                if (tarifa.HasValue)
                {
                    cmd.Parameters.AddWithValue("@Tarifa", tarifa.Value); 
                }

                if (!string.IsNullOrEmpty(caracteristicas))
                {
                    cmd.Parameters.AddWithValue("@Caracteristicas", "%" + caracteristicas + "%"); 
                }

                if (!string.IsNullOrEmpty(estado))
                {
                    cmd.Parameters.AddWithValue("@Estado", estado); 
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvCategorias.DataSource = dt;
                gvCategorias.DataBind();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int? idCategoria = string.IsNullOrEmpty(txtIDCategoria.Text) ? (int?)null : Convert.ToInt32(txtIDCategoria.Text);
            string descripcion = txtDescripcion.Text;
            decimal? tarifa = string.IsNullOrEmpty(txtTarifa.Text) ? (decimal?)null : Convert.ToDecimal(txtTarifa.Text);
            string caracteristicas = txtCaracteristicas.Text;
            string estado = ddlEstado.SelectedValue;

            CargarCategorias(idCategoria, descripcion, tarifa, caracteristicas, estado);
        }

     
    }
}
