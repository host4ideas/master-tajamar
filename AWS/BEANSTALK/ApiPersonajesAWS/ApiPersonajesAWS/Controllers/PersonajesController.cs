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

        [HttpGet("[action]/{id}")]
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

        [HttpPost("[action]")]
        public async Task<ActionResult> SPCreatePersonaje(Personaje personaje)
        {
            await this.repositoryPersonajes.SPCreatePersonajeAsync(personaje.Nombre, personaje.Imagen);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> SPUpdatePersonaje(Personaje personaje)
        {
            await this.repositoryPersonajes.SPUpdatePersonajeAsync(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen);
            return Ok();
        }

        [HttpDelete("[action]/{idPersonaje}")]
        public async Task<ActionResult> SPDeletePersonaje(int idPersonaje)
        {
            await this.repositoryPersonajes.SPDeletePersonajeAsync(idPersonaje);
            return Ok();
        }
    }
}
