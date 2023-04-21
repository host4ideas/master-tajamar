using Azure.Data.Tables;
using Azure;
using MvcCoreSasStorage.Models;

namespace MvcCoreSasStorage.Services
{
    public class ServiceStorageTables
    {
        private readonly TableClient tableClient;

        public ServiceStorageTables(TableServiceClient tableServiceClient)
        {
            this.tableClient = tableServiceClient.GetTableClient("alumnos");
            Task.Run(async () => await this.tableClient.CreateIfNotExistsAsync());
        }

        public async Task CreateAlumnoAsync(int idAlumno, string nombre, string apellidos, string curso, int nota)
        {
            Alumno alumno = new()
            {
                Apellidos = apellidos,
                Curso = curso,
                Nota = nota,
                IdAlumno = idAlumno,
                Nombre = nombre,
            };

            await this.tableClient.AddEntityAsync(alumno);
        }

        public async Task SaveAlumnoAsync(Alumno alumno)
        {
            await this.tableClient.AddEntityAsync(alumno);
        }

        public Task<Response<Alumno>> FindAlumnoAsync(string partitionKey, string rowKey)
        {
            return this.tableClient.GetEntityAsync<Alumno>(partitionKey, rowKey);
        }

        public async Task DeleteAlumnoAsync(string partitionKey, string rowKey)
        {
            await this.tableClient.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task<List<Alumno>> GetAlumnosAsync()
        {
            List<Alumno> alumnos = new();
            var query = this.tableClient.QueryAsync<Alumno>(filter: "");
            await foreach (var alumno in query)
            {
                alumnos.Add(alumno);
            }
            return alumnos;
        }

        public List<Alumno>? GetAlumnosCurso(string curso)
        {
            if (curso != null)
            {
                var query = this.tableClient.Query<Alumno>(x => x.Curso == curso);
                return query.ToList();
            }
            return null;
        }
    }
}
