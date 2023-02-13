using Microsoft.AspNetCore.Mvc;
using NetCoreLinqToSql.Models;
using NetCoreLinqToSql.Repositories;

namespace NetCoreLinqToSql.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosController()
        {
            this.repo = new RepositoryEmpleados();
        }

        public IActionResult Index()
        {
            var empleados = this.repo.GetEmpleados();
            return View(empleados);
        }

        public IActionResult DatosEmpleados()
        {
            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;
            return View();
        }

        [HttpPost]
        public IActionResult DatosEmpleados(string oficio)
        {
            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;

            ResumenEmpleados model = this.repo.GetEmpleadosOficios(oficio);

            return View(model);
        }

        public IActionResult Details(int idEmpleado)
        {
            var empleado = this.repo.FindEmpleado(idEmpleado);
            return View(empleado);
        }

        public IActionResult BuscadorEmpleados()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscadorEmpleados(string oficio, int salario)
        {
            List<Empleado> empleados = this.repo.GetEmpleados(oficio, salario);

            if (empleados == null)
            {
                ViewData["MENSAJE"] = "No existen empleados con oficio " + oficio + " o salario superior a " + salario;
                return View();
            }

            return View(empleados);
        }
    }
}
