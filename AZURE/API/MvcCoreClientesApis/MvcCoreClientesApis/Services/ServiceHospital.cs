using Microsoft.AspNetCore.Mvc;
using MvcCoreClientesApis.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MvcCoreClientesApis.Services
{
    public class ServiceHospital
    {
        private readonly MediaTypeWithQualityHeaderValue Header;
        private readonly string UrlAPI;
        static readonly HttpClient client = new();

        public ServiceHospital(IConfiguration configuration)
        {
            this.Header = new("application/json");
            this.UrlAPI = configuration.GetValue<string>("ApiUrls:ApiHospitales");
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            client.BaseAddress = new Uri(this.UrlAPI);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(this.Header);

            HttpResponseMessage response = await client.GetAsync(this.UrlAPI + "/api/hospitales");
            if (response.IsSuccessStatusCode)
            {
                List<Hospital> data = await response.Content.ReadAsAsync<List<Hospital>>();

                //string json = await response.Content.ReadAsStringAsync();
                //List<Hospital> hospitales = JsonConvert.DeserializeObject<List<Hospital>>(json);

                return data;
            }
            else
            {
                return null;
            }
        }
    }
}
