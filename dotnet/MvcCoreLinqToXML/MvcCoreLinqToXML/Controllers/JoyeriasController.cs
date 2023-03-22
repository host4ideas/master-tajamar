using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqToXML.Models;
using MvcCoreLinqToXML.Repositories;

namespace MvcCoreLinqToXML.Controllers
{
    public class JoyeriasController : Controller
    {
        private readonly RepositoryXML repositoryXML;

        public JoyeriasController(RepositoryXML repositoryXML)
        {
            this.repositoryXML = repositoryXML;
        }

        public IActionResult Index()
        {
            List<Joyeria> joyerias = this.repositoryXML.GetJoyerias();
            return View(joyerias);
        }
    }
}
