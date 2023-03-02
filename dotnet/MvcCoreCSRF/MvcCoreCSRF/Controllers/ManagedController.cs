using Microsoft.AspNetCore.Mvc;

namespace MvcCoreCSRF.Controllers
{
    public class ManagedController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            if(usuario == "admin" && password == "admin")
            {
                // Almacenamos el usuario en sesion
                HttpContext.Session.SetString("usuario", usuario);
                return RedirectToAction("Productos", "Tienda");
            } else
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrectos";
                return View();
            }
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}
