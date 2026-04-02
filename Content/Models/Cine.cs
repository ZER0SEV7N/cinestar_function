using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinestar_function.Content.Models
{
    internal class Cine
    {
        public int id { get; set; }
        public string RazonSocial { get; set; }
        public int Salas { get; set; }
        public int idDistrito { get; set; }
        public string Direccion { get; set; }
        public string Telefonos { get; set; }
        public string Detalle { get; set; }

        internal Cine() { }

        internal Cine(DataRow dr)
        {
            if(dr == null) return;
            id = int.Parse(dr["id"].ToString());
            RazonSocial = dr["RazonSocial"].ToString();
            Salas = int.Parse(dr["Salas"].ToString());
            idDistrito = int.Parse(dr["idDistrito"].ToString());
            Direccion = dr["Direccion"].ToString();
            Telefonos = dr["Telefonos"].ToString();
            Detalle = dr["Detalle"].ToString();
        }
    }
}
