using ApiCoreCrudPersonajes.Data;
using ApiCoreCrudPersonajes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudPersonajes.Repositories
{
    public class RepositoryPersonajes
    {
        private readonly PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje?> FindPersonajeAsync(int idPersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idPersonaje);
        }

        public async Task DeletePersonajeAsync(int idPersonaje)
        {
            Personaje? personaje = await this.FindPersonajeAsync(idPersonaje);

            if (personaje != null)
            {
                this.context.Personajes.Remove(personaje);
                await this.context.SaveChangesAsync();
            }
        }

        private async Task<int> GetMaxPersonajeAsync()
        {
            return await this.context.Personajes.MaxAsync(x => x.IdPersonaje) + 1;
        }

        public async Task CreatePersonajeAsync(string nombre, string imagen)
        {
            await this.context.Personajes.AddAsync(new()
            {
                Imagen = imagen,
                Nombre = nombre,
                IdPersonaje = await this.GetMaxPersonajeAsync()
            });

            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync(int idPersonaje, string nombre, string imagen)
        {
            Personaje? personaje = await this.FindPersonajeAsync(idPersonaje);

            if (personaje != null)
            {
                personaje.Nombre = nombre;
                personaje.Imagen = imagen;

                await this.context.SaveChangesAsync();
            }
        }
    }
}
