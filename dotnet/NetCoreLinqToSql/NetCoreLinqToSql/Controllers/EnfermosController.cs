using Microsoft.AspNetCore.Mvc;
using NetCoreLinqToSql.Models;
using NetCoreLinqToSql.Repositories;

namespace NetCoreLinqToSql.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryEnfermos repo;
        public EnfermosController()
        {
            this.repo = new();
        }

        public IActionResult Index()
        {
            List<Enfermo> enfermos = this.repo.GetEnfermos();
            return View(enfermos);
        }

        public IActionResult BuscadorEnfermos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscadorEnfermos(DateTime fechaNac)
        {
            List<Enfermo> enfermos = this.repo.GetEnfermos(fechaNac);
            if (enfermos == null)
            {
                ViewData["MENSAJE"] = "No se han encontrado enfermos";
            }
            return View(enfermos);
        }

        public IActionResult DeleteEnfermo(string inscripcion)
        {
            this.repo.Delete(inscripcion);
            return RedirectToAction("Index");
        }
    }
}
