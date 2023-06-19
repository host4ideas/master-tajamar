using MvcApiPersonajesAWS.Models;

namespace MvcApiPersonajesAWS.Services
{
    public class ServiceApiPersonajes
    {
        private string UrlApi;
        private string UrlApiEC2;
        private readonly IHttpClientFactory HttpClientFactory;

        public ServiceApiPersonajes(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiPersonajes");
            this.UrlApiEC2 = configuration.GetValue<string>("ApiUrls:ApiPersonajesEC2");
            HttpClientFactory = httpClientFactory;
        }

        private async Task<T?> CallApiAsync<T>(string urlApi, string request)
        {
            using HttpClient httpClient = HttpClientFactory.CreateClient();

            httpClient.BaseAddress = new Uri(urlApi);
            var response = await httpClient.GetAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            return await response.Content.ReadAsAsync<T>();
        }

        private async Task<T?> CallApiNoSSLAsync<T>(string urlApi, string request)
        {

            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }
            };

            HttpClient httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(urlApi)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
            var response = await httpClient.GetAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            return await response.Content.ReadAsAsync<T>();
        }

        private async Task PostApiNoSSLAsync(string urlApi, string request, object body)
        {
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }
            };

            HttpClient httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(urlApi)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
            var response = await httpClient.PostAsJsonAsync(request, body);
        }

        private async Task PutApiNoSSLAsync(string urlApi, string request, object body)
        {
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }
            };

            HttpClient httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(urlApi)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));
            var response = await httpClient.PutAsJsonAsync(request, body);
        }

        private async Task DeleteApiNoSSLAsync(string urlApi, string request)
        {
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                }
            };

            HttpClient httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(urlApi)
            };
            var response = await httpClient.DeleteAsync(request);
        }

        public async Task<List<Personaje>?> GetPersonajesAsync()
        {
            return await this.CallApiAsync<List<Personaje>>(this.UrlApi, "/api/personajes");
        }

        public async Task<List<Personaje>?> GetPersonajesEC2Async()
        {
            return await this.CallApiNoSSLAsync<List<Personaje>>(this.UrlApiEC2, "/api/personajes");
        }

        public async Task SPDeletePersonajeAsync(int id)
        {
            await this.DeleteApiNoSSLAsync(UrlApiEC2, "/api/Personajes/SPDeletePersonaje/" + id);
        }

        public async Task SPCreatePersonajeAsync(string nombre, string imagen)
        {
            await this.PostApiNoSSLAsync(UrlApiEC2, "/api/Personajes/SPCreatePersonaje", new Personaje()
            {
                IdPersonaje = 0,
                Imagen = imagen,
                Nombre = nombre
            });
        }

        public async Task SPUpdatePersonajeAsync(int id, string nombre, string imagen)
        {
            await this.PutApiNoSSLAsync(UrlApiEC2, "/api/Personajes/SPUpdatePersonaje", new Personaje()
            {
                IdPersonaje = id,
                Imagen = imagen,
                Nombre = nombre
            });
        }

        public async Task<Personaje?> FindPersonajeAsync(int id)
        {
            return await this.CallApiNoSSLAsync<Personaje>(UrlApiEC2, "/api/Personajes/FindPersonaje/" + id);
        }
    }
}
