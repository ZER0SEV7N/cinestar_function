using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using cinestar_function.Content.Datos;
using cinestar_function.Content.Models;
namespace cinestar_function.Content.Function
{
    public class CinestarEndpoints
    {
        private readonly daoCinestar _daoCinestar;

        private readonly ILogger<CinestarEndpoints> _logger;

        public CinestarEndpoints(ILogger<CinestarEndpoints> logger, daoCinestar daoCinestar)
        {
            _logger = logger;
            _daoCinestar = daoCinestar;
        }

        //Endpoint para obtener todos los cines
        [Function("verCines")]
        public IActionResult verCines(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "verCines")] HttpRequest req)
        {
            _logger.LogInformation("Ejecutando endpoint verCines");
            var cines = _daoCinestar.getCines();
            if (cines == null || cines.Count == 0) return new NotFoundObjectResult(new { mensaje = "No se encontraron cines" });
            return new OkObjectResult(cines);
        }

        //Endpoint para obtener un cine por su id
        [Function("verCine")]
        public IActionResult verCine(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "verCine/{id:int}")] HttpRequest req,
            int id)
        {
            _logger.LogInformation($"Ejecutando el endpoint verCine con id: {id}");
            var cine = _daoCinestar.getCine(id);
            List<CineTarifa> cineTarifas = _daoCinestar.getCineTarifa(id);
            List<CinePelicula> cinePeliculas = _daoCinestar.getCinePeliculas(id);
            if (cine == null) return new NotFoundObjectResult(new { mensaje = $"No se encontró el cine con id: {id}" });
            return new OkObjectResult(new { cine, cineTarifas, cinePeliculas });
        }

        //Endpoint para obtener las peliculas dependiendo de su estado
        [Function("verPeliculas")]
        public IActionResult verPeliculas(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "verPeliculas/{id:int}")] HttpRequest req,
            int id)
        {
            _logger.LogInformation($"Ejecutando el endpoint verPeliculas con id: {id}");
            var peliculas = _daoCinestar.getPeliculas(id);
            if (peliculas == null || peliculas.Count == 0) return new NotFoundObjectResult(new { mensaje = $"No se encontraron peliculas para el cine con id: {id}" });
            return new OkObjectResult(peliculas);
        }

        //Endpoint para obtener una pelicula por su id
        [Function("verPelicula")]
        public IActionResult verPelicula(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "verPelicula/{id:int}")] HttpRequest req,
            int id)
        {
            _logger.LogInformation($"Ejecutando el endpoint verPelicula con id: {id}");
            var pelicula = _daoCinestar.getPelicula(id);
            if (pelicula == null) return new NotFoundObjectResult(new { mensaje = $"No se encontró la pelicula con id: {id}" });
            return new OkObjectResult(pelicula);
        }

        //Endpoint para tener las tarifas de un cine por su id
        [Function("verTarifas")]
        public IActionResult verTarifas(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "verTarifas/{id:int}")] HttpRequest req,
            int id)
        {
            _logger.LogInformation($"Ejecutando el endpoint verTarifas con id: {id}");
            var cineTarifas = _daoCinestar.getCineTarifa(id);
            if (cineTarifas == null || cineTarifas.Count == 0) return new NotFoundObjectResult(new { mensaje = $"No se encontraron tarifas para el cine con id: {id}" });
            return new OkObjectResult(cineTarifas);
        }

        //Endpoint para obtener las peliculas de un cine por su id
        [Function("verCinePeliculas")]
        public IActionResult verCinePeliculas(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "verCinePeliculas/{id:int}")] HttpRequest req,
            int id)
        {
            _logger.LogInformation($"Ejecutando el endpoint verCinePeliculas con id: {id}");
            var cinePeliculas = _daoCinestar.getCinePeliculas(id);
            if (cinePeliculas == null || cinePeliculas.Count == 0) return new NotFoundObjectResult(new { mensaje = $"No se encontraron peliculas para el cine con id: {id}" });
            return new OkObjectResult(cinePeliculas);
        }
    }
}
