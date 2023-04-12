using Microsoft.AspNetCore.Mvc;
using MvcWebJobChollometro.Models;
using MvcWebJobChollometro.Repositories;

namespace MvcWebJobChollometro.Controllers
{
    public class ChollometroController : Controller
    {
        private readonly RepositoryChollos repositoryChollos;

        public ChollometroController(RepositoryChollos repositoryChollos)
        {
            this.repositoryChollos = repositoryChollos;
        }

        public async Task<IActionResult> Index()
        {
            List<Chollo> chollos = await this.repositoryChollos.GetChollosAsync();
            return View(chollos);
        }
    }
}
