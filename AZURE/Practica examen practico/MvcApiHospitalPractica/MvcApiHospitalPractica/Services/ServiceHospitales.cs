using ApiHospitalPractica.Models;
using MvcApiHospitalPractica.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace MvcApiHospitalPractica.Services
{
    public class ServiceHospitales
    {
        private MediaTypeWithQualityHeaderValue Header;
        private string UrlApi;
        private IHttpClientFactory HttpClientFactory;

        public ServiceHospitales(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
            this.UrlApi = configuration.GetValue<string>("ApiUrl:ApiHospital");
            this.HttpClientFactory = httpClientFactory;
        }

        public async Task<string?> GetTokenAsync(string username, int password)
        {
            using (HttpClient client = this.HttpClientFactory.CreateClient())
            {
                string request = "/api/auth/login";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                LoginModel model = new()
                {
                    Password = password,
                    Username = username,
                };

                var response = await client.PostAsJsonAsync(request, model);
                var data = await response.Content.ReadAsStringAsync();
                return JObject.Parse(data).Value<string>("response");
            }
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = this.HttpClientFactory.CreateClient())
            {
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
        }

        public async Task<T?> CallApiAsync<T>(string request, string token)
        {
            using (HttpClient client = this.HttpClientFactory.CreateClient())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

                return await client.GetFromJsonAsync<T>(request);
            }
        }

        public async Task<List<Hospital>> GetHospitalesAsync(string token)
        {
            string request = "api/Hospital";
            List<Hospital> hospitals = await this.CallApiAsync<List<Hospital>>(request, token);
            return hospitals;
        }

        public async Task<Hospital> FindHospital(int id)
        {
            string request = "api/Hospital/" + id;
            Hospital hospital = await this.CallApiAsync<Hospital>(request);
            return hospital;
        }
        //insert
        public async Task InsertHospital(int hos_cod, string nombre, string direccion, string telefono, int num_cama, string imagen)
        {
            using (HttpClient client = this.HttpClientFactory.CreateClient())
            {
                string request = "api/Hospital";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                //tenemos que enviar un objeto JSON
                //nos creamos un objeto de la clase Hospital
                Hospital hospital = new Hospital
                {
                    Hospital_cod = hos_cod,
                    Nombre = nombre,
                    Direccion = direccion,
                    Telelfono = telefono,
                    Num_cama = num_cama,
                    Imagen = imagen
                };
                //convertimos el objeto a json
                string json = JsonConvert.SerializeObject(hospital);
                //para enviar datos al servicio se utiliza 
                //la clase SytringContent, donde debemos indicar
                //los datos, de ending  y su tipo
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
            }
        }
        //update

        public async Task UpdateHospital(int hos_cod, string nombre, string direccion, string telefono, int num_cama, string imagen)
        {
            using (HttpClient client = this.HttpClientFactory.CreateClient())
            {
                string request = "api/Hospital";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                Hospital hospital = new Hospital
                {
                    Hospital_cod = hos_cod,
                    Nombre = nombre,
                    Direccion = direccion,
                    Telelfono = telefono,
                    Num_cama = num_cama,
                    Imagen = imagen
                };
                //convierto a json el objeto
                string json = JsonConvert.SerializeObject(hospital);
                //para enviar datos al servicio se utiliza 
                //la clase SytringContent, donde debemos indicar
                //los datos, de ending  y su tipo
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);

            }
        }

        //delete 

        public async Task DeleteHospital(int id)
        {
            using (HttpClient client = this.HttpClientFactory.CreateClient())
            {
                string request = "api/hospital/" + id;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.DeleteAsync(request);
            }
        }
    }
}
