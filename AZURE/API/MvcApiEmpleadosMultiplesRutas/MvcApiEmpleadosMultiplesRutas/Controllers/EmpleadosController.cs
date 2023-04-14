using Microsoft.AspNetCore.Mvc;
using MvcApiEmpleadosMultiplesRutas.Services;
using NugetApiPaco.Models;

namespace MvcApiEmpleadosMultiplesRutas.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ServiceEmpleados service;

        public EmpleadosController(ServiceEmpleados service)
        {
            this.service = service;
        }

        public async Task<IActionResult> EmpleadosOficios()
        {
            List<Empleado>? emps = await this.service.GetEmpleadosAsync();
            List<string>? oficios = await this.service.GetOficiosAsync();
            ViewData["OFICIOS"] = oficios;
            return View(emps);
        }

        [HttpPost]
        public async Task<IActionResult> EmpleadosOficios(string oficio)
        {
            List<Empleado>? emps = await this.service.GetEmpleadosOficioAsync(oficio);
            List<string>? oficios = await this.service.GetOficiosAsync();
            ViewData["OFICIOS"] = oficios;
            return View(emps);
        }

        public async Task<IActionResult> Details(int id)
        {
            Empleado? emp = await this.service.FindEmpleadoAsync(id);
            return View(emp);
        }
    }
}
