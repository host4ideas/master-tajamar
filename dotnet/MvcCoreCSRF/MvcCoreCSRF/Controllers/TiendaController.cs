using Microsoft.AspNetCore.Mvc;

namespace MvcCoreCSRF.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Productos()
        {
            if (HttpContext.Session.GetString("usuario") == null)
            {
                return RedirectToAction("AccesoDenegado", "Managed");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Productos(string direccion, string[] producto)
        {
            if (HttpContext.Session.GetString("usuario") != null)
            {
                TempData["PRODUCTOS"] = producto;
                TempData["DIRECCION"] = direccion;
                return RedirectToAction("PedidoFinal");
            }
            else
            {
                return RedirectToAction("AccesoDenegado", "Managed");
            }
        }

        public IActionResult PedidoFinal()
        {
            string[]? productos = TempData["PRODUCTOS"] as string[];
            ViewData["DIRECCION"] = TempData["DIRECCION"];
            return View(productos);
        }
    }
}
