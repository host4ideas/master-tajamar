using Microsoft.AspNetCore.Mvc;
using MvcCorePaginacionRegistros.Models;
using MvcCorePaginacionRegistros.Repositories;

namespace MvcCorePaginacionRegistros.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly RepositoryEmpleados repositoryEmpleados;

        public DepartamentosController(RepositoryEmpleados repositoryEmpleados)
        {
            this.repositoryEmpleados = repositoryEmpleados;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int deptNo)
        {
            List<Empleado> dept = this.repositoryEmpleados.GetEmpleadosDept(deptNo);
            return View(dept);
        }
    }
}
