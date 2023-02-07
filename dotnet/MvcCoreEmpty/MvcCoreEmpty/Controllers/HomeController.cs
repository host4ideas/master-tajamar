using Microsoft.AspNetCore.Mvc;
using MvcCoreEmpty.Models;

namespace MvcCoreEmpty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contenido()
        {
            return View();
        }

        public IActionResult VistaPersona()
        {
            return View(new Persona(nombre: "Alumno Core", edad: 23, email: "example@tajamar365.com"));
        }
    }
}
