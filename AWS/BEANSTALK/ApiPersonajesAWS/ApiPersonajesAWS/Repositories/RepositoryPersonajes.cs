using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MySqlConnector;
using System.Xml.Linq;

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

        public async Task SPCreatePersonajeAsync(string nombre, string imagen)
        {
            string sql = "CALL SP_CREATE_PERSONAJE(@NOMBRE,@IMAGEN)";

            MySqlParameter paramName = new("@NOMBRE", nombre);
            MySqlParameter paramImagen = new("@IMAGEN", imagen);

            await this.personajesContext.Database.ExecuteSqlRawAsync(sql, paramName, paramImagen);
        }

        public async Task SPUpdatePersonajeAsync(int id, string nombre, string imagen)
        {
            string sql = "CALL SP_UPDATE_PERSONAJE(@P_ID,@P_NOMBRE,@P_IMAGEN)";

            MySqlParameter paramId = new("@P_ID", id);
            MySqlParameter paramName = new("@P_NOMBRE", nombre);
            MySqlParameter paramImagen = new("@P_IMAGEN", imagen);

            await this.personajesContext.Database.ExecuteSqlRawAsync(sql, paramId, paramName, paramImagen);
        }

        public async Task SPDeletePersonajeAsync(int id)
        {
            string sql = "CALL SP_DELETE_PERSONAJE(@P_ID)";

            MySqlParameter paramId = new("@P_ID", id);

            await this.personajesContext.Database.ExecuteSqlRawAsync(sql, paramId);
        }
    }
}
