using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Repositories
{
    public class RepositoryPersonajes
    {
        private readonly PersonajesContext personajesContext;

        public RepositoryPersonajes(PersonajesContext personajesContext)
        {
            this.personajesContext = personajesContext;
        }

        public Task<List<Personaje>> GetPersonajesAsync()
        {
            return this.personajesContext.Personajes.ToListAsync();
        }

        public async Task<Personaje?> FindPersonajeAsync(int id)
        {
            return await this.personajesContext.Personajes.FindAsync(id);
        }

        public async Task CreatePersonajeAsync(string nombre, string imagen)
        {
            await this.personajesContext.Personajes.AddAsync(new()
            {
                IdPersonaje = await GetMaxPersonajeAsync(),
                Imagen = imagen,
                Nombre = nombre,
            });

            await this.personajesContext.SaveChangesAsync();
        }

        private async Task<int> GetMaxPersonajeAsync()
        {
            return await this.personajesContext.Personajes.MaxAsync(x => x.IdPersonaje) + 1;
        }
    }
}
