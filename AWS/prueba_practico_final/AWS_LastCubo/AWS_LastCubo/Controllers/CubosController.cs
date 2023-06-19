using AWS_LastCubo.Models;
using AWS_LastCubo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AWS_LastCubo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase {

        private RepositoryCubo repo;

        public CubosController(RepositoryCubo repo) {
            this.repo = repo;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCubo(Cubo cubo) {
            await this.repo.UpdateCuboAsync(cubo.Id, cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return NoContent();
        }

        [HttpGet]
        public async Task<List<Cubo>> GetCubos() {
            return await this.repo.GetCubosAsync();
        }

        [HttpGet("{marca}")]
        public async Task<List<Cubo>> FindCubosMarca(string marca) {
            return await this.repo.FindCuboMarcaAsync(marca);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCubo(Cubo cubo) {
            await this.repo.CreateCuboAsync(cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCubo(int id) {
            await this.repo.DeleteCuboAsync(id);
            return Ok();
        }

    }
}
