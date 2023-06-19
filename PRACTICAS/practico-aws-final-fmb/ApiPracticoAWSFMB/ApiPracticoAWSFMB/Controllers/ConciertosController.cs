using ApiPracticoAWSFMB.Models;
using ApiPracticoAWSFMB.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPracticoAWSFMB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConciertosController : ControllerBase
    {
        private readonly RepositoryConciertos repositoryConciertos;

        public ConciertosController(RepositoryConciertos repositoryConciertos)
        {
            this.repositoryConciertos = repositoryConciertos;
        }

        [HttpGet]
        public async Task<List<Evento>> Eventos()
        {
            return await this.repositoryConciertos.GetEventosAsync();
        }

        [HttpGet]
        public async Task<List<CategoriaEvento>> Categorias()
        {
            return await this.repositoryConciertos.GetCategoriasAsync();
        }

        [HttpGet("{idCategoria}")]
        public async Task<List<Evento>> Eventos(int idCategoria)
        {
            return await this.repositoryConciertos.GetEventosCategoriaAsync(idCategoria);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvento(Evento evento)
        {
            await this.repositoryConciertos.CreateEventoAsync(evento.Nombre, evento.Artista, evento.IdCategoria, evento.Imagen);
            return NoContent();
        }
    }
}
