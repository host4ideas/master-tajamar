using ApiComicsMySql.Models;
using ApiComicsMySql.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiComicsMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly RepositoryComics repositoryComics;

        public ComicsController(RepositoryComics repositoryComics)
        {
            this.repositoryComics = repositoryComics;
        }

        [HttpGet]
        public async Task<List<Comic>> GetComics()
        {
            return await this.repositoryComics.GetComicsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Comic?> FindComic(int id)
        {
            return await this.repositoryComics.FindComicAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Comic comic)
        {

            await this.repositoryComics.CreateComicAsync(comic.Nombre, comic.Imagen);
            return CreatedAtAction(null, null);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateComic(Comic comic)
        {
            await this.repositoryComics.UpdateComicAsync(comic.Id, comic.Nombre, comic.Imagen);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComic(int id)
        {
            await this.repositoryComics.DeleteComicAsync(id);
            return NoContent();
        }
    }
}
