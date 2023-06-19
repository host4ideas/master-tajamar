using MvcCubosAWS.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcCubosAWS.Services {
    public class ServiceCubos {

        private MediaTypeWithQualityHeaderValue header;
        private string UrlApi;

        public ServiceCubos(IConfiguration configuration, KeysModel keysModel) {
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
            this.UrlApi = keysModel.ApiUrl;
        }

        #region GENERAL
        private async Task<T> CallApiAsync<T>(string request) {
            using (HttpClient client = new HttpClient()) {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                string url = this.UrlApi + request;

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                } else {
                    return default(T);
                }
            }
        }
        #endregion 

        #region CRUD
        public async Task<Cubo> FindCuboAsync(int id) {
            string request = "/api/cubos/" + id;
            Cubo cubo = await this.CallApiAsync<Cubo>(request);
            return cubo;
        }

        public async Task<List<Cubo>> GetCubosAsync() {
            string request = "/api/cubos";
            List<Cubo> cubos = await this.CallApiAsync<List<Cubo>>(request);
            return cubos;
        }

        public async Task CreateCuboAsync(Cubo cubo) {
            using (HttpClient client = new HttpClient()) {
                string request = "/api/cubos";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                string json = JsonConvert.SerializeObject(cubo);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(this.UrlApi + request, content);
            }
        }

        public async Task UpdateCubosAsync(Cubo cubo) {
            using (HttpClient client = new HttpClient()) {
                string request = "/api/cubos";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                string json = JsonConvert.SerializeObject(cubo);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(this.UrlApi + request, content);
            }
        }
        
        public async Task DeleteAsync(int id) {
            using (HttpClient client = new HttpClient()) {
                string request = "/api/cubos/" + id;
                await client.DeleteAsync(this.UrlApi + request);
            }
        }
        #endregion
    }
}