using cinestar_function.Content.Database; 
using cinestar_function.Content.Models;
using System.Data;
namespace cinestar_function.Content.Datos
{
    //daoCinestar: Clase encargada de obtener los datos y setearlos en los modelos correspondientes
    public class daoCinestar
    {
        private readonly Conexion _conexion;

        public daoCinestar(Conexion conexion)
        {
            _conexion = conexion;
        }

        //Obtener todos los cines
        internal List<Cine> getCines()
        {
            _conexion.setencia("sp_getCines");
            DataTable dt = _conexion.getDataTable();
            List<Cine> cines = new List<Cine>();
            foreach (DataRow dr in dt.Rows)
                cines.Add(new Cine(dr));


            return cines;
        }

        //Obtener un solo cine por su id
        internal Cine getCine(int id)
        {
            _conexion.setencia($"sp_getcine {id}");
            DataTable dt = _conexion.getDataTable();
            if (dt.Rows.Count > 0)
                return new Cine(dt.Rows[0]);
            else
                return null;
        }

        //Obtener las tarifas de un cine por su id
        internal List<CineTarifa> getCineTarifa(int idCine)
        {
            _conexion.setencia($"sp_getCineTarifas {idCine}");
            DataTable dt = _conexion.getDataTable();
            List<CineTarifa> cineTarifas = new List<CineTarifa>();
            foreach (DataRow dr in dt.Rows)
                cineTarifas.Add(new CineTarifa(dr));

            return cineTarifas;

        }

        //Obtener las peliculas de un cine por su estado
        internal List<Pelicula> getPeliculas(int id)
        {
            _conexion.setencia($"sp_getPeliculas {id}");
            DataTable dt = _conexion.getDataTable();
            List<Pelicula> peliculas = new List<Pelicula>();
            foreach (DataRow dr in dt.Rows)
                peliculas.Add(new Pelicula(dr));

            return peliculas;
        }

        //Obtener una sola pelicula por su id
        internal Pelicula getPelicula(int id)
        {
            _conexion.setencia($"sp_getPelicula {id}");
            DataTable dt = _conexion.getDataTable();
            if (dt.Rows.Count > 0)
                return new Pelicula(dt.Rows[0]);
            else
                return null;
        }

        //Obtener las peliculas de un cine por el id del cine
        internal List<CinePelicula> getCinePeliculas(int idCine)
        {
            _conexion.setencia($"sp_getCinePeliculas {idCine}");
            DataTable dt = _conexion.getDataTable();
            List<CinePelicula> cinePeliculas = new List<CinePelicula>();
            foreach (DataRow dr in dt.Rows)
                cinePeliculas.Add(new CinePelicula(dr));

            return cinePeliculas;
        }

    }
}
