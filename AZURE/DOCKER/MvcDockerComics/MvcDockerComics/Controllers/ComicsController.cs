using Microsoft.AspNetCore.Mvc;
using MvcDockerComics.Models;
using MvcDockerComics.Repositories;

namespace MvcDockerComics.Controllers
{
    public class ComicsController : Controller
    {
        private RepositoryComics repositoryComics;

        public ComicsController(RepositoryComics repositoryComics)
        {
            this.repositoryComics = repositoryComics;
        }

        public async Task<IActionResult> Index()
        {
            List<Comic> comics = await this.repositoryComics.GetComicsAsync();
            return View(comics);
        }

        public async Task<IActionResult> Details(int idComic)
        {
            return View(await this.repositoryComics.FindComicAsync(idComic));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comic comic)
        {
            await this.repositoryComics.InsertComicAsync(comic.Nombre, comic.Imagen);
            return View();
        }

        public async Task<IActionResult> Delete(int idComic)
        {
            await this.repositoryComics.DeleteComicAsync(idComic);
            return RedirectToAction("Index");
        }
    }
}
