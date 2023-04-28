using ApiCoreCrudPersonajes.Models;
using ApiCoreCrudPersonajes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudPersonajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private readonly RepositoryPersonajes repository;

        public PersonajesController(RepositoryPersonajes repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.repository.GetPersonajesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await this.repository.FindPersonajeAsync(id));
        }

        [HttpPost("[action]/{nombre}/{imagen}")]
        public async Task<IActionResult> Create(string nombre, string imagen)
        {
            await this.repository.CreatePersonajeAsync(nombre, imagen);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(Personaje personaje)
        {
            await this.repository.UpdatePersonajeAsync(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.repository.DeletePersonajeAsync(id);
            return Ok();
        }
    }
}
