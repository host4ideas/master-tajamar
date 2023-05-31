using Microsoft.AspNetCore.Mvc;
using MvcCoreElastiCacheAWS.Models;
using MvcCoreElastiCacheAWS.Repositories;
using MvcCoreElastiCacheAWS.Services;

namespace MvcCoreElastiCacheAWS.Controllers
{
    public class CochesController : Controller
    {
        private readonly RepositoryCoches repositoryCoches;
        private readonly ServiceAWSCache serviceCache;

        public CochesController(RepositoryCoches repositoryCoches, ServiceAWSCache serviceCache)
        {
            this.repositoryCoches = repositoryCoches;
            this.serviceCache = serviceCache;
        }

        public IActionResult Index()
        {
            return View(this.repositoryCoches.GetCoches());
        }

        public IActionResult Details(int id)
        {
            return View(this.repositoryCoches.FindCoche(id));
        }

        public async Task<IActionResult> SeleccionarFavorito(int id)
        {
            Coche? coche = this.repositoryCoches.FindCoche(id);
            if (coche != null)
            {
                await this.serviceCache.AddCocheAsync(coche);
                return RedirectToAction(nameof(Favoritos));
            }
            return View(nameof(Favoritos));
        }

        public async Task<IActionResult> Favoritos()
        {
            return View(await this.serviceCache.GetCochesFavoritosAsync() ?? new List<Coche>());
        }

        public async Task<IActionResult> EliminarFavorito(int id)
        {
            await this.serviceCache.DeleteCocheFavoritoAsync(id);
            return RedirectToAction(nameof(Favoritos));
        }
    }
}
