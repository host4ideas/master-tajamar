using Microsoft.AspNetCore.Mvc;
using MvcApiTokenEmpleados.Filters;
using MvcApiTokenEmpleados.Models;
using MvcApiTokenEmpleados.Services;

namespace MvcApiTokenEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ServiceEmpleados serviceEmpleados;

        public EmpleadosController(ServiceEmpleados serviceEmpleados)
        {
            this.serviceEmpleados = serviceEmpleados;
        }

        [AuthorizeEmpleados]
        public async Task<IActionResult> Index()
        {
            string? token = HttpContext.Session.GetString("TOKEN");
            List<Empleado>? empleados = null;

            if (token == null)
            {
                ViewData["MENSAJE"] = "Debe realizar login para visualizar datos";
            }
            else
            {
                empleados = await this.serviceEmpleados.GetEmpleadosAsync(token);
            }
            return View(empleados);
        }

        public async Task<IActionResult> Details(int idEmpleado)
        {
            return View(await this.serviceEmpleados.FindEmpleadoAsync(idEmpleado));
        }
    }
}
