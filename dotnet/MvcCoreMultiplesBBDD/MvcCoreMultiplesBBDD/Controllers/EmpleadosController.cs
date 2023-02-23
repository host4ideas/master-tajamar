using Microsoft.AspNetCore.Mvc;
using MvcCoreMultiplesBBDD.Models;
using MvcCoreMultiplesBBDD.Repositories;

namespace MvcCoreMultiplesBBDD.Controllers
{
    public class EmpleadosController : Controller
    {
        private IRepositoryEmpleados repo;

        public EmpleadosController(IRepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }

        public IActionResult Details(int idEmpleado)
        {
            Empleado emp = this.repo.EmpleadoDetails(idEmpleado);
            return View(emp);
        }

        public async Task<IActionResult> Delete(int idEmpleado)
        {
            await this.repo.DeleteEmpleado(idEmpleado);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int idEmpleado)
        {
            Empleado emp = this.repo.FindEmpleado(idEmpleado);
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int idEmpleado, int salario, string oficio)
        {
            await this.repo.UpdateEmpleado(idEmpleado, salario, oficio);
            return RedirectToAction("Edit", new { idEmpleado });
        }
    }
}
