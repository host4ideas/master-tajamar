using Microsoft.AspNetCore.Mvc;
using MvcCoreSqlOracleHospitales.Models;

namespace MvcCoreSqlOracleHospitales.Controllers
{
    public class HospitalesController : Controller
    {
        private IHospitalesRepository repo;

        public HospitalesController(IHospitalesRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Detalles(int hospcod)
        {
            Hospital hospital = this.repo.FindHospital(hospcod);
            return View(hospital);
        }

        public IActionResult Insertar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insertar(string nombre, string direccion, int numCamas, string telefono)
        {
            this.repo.CreateHospital(nombre, direccion, telefono, numCamas);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHospital(int hospCod)
        {
            this.repo.DeleteHospital(hospCod);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int hospCod)
        {
            Hospital hosp = this.repo.FindHospital(hospCod);
            return View(hosp);
        }

        [HttpPost]
        public IActionResult Update(int hospcod, string nombre, string direccion, int numCamas, string telefono)
        {
            this.repo.UpdateHospital(hospcod, nombre, direccion, telefono, numCamas);
            return RedirectToAction("Index");
        }
    }
}
