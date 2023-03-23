using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqToXML.Models;
using MvcCoreLinqToXML.Repositories;

namespace MvcCoreLinqToXML.Controllers
{
    public class PeliculasController : Controller
    {
        private RepositoryPeliculas repositoryPeliculas;

        public PeliculasController(RepositoryPeliculas repositoryPeliculas)
        {
            this.repositoryPeliculas = repositoryPeliculas;
        }

        public IActionResult Index()
        {
            List<Pelicula> peliculas = this.repositoryPeliculas.GetPeliculas();
            return View(peliculas);
        }

        public IActionResult EscenasPelicula(int peliculaId)
        {
            List<Escena> escenas = this.repositoryPeliculas.GetEscenasPelicula(peliculaId);
            return View(escenas);
        }
         
        public IActionResult DetallePeliculaEscena(int idpelicula
            , int? posicion)
        {
            //LINQ FUNCIONA EN BASE 0
            //SQL SERVER FUNCIONA EN BASE 1
            if (posicion == null)
            {
                posicion = 0;
            }
            int numeroEscenas = 0;
            Escena escena = this.repositoryPeliculas.GetEscenaPelicula
                (idpelicula, posicion.Value, ref numeroEscenas);
            ViewData["DATOS"] = "Escena " + (posicion + 1)
                + " de " + numeroEscenas;
            int siguiente = posicion.Value + 1;
            if (siguiente >= numeroEscenas)
            {
                siguiente = 0;
            }
            int anterior = posicion.Value - 1;
            if (anterior < 0)
            {
                anterior = numeroEscenas - 1;
            }
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;
            Pelicula peli = this.repositoryPeliculas.FindPelicula(idpelicula);
            ViewData["PELICULA"] = peli;
            return View(escena);
        }
    }
}
