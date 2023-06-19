using ApiHospitalPractica.Models;
using ApiSegundaPractica.Models;
using Azure.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Net.Http.Headers;
using System.Text;

namespace MvcSegundaPractica.Services
{
    public class ServiceSegundaPractica
    {
        private MediaTypeWithQualityHeaderValue Header;
        private string UrlApi;
        private IHttpClientFactory HttpClientFactory;

        public ServiceSegundaPractica(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.Header = new("application/json");
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiSegundaPractica");
            this.HttpClientFactory = httpClientFactory;
        }

        public async Task<string?> GetTokenAsync(string email, string password)
        {
            using HttpClient client = HttpClientFactory.CreateClient();

            string request = "/api/auth/login";
            client.BaseAddress = new Uri(this.UrlApi);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(this.Header);

            LoginModel model = new()
            {
                Email = email,
                Password = password
            };

            var response = await client.PostAsJsonAsync(request, model);
            var data = await response.Content.ReadAsStringAsync();
            return JObject.Parse(data).Value<string>("response");
        }

        private async Task<T?> CallApiAsync<T>(string request)
        {
            using HttpClient client = HttpClientFactory.CreateClient();

            client.BaseAddress = new Uri(this.UrlApi);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(this.Header);
            HttpResponseMessage response = await client.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                T data = await response.Content.ReadAsAsync<T>();
                return data;
            }
            else
            {
                return default;
            }
        }

        public async Task<T?> CallApiAsync<T>(string request, string token)
        {
            using HttpClient client = HttpClientFactory.CreateClient();

            client.BaseAddress = new Uri(this.UrlApi);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            return await client.GetFromJsonAsync<T>(request);
        }

        public async Task<List<Cubo>?> GetCubosAsync()
        {
            return await CallApiAsync<List<Cubo>?>("/api/cubos");
        }

        public async Task<List<Cubo>?> GetCubosMarcaAsync(string marca)
        {
            return await CallApiAsync<List<Cubo>?>("api/cubos/" + marca);
        }

        public async Task RegisterUserAsync(InsertUserModel newUser)
        {
            using HttpClient client = HttpClientFactory.CreateClient();

            client.BaseAddress = new Uri(this.UrlApi);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(this.Header);

            string request = "/api/cubos/registeruser/";
            string json = JsonConvert.SerializeObject(newUser);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(request, content);
        }

        public async Task InsertarCuboAsync(InsertCuboModel newCubo)
        {
            using HttpClient client = HttpClientFactory.CreateClient();

            client.BaseAddress = new Uri(this.UrlApi);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(this.Header);

            string request = "/api/cubos/insertarcubo/";
            string json = JsonConvert.SerializeObject(newCubo);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(request, content);
        }

        public async Task<Usuario?> GetPerfilUsuarioAsync(string token)
        {
            string request = "/api/cubos/profile/";
            return await CallApiAsync<Usuario?>(request, token);
        }

        public async Task<List<CompraCubo>?> GetPedidosUsuarioAsync(string token)
        {
            string request = "/api/cubos/getuserpedidos/";
            return await CallApiAsync<List<CompraCubo>?>(request, token);
        }

        public async Task RealizarPedidoAsync(InsertCompraModel newPedido, string token)
        {
            using HttpClient client = HttpClientFactory.CreateClient();

            client.BaseAddress = new Uri(this.UrlApi);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(this.Header);
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            string request = "/api/cubos/realizarpedido/";
            string json = JsonConvert.SerializeObject(newPedido);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(request, content);
        }
    }
}
