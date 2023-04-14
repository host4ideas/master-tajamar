using ApiEmpleadosMultiplesRutas.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetApiPaco.Models;

namespace ApiEmpleadosMultiplesRutas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> GetEmpleadosAsync()
        {
            return await this.repo.GetEmpleadosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> FindEmpeladosAsync(int id)
        {
            return await this.repo.FindEmpleadoAsync(id);
        }

        //api/empleados/oficios
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> Oficios()
        {
            return await this.repo.GetOficiosAsync();
        }

        [HttpGet]
        [Route("[action]/{oficio}")]
        public async Task<ActionResult<List<Empleado>>> EmpleadosOficios(string oficio)
        {
            return await this.repo.GetEmpleadosOficioAsync(oficio);
        }

        [HttpGet]
        [Route("[action]/{salario}/{iddepartamento}")]
        public async Task<ActionResult<List<Empleado>>> EmpleadosOficios(int salario, int iddepartamento)
        {
            return await this.repo.GetEmpleadosSalarioAsync(salario, iddepartamento);
        }

    }
}
