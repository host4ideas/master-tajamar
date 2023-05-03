using MvcApiTokenEmpleados.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MvcApiTokenEmpleados.Services
{
    public class ServiceEmpleados
    {
        private MediaTypeWithQualityHeaderValue Header;
        private string UrlApiEmpleados;

        public ServiceEmpleados(IConfiguration configuration)
        {
            this.UrlApiEmpleados = configuration.GetValue<string>("ApiUrls:ApiOAuthEmpleados");
            this.Header = new("application/json");
        }

        public async Task<string?> GetTokenAsync(string username, string password)
        {
            using (HttpClient client = new())
            {
                string request = "/api/auth/login";
                client.BaseAddress = new Uri(this.UrlApiEmpleados);
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

        public async Task<T?> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new())
            {
                client.BaseAddress = new Uri(this.UrlApiEmpleados);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                var response = await client.GetAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }

                return default;
            }
        }

        public async Task<T?> CallApiAsync<T>(string request, string token)
        {
            using (HttpClient client = new())
            {
                client.BaseAddress = new Uri(this.UrlApiEmpleados);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

                return await client.GetFromJsonAsync<T>(request);
            }
        }

        public async Task<List<Empleado>?> GetEmpleadosAsync(string token)
        {
            string request = "/api/empleados";
            return await this.CallApiAsync<List<Empleado>>(request, token);
        }

        public async Task<Empleado?> FindEmpleadoAsync(int idEmpleado)
        {
            string request = "/api/empleados/" + idEmpleado;
            return await this.CallApiAsync<Empleado>(request);
        }

        public async Task<Empleado> GetPerfilEmpleadoAsync(string token)
        {
            string request = "/api/empleados/perfilempleado";
            Empleado empleado = await this.CallApiAsync<Empleado>(request, token);
            return empleado;
        }

        public async Task<List<Empleado>> GetCompisCurroAsync(string token)
        {
            string request = "/api/empleados/compiscurro";
            List<Empleado> compis = await this.CallApiAsync<List<Empleado>>(request, token);
            return compis;
        }
    }
}
