using Microsoft.AspNetCore.Mvc;
using MvcCrudDoctoresAdo.Models;
using MvcCrudDoctoresAdo.Repositories;

namespace MvcCrudDoctoresAdo.Controllers
{
    public class DoctoresController : Controller
    {
        private readonly RepositoryDoctores repo;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctores();
        }

        public IActionResult Index()
        {
            var doctores = this.repo.GetDoctores();
            var hospitales = this.repo.GetHospitales();
            ViewData["HOSPITALES"] = hospitales;
            return View(doctores);
        }

        [HttpPost]
        public IActionResult Index(string idHospital)
        {
            var doctores = this.repo.GetDoctoresHospital(idHospital);
            var hospitales = this.repo.GetHospitales();
            ViewData["HOSPITALES"] = hospitales;
            return View(doctores);
        }

        public IActionResult Delete(string id)
        {
            this.repo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(string id)
        {
            var doctor = this.repo.FindDoctor(id);
            return View(doctor);
        }

        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            this.repo.Update(doctor);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            this.repo.CreateDoctor(doctor);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var doctor = this.repo.FindDoctor(id);
            return View(doctor);
        }
    }
}
