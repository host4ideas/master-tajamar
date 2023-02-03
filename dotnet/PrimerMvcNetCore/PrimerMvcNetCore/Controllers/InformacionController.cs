using Microsoft.AspNetCore.Mvc;
using PrimerMvcNetCore.Models;

namespace PrimerMvcNetCore.Controllers
{
    public class InformacionController : Controller
    {
        [HttpGet]
        public IActionResult Index(string variable1, string variable2)
        {
            return View();
        }

        public IActionResult VistaControladorGet
            (
            string app, Nullable<int> version
            )
        {
            if (version is null)
            {
                ViewData["DATOS"] = "Solo Application: " + app;
            }
            else
            {
                ViewData["DATOS"] = "Application: " + app + ", Version: " + version.GetValueOrDefault();
            }
            return View();
        }

        public IActionResult VistaControladorPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VistaControladorPost
        (
        //string cajaNombre, string cajaEmail, int cajaEdad
        Persona persona, int inventado
        )
        {
            //ViewData["DATOS"] = "Nombre: " + cajaNombre + ", Email: " + cajaEmail + ", Edad: " + cajaEdad;
            ViewData["DATOS"] = "Nombre: " + persona.Nombre +
                ", Email: " + persona.Email +
                ", Edad: " + persona.Edad +
                ", Inventado: " + inventado;
            return View();
        }

        public IActionResult ControladorVista()
        {
            Persona persona = new()
            {
                Nombre = "Persona Model",
                Edad = 23,
                Email = "example@example.com"
            };

            ViewData["Nombre"] = "Felix";
            ViewData["Edad"] = 23;

            return View(persona);
        }
    }
}
