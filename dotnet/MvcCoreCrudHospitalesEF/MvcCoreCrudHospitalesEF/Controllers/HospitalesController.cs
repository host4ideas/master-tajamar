using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudHospitalesEF.Models;
using MvcCoreCrudHospitalesEF.Repositories;

namespace MvcCoreCrudHospitalesEF.Controllers
{
    public class HospitalesController : Controller
    {
        private HospitalesRepository repo;

        public HospitalesController(HospitalesRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Details(int id)
        {
            Hospital hosp = this.repo.FindHospital(id);
            return View(hosp);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.repo.DeleteHospital(id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string direccion, string telefono, int camas)
        {
            await this.repo.InsertHospital(nombre, direccion, telefono, camas);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Hospital hosp = this.repo.FindHospital(id);
            return View(hosp);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Hospital hospital)
        {
            await this.repo.UpdateHospital(hospital);
            return RedirectToAction("Index");
        }
    }
}
