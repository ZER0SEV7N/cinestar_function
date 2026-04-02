using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinestar_function.Content.Models
{
    internal class Pelicula
    {
        public int id { get; set; }
        public string Titulo { get; set; }
        public string FechaEstreno { get; set; }
        public string Director { get; set; }
        public int idClasificacion { get; set; }
        public int idEstado { get; set; }
        public string Duracion { get; set; }
        public string Link { get; set; }
        public string Generos { get; set; }
        public string Reparto { get; set; }

        public string Sinopsis { get; set; }


        internal Pelicula() { }

        internal Pelicula(DataRow dr)
        {
            if (dr == null) return;
            int columnCount = dr.Table.Columns.Count;
            id = int.Parse(dr["id"].ToString());
            Titulo = dr["Titulo"].ToString();
            Link = dr["Link"].ToString();
            Sinopsis = dr["Sinopsis"].ToString();
            if (columnCount > 4)
            {
                FechaEstreno = dr["FechaEstreno"].ToString();
                Director = dr["Director"].ToString();
                idClasificacion = int.Parse(dr["idClasificacion"].ToString());
                idEstado = int.Parse(dr["idEstado"].ToString());
                Duracion = dr["Duracion"].ToString();
                Reparto = dr["Reparto"].ToString();
                Generos = dr["Geneross"].ToString();
            }

        }
    }
}
