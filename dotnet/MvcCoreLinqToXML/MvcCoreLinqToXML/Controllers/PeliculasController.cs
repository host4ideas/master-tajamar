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
    }
}
