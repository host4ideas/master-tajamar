using Microsoft.AspNetCore.Mvc;
using MvcCoreCacheRedisProductos.Models;
using MvcCoreCacheRedisProductos.Repositories;
using MvcCoreCacheRedisProductos.Services;

namespace MvcCoreCacheRedisProductos.Controllers
{
    public class ProductosController : Controller
    {
        private readonly RepositoryProductos repositoryProductos;
        private readonly ServiceCacheRedis serviceCache;

        public ProductosController(RepositoryProductos repositoryProductos, ServiceCacheRedis serviceCache)
        {
            this.repositoryProductos = repositoryProductos;
            this.serviceCache = serviceCache;
        }

        public IActionResult Index()
        {
            return View(this.repositoryProductos.GetProductos());
        }

        public IActionResult Details(int idProducto)
        {
            return View(this.repositoryProductos.FindProducto(idProducto));
        }

        public async Task<IActionResult> Favoritos()
        {
            return View(await this.serviceCache.GetProductosFavoritos());
        }

        public async Task<IActionResult> SeleccionarFavorito(int idProducto)
        {
            Producto? producto = this.repositoryProductos.FindProducto(idProducto);
            await this.serviceCache.AddProductoFavorito(producto);
            return RedirectToAction("Details", new { idProducto });
        }

        public async Task<IActionResult> DeleteFavorito(int idProducto)
        {
            await this.serviceCache.DeleteProductoFavorito(idProducto);
            return RedirectToAction("Favoritos");
        }
    }
}
