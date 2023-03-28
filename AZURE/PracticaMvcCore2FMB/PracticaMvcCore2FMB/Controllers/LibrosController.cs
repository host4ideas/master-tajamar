using Microsoft.AspNetCore.Mvc;
using PracticaMvcCore2FMB.Extensions;
using PracticaMvcCore2FMB.Filters;
using PracticaMvcCore2FMB.Models;
using PracticaMvcCore2FMB.Repositories;
using System.Security.Claims;

namespace PracticaMvcCore2FMB.Controllers
{
    public class LibrosController : Controller
    {
        private RepositoryLibros repositoryLibros;

        public LibrosController(RepositoryLibros repositoryLibros)
        {
            this.repositoryLibros = repositoryLibros;
        }

        public async Task<IActionResult> Index(int? posicion)
        {
            int numeroLibros = await this.repositoryLibros.LibrosCount();

            if (posicion == null)
            {
                posicion = 0;
            }

            if (posicion > numeroLibros)
            {
                posicion = 0;
            }

            if (posicion < 0)
            {
                posicion = numeroLibros - 1;
            }

            List<Libro> libros = await this.repositoryLibros.AllLibros(posicion.Value);

            ViewData["SIGUIENTE"] = posicion + 4;
            ViewData["ANTERIOR"] = posicion - 4;

            return View(libros);
        }

        public async Task<IActionResult> Details(int idLibro)
        {
            Libro libro = await this.repositoryLibros.FindLibro(idLibro);
            return View(libro);
        }

        public async Task<IActionResult> LibrosGenero(int idGenero, string nombreGenero)
        {
            List<Libro> libros = await this.repositoryLibros.LibrosGenero(idGenero);
            ViewData["GENERO"] = nombreGenero;
            return View(libros);
        }

        public IActionResult Carrito()
        {
            List<Libro>? carrito = HttpContext.Session.GetObject<List<Libro>>("CARRITO");
            if (carrito == null)
            {
                carrito = new();
                HttpContext.Session.SetObject("CARRITO", new List<Libro>());
            }
            return View(carrito);
        }

        public async Task<IActionResult> QuitarDeCarrito(int idLibro)
        {
            List<Libro>? carrito = HttpContext.Session.GetObject<List<Libro>>("CARRITO");

            if (carrito == null)
            {
                carrito = new();
            }

            var result = carrito.Remove(carrito.FirstOrDefault(x => x.IdLibro == idLibro));

            // Save without duplicates
            HttpContext.Session.SetObject("CARRITO", carrito);

            return RedirectToAction("Carrito");
        }

        [AuthorizeUsers]
        public async Task<IActionResult> VistaPedidos()
        {
            int usuarioId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<VistaPedidos> pedidos = await this.repositoryLibros.PedidosUsuario(usuarioId);
            return View(pedidos);
        }

        [AuthorizeUsers]
        public async Task<IActionResult> FinalizarCompra()
        {
            List<Libro>? carrito = HttpContext.Session.GetObject<List<Libro>>("CARRITO");
            int usuarioId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            await this.repositoryLibros.FinalizarCompra(usuarioId, carrito);

            // Vaciar carrito
            HttpContext.Session.SetObject("CARRITO", new List<Libro>());

            return RedirectToAction("VistaPedidos");
        }

        public async Task<IActionResult> Purchase(int idLibro)
        {
            Libro? libro = await this.repositoryLibros.FindLibro(idLibro);

            if (libro != null)
            {
                List<Libro>? carrito = HttpContext.Session.GetObject<List<Libro>>("CARRITO");

                if (carrito == null)
                {
                    carrito = new();
                }

                carrito.Add(new Libro()
                {
                    IdLibro = idLibro,
                    Autor = libro.Autor,
                    Editorial = libro.Editorial,
                    IdGenero = libro.IdGenero,
                    Portada = libro.Portada,
                    Precio = libro.Precio,
                    Resumen = libro.Resumen,
                    Titulo = libro.Titulo
                });

                // Save without duplicates
                HttpContext.Session.SetObject("CARRITO", carrito);
            }
            return RedirectToAction("Index");
        }
    }
}
