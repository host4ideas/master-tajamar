using Microsoft.AspNetCore.Mvc;
using SegundaPracticaFMB.Models;

namespace SegundaPracticaFMB.Controllers
{
    public class ComicsController : Controller
    {
        private IRepositoryComics repo;

        public ComicsController(IRepositoryComics repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Comic> comics = this.repo.GetComics();
            return View(comics);
        }

        public IActionResult CreateComic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateComic(string nombre, string imagen, string descripcion)
        {
            this.repo.CreateComic(nombre, imagen, descripcion);
            return RedirectToAction("Index");
        }
    }
}
