using Microsoft.AspNetCore.Mvc;
using MvcApiManagement.Models;
using MvcApiManagement.Services;

namespace MvcApiManagement.Controllers
{
    public class ApiManagementController : Controller
    {
        private readonly ServiceApiManagement serviceApiManagement;

        public ApiManagementController(ServiceApiManagement serviceApiManagement)
        {
            this.serviceApiManagement = serviceApiManagement;
        }

        public async Task<IActionResult> Empleados()
        {
            List<Empleado> data = await this.serviceApiManagement.GetEmpleadosAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Departamentos()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Departamentos(string suscripcion)
        {
            List<Departamento> depts = await this.serviceApiManagement.GetDepartamentosAsync(suscripcion);
            return View(depts);
        }
    }
}
