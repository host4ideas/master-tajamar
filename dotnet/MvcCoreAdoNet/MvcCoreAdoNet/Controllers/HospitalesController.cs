using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
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

        public IActionResult Detalles(int idHospital)
        {
            var hospital = this.repo.FindHospital(idHospital);
            return View(hospital);
        }

        public IActionResult CreateHospital()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateHospital(Hospital hospital)
        {
            this.repo.CreateHospital(hospital.IdHospital, hospital.HospitalName, hospital.Direccion, hospital.Telefono, hospital.Camas);

            ViewData["MENSAJE"] = "Hospital creado correctamente";
            return View();
        }
    }
}
