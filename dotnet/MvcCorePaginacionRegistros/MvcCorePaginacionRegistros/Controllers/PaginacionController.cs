using Microsoft.AspNetCore.Mvc;
using MvcCorePaginacionRegistros.Models;
using MvcCorePaginacionRegistros.Repositories;

namespace MvcCorePaginacionRegistros.Controllers
{
    public class PaginacionController : Controller
    {
        private RepositoryDepartamentos repositoryDepartamentos;
        private RepositoryEmpleados repositoryEmpleados;

        public PaginacionController(RepositoryDepartamentos repositoryDepartamentos, RepositoryEmpleados repositoryEmpleados)
        {
            this.repositoryDepartamentos = repositoryDepartamentos;
            this.repositoryEmpleados = repositoryEmpleados;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmpleadosProcedure(string? oficio, int posicion = 1)
        {
            if (oficio != null)
            {
                List<Empleado> empleados = this.repositoryEmpleados.GetEmpleadosProcedure(oficio, posicion);
                ViewData["NUM_REGISTROS"] = empleados.Count;
                ViewData["OFICIO"] = oficio;
                return View(empleados);
            }
            return View();
        }

        [HttpPost]
        public IActionResult EmpleadosProcedure(string oficio, int posicion = 1)
        {
            List<Empleado> empleados = this.repositoryEmpleados.GetEmpleadosProcedure(oficio, posicion);
            ViewData["NUM_REGISTROS"] = empleados.Count;
            ViewData["OFICIO"] = oficio;
            return View(empleados);
        }

        public async Task<IActionResult> PaginarGrupoEmpleados(int posicion = 1)
        {
            int numRegistros = this.repositoryEmpleados.GetNumeroRegistrosVistaEmpleados();
            ViewData["NUM_REGISTROS"] = numRegistros;
            List<Empleado> emps = await this.repositoryEmpleados.GetGrupoEmpleadosAsync(posicion);
            return View(emps);
        }

        public async Task<IActionResult> PaginarGrupoDepartamentos(int posicion = 1)
        {
            int numRegistros = this.repositoryDepartamentos.GetNumeroRegistrosVistaDepartamentos();
            ViewData["NUM_REGISTROS"] = numRegistros;
            List<Departamento> depts = await this.repositoryDepartamentos.GetGrupoDepartamentosAsync(posicion);
            return View(depts);
        }

        public async Task<IActionResult> PaginarGrupoVistaDepartamento(int posicion = 1)
        {
            int numeroRegistros = this.repositoryDepartamentos.GetNumeroRegistrosVistaDepartamentos();

            List<VistaDepartamento> depts = await this.repositoryDepartamentos.GetGrupoVistaDepartamento(posicion);

            ViewData["NUM_REGISTROS"] = numeroRegistros;

            return View(depts);
        }

        public async Task<IActionResult> PaginarRegistroVistaDepartamentos(int posicion = 1)
        {
            int numeroRegistros = this.repositoryDepartamentos.GetNumeroRegistrosVistaDepartamentos();

            int siguiente = posicion + 1;

            if (siguiente > numeroRegistros)
            {
                siguiente = 1;
            }

            int anterior = posicion - 1;

            if (anterior < 1)
            {
                anterior = numeroRegistros;
            }

            VistaDepartamento? vistaDepartamento = await this.repositoryDepartamentos.GetVistaDepartamento(posicion);
            ViewData["ULTIMO"] = numeroRegistros;
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;

            return View(vistaDepartamento);
        }
    }
}
