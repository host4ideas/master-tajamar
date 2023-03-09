using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MvcCryptography.Controllers
{
    public class CachingController : Controller
    {
        IMemoryCache memoryCache;

        public CachingController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public IActionResult MemoriaPersonalizada(int? tiempo)
        {
            if (tiempo == null)
            {
                tiempo = 60;
            }

            string fecha = DateTime.Now.ToLongDateString() + " -- " + DateTime.Now.ToLongTimeString();

            if (this.memoryCache.Get("FECHA") == null)
            {
                MemoryCacheEntryOptions options = new();
                options.SetAbsoluteExpiration(TimeSpan.FromSeconds(tiempo.Value));

                this.memoryCache.Set("FECHA", fecha, options);
                ViewData["MENSAJE"] = "Almacenado en cache";
                ViewData["MENSAJE"] = this.memoryCache.Get("FECHA");
            }
            else
            {
                fecha = this.memoryCache.Get<string>("FECHA");
                ViewData["MENSAJE"] = "Recuperando cache";
                ViewData["FECHA"] = fecha;
            }

            return View();
        }

        [ResponseCache(Duration = 5, Location = ResponseCacheLocation.Client)]
        public IActionResult MemoriaDistribuida()
        {
            string fecha = DateTime.Now.ToLongDateString() + " -- " + DateTime.Now.ToLongTimeString();
            ViewData["FECHA"] = fecha;
            return View();
        }
    }
}
