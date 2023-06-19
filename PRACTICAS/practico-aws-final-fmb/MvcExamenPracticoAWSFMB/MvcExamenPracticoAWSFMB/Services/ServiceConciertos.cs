using ApiPracticoAWSFMB.Models;
using MvcCubosAWS.Models;
using System.Net.Http.Headers;

namespace MvcExamenPracticoAWSFMB.Services
{
    public class ServiceConciertos
    {
        private readonly IHttpClientFactory HttpClientFactory;
        private MediaTypeWithQualityHeaderValue header;
        private string UrlApi;

        public ServiceConciertos(IConfiguration configuration, IHttpClientFactory HttpClientFactory, KeysModel keysModel)
        {
            this.HttpClientFactory = HttpClientFactory;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
            this.UrlApi = keysModel.UrlApi;
        }

        #region GENERAL
        private async Task<T?> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                string url = this.UrlApi + request;

                HttpResponseMessage response = await client.GetAsync(url);
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
        }
        #endregion

        public async Task<List<Evento>?> GetEventosAsync()
        {
            string request = "/api/Conciertos/Eventos";
            return await this.CallApiAsync<List<Evento>>(request);
        }

        public async Task<List<CategoriaEvento>?> GetCategoriasAsync()
        {
            string request = "/api/conciertos/categorias";
            return await this.CallApiAsync<List<CategoriaEvento>>(request);
        }

        public async Task<List<Evento>?> GetEventosCategoriaAsync(int idCategoria)
        {
            string request = "/api/conciertos/eventos/" + idCategoria;
            return await this.CallApiAsync<List<Evento>>(request);
        }

        public async Task CreateEventoAsync(Evento evento)
        {
            using HttpClient client = HttpClientFactory.CreateClient();

            string request = "/api/conciertos/CreateEvento";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(this.header);

            //string json = JsonConvert.SerializeObject(evento);

            //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync(this.UrlApi + request, content);
            HttpResponseMessage response = await client.PostAsJsonAsync<Evento>(this.UrlApi + request, evento);
        }
    }
}
