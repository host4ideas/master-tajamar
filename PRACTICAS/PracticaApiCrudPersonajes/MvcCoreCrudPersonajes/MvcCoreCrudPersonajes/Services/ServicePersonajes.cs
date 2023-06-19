using ApiCoreCrudPersonajes.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;

namespace MvcCoreCrudPersonajes.Services
{
    public class ServicePersonajes
    {
        private readonly MediaTypeWithQualityHeaderValue Header;
        private readonly string UrlApi;

        public ServicePersonajes(IConfiguration configuration)
        {
            this.Header =
                new MediaTypeWithQualityHeaderValue("application/json");
            this.UrlApi = configuration.GetValue<string>
                ("ApiUrls:ApiPersonajes");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            string request = "/api/personajes";
            List<Personaje> personajes =
                await this.CallApiAsync<List<Personaje>>(request);
            return personajes;
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            string request = "/api/personajes/" + id;
            Personaje personaje =
                await this.CallApiAsync<Personaje>(request);
            return personaje;
        }

        public async Task DeletePersonajeAsync(int id)
        {
            using (HttpClient client = new())
            {
                string request = "/api/personajes/delete/" + id;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response =
                    await client.DeleteAsync(request);
            }
        }

        public async Task InsertPersonajeAsync
            (string nombre, string imagen)
        {
            using (HttpClient client = new())
            {
                string request = "/api/personajes/create/" + nombre + "/" + imagen;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                await client.PostAsync(request, null);
            }
        }

        public async Task UpdatePersonajeAsync(Personaje personaje)
        {
            using (HttpClient client = new())
            {
                string request = "/api/personajes/update";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                string json = JsonConvert.SerializeObject(personaje);
                StringContent content = new(json, Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }
    }
}
