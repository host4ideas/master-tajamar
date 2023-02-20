using Microsoft.AspNetCore.Mvc;
using MvcCoreEfProcedures.Models;
using MvcCoreEfProcedures.Repositories;

namespace MvcCoreEfProcedures.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryEnfermos repo;

        public EnfermosController (RepositoryEnfermos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Enfermo> enfermos = this.repo.GetEnfermos();
            return View(enfermos);
        }

        public IActionResult Details(string ins)
        {
            Enfermo enfermo = this.repo.FindEnfermo(ins);
            return View(enfermo);
        }

        public IActionResult Delete(string ins)
        {
            this.repo.DeleteEnfermo(ins);
            return RedirectToAction("Index");
        }
    }
}
