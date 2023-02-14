using Microsoft.AspNetCore.Mvc;
using NetCoreLinqToSqlInjection.Models;
using NetCoreLinqToSqlInjection.Repositories;

namespace NetCoreLinqToSqlInjection.Controllers
{
    public class DoctoresController : Controller
    {
        private IRepository repo;

        public DoctoresController(IRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        public IActionResult InsertarDoctor()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult InsertarDoctor(string HospitalCod, string Apellido, string Especialidad, int Salario)
        {
            this.repo.InsertarDoctor(HospitalCod, Apellido, Especialidad, Salario);
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }
    }
}
