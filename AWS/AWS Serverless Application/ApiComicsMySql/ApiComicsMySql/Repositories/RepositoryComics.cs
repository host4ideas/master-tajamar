using ApiComicsMySql.Data;
using ApiComicsMySql.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComicsMySql.Repositories
{
    public class RepositoryComics
    {
        private readonly ComicsContext comicsContext;

        public RepositoryComics(ComicsContext comicsContext)
        {
            this.comicsContext = comicsContext;
        }

        public Task<List<Comic>> GetComicsAsync()
        {
            return this.comicsContext.Comics.ToListAsync();
        }

        public async Task<Comic?> FindComicAsync(int id)
        {
            return await this.comicsContext.Comics.FindAsync(id);
        }

        private async Task<int> GetMaxComicAsync()
        {
            if (!await comicsContext.Comics.AnyAsync())
            {
                return 1;
            }
            return await this.comicsContext.Comics.MaxAsync(x => x.Id) + 1;
        }

        public async Task CreateComicAsync(string nombre, string imagen)
        {
            await this.comicsContext.Comics.AddAsync(new()
            {
                Id = await this.GetMaxComicAsync(),
                Imagen = imagen,
                Nombre = nombre
            });

            await this.comicsContext.SaveChangesAsync();
        }

        public async Task UpdateComicAsync(int id, string nombre, string imagen)
        {
            Comic? comic = await this.FindComicAsync(id);
            if (comic != null)
            {
                comic.Nombre = nombre;
                comic.Imagen = imagen;
                await this.comicsContext.SaveChangesAsync();
            }
        }

        public async Task DeleteComicAsync(int id)
        {
            Comic? comic = await this.FindComicAsync(id);
            if (comic != null)
            {
                this.comicsContext.Comics.Remove(comic);
                await this.comicsContext.SaveChangesAsync();
            }
        }
    }
}
