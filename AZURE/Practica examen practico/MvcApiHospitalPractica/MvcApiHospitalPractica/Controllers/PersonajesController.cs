using Microsoft.AspNetCore.Mvc;

namespace MvcApiHospitalPractica.Controllers
{
    public class PersonajesController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
