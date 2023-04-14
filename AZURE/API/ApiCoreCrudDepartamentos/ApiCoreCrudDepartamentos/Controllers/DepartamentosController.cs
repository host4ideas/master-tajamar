using ApiCoreCrudDepartamentos.Models;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repositoryDepartamentos;

        public DepartamentosController(RepositoryDepartamentos repositoryDepartamentos)
        {
            this.repositoryDepartamentos = repositoryDepartamentos;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamentos()
        {
            return await this.repositoryDepartamentos.GetDepartamentosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> FindDepartamento(int id)
        {
            var dept = await this.repositoryDepartamentos.FindDepartamentoAsync(id);
            if (dept == null)
            {
                return NotFound();
            }

            return Ok(dept);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InsertarDepartamento(Departamento departamento)
        {
            try
            {
                await this.repositoryDepartamentos.InsertarDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeleteDepartamento(int id)
        {
            try
            {
                await this.repositoryDepartamentos.DeleteDepartamentoAsync(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task<ActionResult> UpdateDepartamento(int id, string nombre, string localidad)
        {
            try
            {
                await this.repositoryDepartamentos.UpdateDepartamento(id, nombre, localidad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
