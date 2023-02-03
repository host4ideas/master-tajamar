using Microsoft.AspNetCore.Mvc;

namespace PrimerMvcNetCore.Controllers
{
    public class MatematicasController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult SumarNumerosGet(int num1, int num2)
        {
            ViewData["RESULTADO"] = num1 + num2;
            return View();
        }

        public IActionResult SumarNumerosPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SumarNumerosPost(int num1, int num2)
        {
            ViewData["RESULTADO"] = num1 + num2;
            return View();
        }
    }
}
