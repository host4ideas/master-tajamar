using Microsoft.AspNetCore.Mvc;
using MvcCoreSeguridadEmpleados.Filters;
using MvcCoreSeguridadEmpleados.Models;
using MvcCoreSeguridadEmpleados.Repositories;

namespace MvcCoreSeguridadEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly RepositoryHospital repositoryHospital;

        public EmpleadosController(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Empleados()
        {
            List<Empleado> empleados = await this.repositoryHospital.GetEmpleados();
            return View(empleados);
        }

        public async Task<IActionResult> DetallesEmpleado(int empleadoId)
        {
            Empleado? emp = await this.repositoryHospital.FindEmpleado(empleadoId);
            return View(emp);
        }

        public async Task<IActionResult> SubirSalarioDept()
        {
            List<Departamento> depts = await this.repositoryHospital.GetDepartamentos();
            return View(depts);
        }

        [HttpPost]
        public async Task<IActionResult> SubirSalarioDept(int deptNo, int incremento)
        {
            await this.repositoryHospital.SubirSalarioPorDept(deptNo, incremento);
            return RedirectToAction("SubirSalarioDept");
        }

        [AuthorizeEmpleados]
        public async Task<IActionResult> PerfilEmpleado(int empId)
        {
            Empleado emp = await this.repositoryHospital.FindEmpleado(empId);
            return View(emp);
        }
    }
}
