using Microsoft.EntityFrameworkCore;
using MvcDockerComics.Data;
using MvcDockerComics.Models;

namespace MvcDockerComics.Repositories
{
    public class RepositoryComics
    {
        private ComicsContext context;

        public RepositoryComics(ComicsContext context)
        {
            this.context = context;
        }

        public Task<List<Comic>> GetComicsAsync()
        {
            return this.context.Comics.ToListAsync();
        }

        public Task<Comic?> FindComicAsync(int idComic)
        {
            return this.context.Comics.FirstOrDefaultAsync(x => x.IdComic == idComic);
        }

        public async Task<int> GetMaxComicAsync()
        {
            return await this.context.Comics.MaxAsync(x => x.IdComic) + 1;
        }

        public async Task InsertComicAsync(string nombre, string imagen)
        {
            await this.context.Comics.AddAsync(new Comic()
            {
                IdComic = await this.GetMaxComicAsync(),
                Imagen = imagen,
                Nombre = nombre,
            });

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteComicAsync(int idComic)
        {
            Comic? comic = await this.FindComicAsync(idComic);
            if (comic != null)
            {
                this.context.Comics.Remove(comic);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
