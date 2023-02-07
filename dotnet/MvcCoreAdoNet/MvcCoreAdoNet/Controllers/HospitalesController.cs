using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class HospitalesController : Controller
    {
        private readonly RepositoryHospital repo;

        public HospitalesController()
        {
            this.repo = new RepositoryHospital();
        }

        public IActionResult Index()
        {
            var hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }
    }
}
