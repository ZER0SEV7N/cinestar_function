using Microsoft.Data.SqlClient;
using System.Data;
namespace cinestar_function.Content.Database
{
    //Clase para la conexion a la base de datos
    public class Conexion
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;

        //Constructor de la clase Conexion
        public Conexion (string cadena)
        {
            //Inicializar la conexion
            cn = new SqlConnection (cadena);
            cmd = new SqlCommand("", cn);
            da = new SqlDataAdapter(cmd);
        }

        internal void setencia (string sql)
        {
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
        }

        internal DataTable getDataTable()
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
