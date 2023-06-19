using ApiPracticoAWSFMB.Data;
using ApiPracticoAWSFMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPracticoAWSFMB.Repositories
{
    public class RepositoryConciertos
    {
        private readonly ConciertosContext conciertosContext;

        public RepositoryConciertos(ConciertosContext conciertosContext)
        {
            this.conciertosContext = conciertosContext;
        }

        public async Task<List<CategoriaEvento>> GetCategoriasAsync()
        {
            return await this.conciertosContext.CategoriasEvento.ToListAsync();
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            return await this.conciertosContext.Eventos.ToListAsync();
        }

        public async Task<List<Evento>> GetEventosCategoriaAsync(int idCategoria)
        {
            return await this.conciertosContext.Eventos.Where(x => x.IdCategoria == idCategoria).ToListAsync();
        }

        private async Task<int> GetMaxEventoAsync()
        {
            if (!await this.conciertosContext.Eventos.AnyAsync())
            {
                return 1;
            }

            return await this.conciertosContext.Eventos.MaxAsync(x => x.Id) + 1;
        }

        public async Task CreateEventoAsync(string nombre, string artista, int idCategoria, string imagen)
        {
            await this.conciertosContext.Eventos.AddAsync(new()
            {
                Id = await this.GetMaxEventoAsync(),
                Artista = artista,
                IdCategoria = idCategoria,
                Imagen = imagen,
                Nombre = nombre,
            });

            await this.conciertosContext.SaveChangesAsync();
        }
    }
}
