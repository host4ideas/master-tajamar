using Azure.Data.Tables;
using MvcCoreSasStorage.Models;
using Newtonsoft.Json.Linq;
using System.Net;

namespace MvcCoreSasStorage.Services
{
    public class ServiceAzureAlumnos
    {
        private TableClient tableAlumnos;
        private readonly string UrlApi;

        public ServiceAzureAlumnos(IConfiguration configuration)
        {
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiTableTokens");
        }

        public async Task<List<Alumno>> GetAlumnosAsync(string token)
        {
            Uri uriToken = new(token);
            this.tableAlumnos = new TableClient(uriToken);
            List<Alumno> alumnos = new();
            var consulta = this.tableAlumnos.QueryAsync<Alumno>(filter: "");
            await foreach (var alumno in consulta)
            {
                alumnos.Add(alumno);
            }
            return alumnos;
        }

        public async Task<string> GetTokenAsync(string curso)
        {
            using WebClient client = new();
            string request = "api/tabletoken/generatetoken/" + curso;
            client.Headers["content-type"] = "application/json";
            Uri uri = new(this.UrlApi + request);
            string data = await client.DownloadStringTaskAsync(uri);
            JObject objectoJSON = JObject.Parse(data);
            string token = objectoJSON.GetValue("token").ToString();
            return token;
        }
    }
}
