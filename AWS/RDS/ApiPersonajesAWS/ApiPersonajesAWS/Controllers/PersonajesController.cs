using ApiPersonajesAWS.Models;
using ApiPersonajesAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private readonly RepositoryPersonajes repositoryPersonajes;

        public PersonajesController(RepositoryPersonajes repositoryPersonajes)
        {
            this.repositoryPersonajes = repositoryPersonajes;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repositoryPersonajes.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje?>> FindPersonaje(int id)
        {
            return await this.repositoryPersonajes.FindPersonajeAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePersonaje(Personaje personaje)
        {
            await this.repositoryPersonajes.CreatePersonajeAsync(personaje.Nombre, personaje.Imagen);

            return Ok();
        }
    }
}
