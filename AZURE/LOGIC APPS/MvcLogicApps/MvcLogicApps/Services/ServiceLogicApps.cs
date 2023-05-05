using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcLogicApps.Services
{
    public class ServiceLogicApps
    {
        private readonly MediaTypeWithQualityHeaderValue Header;
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceLogicApps(IHttpClientFactory httpClientFactory)
        {
            this.Header =
                new MediaTypeWithQualityHeaderValue("application/json");
            this._httpClientFactory = httpClientFactory;
        }

        public async Task SendMailAsync
            (string email, string asunto, string mensaje)
        {
            string urlEmail = "";

            var model = new
            {
                email,
                asunto,
                mensaje
            };

            using HttpClient client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(this.Header);
            string json = JsonConvert.SerializeObject(model);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            await client.PostAsync(urlEmail, content);
        }
    }
}
