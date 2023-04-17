using Microsoft.AspNetCore.Mvc;
using MvcCoreApiCrudDepartamentos.Services;

namespace MvcCoreApiCrudDoctores.Controllers
{
    public class DoctoresController : Controller
    {
        private readonly ServiceHospital serviceHospital;

        public DoctoresController(ServiceHospital serviceHospital)
        {
            this.serviceHospital = serviceHospital;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.serviceHospital.GetDoctoresAsync());
        }

        [HttpGet]
        public IActionResult CreateDoctor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(string apellido, int idHospital, string especialidad, int salario)
        {
            await this.serviceHospital.InsertDoctorAsync(apellido, idHospital, especialidad, salario);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDoctor(int id)
        {
            return View(await this.serviceHospital.FindDoctorAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(int id, string apellido, int idHospital, string especialidad, int salario)
        {
            await this.serviceHospital.UpdateDoctorAsync(id, idHospital, apellido, especialidad, salario);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.serviceHospital.FindDoctorAsync(id));
        }

        public async Task<IActionResult> RemoveDoctor(int id)
        {
            await this.serviceHospital.DeleteDoctorAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult IncrementarSalario(int id)
        {
            ViewData["ID_DOCTOR"] = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IncrementarSalario(int id, int incremento)
        {
            await this.serviceHospital.IncrementarSalarioAsync(id, incremento);
            return RedirectToAction("Index");
        }
    }
}
