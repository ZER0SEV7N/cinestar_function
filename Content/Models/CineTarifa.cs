using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinestar_function.Content.Models
{
    internal class CineTarifa
    {
        public int idCine { get; set; }
        public string DiasSemana { get; set; }
        public string Precio { get; set; }

        internal CineTarifa() { }

        internal CineTarifa(DataRow dr)
        {
            DiasSemana = dr["DiasSemana"].ToString();
            Precio = dr["Precio"].ToString();
        }
    }
}
