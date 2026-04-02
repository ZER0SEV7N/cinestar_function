using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinestar_function.Content.Models
{
    internal class CinePelicula
    {
        public int idCine { get; set; }

        public int idPelicula { get; set; }
        public int Sala { get; set; }

        public string Titulo { get; set; }
        public string Horarios { get; set; }

        internal CinePelicula() { }

        internal CinePelicula(DataRow dr)
        {
            Titulo = dr["Titulo"].ToString();
            Horarios = dr["Horarios"].ToString();
        }
    }
}
