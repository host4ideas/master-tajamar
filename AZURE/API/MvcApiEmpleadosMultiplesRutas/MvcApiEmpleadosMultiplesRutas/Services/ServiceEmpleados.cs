using NugetApiPaco.Models;
using System.Net.Http.Headers;

namespace MvcApiEmpleadosMultiplesRutas.Services
{
    public class ServiceEmpleados
    {
        private readonly MediaTypeWithQualityHeaderValue Header;
        private readonly string ApiUrl;
        private static readonly HttpClient _httpClient = new();

        public ServiceEmpleados(IConfiguration configuration)
        {
            this.Header = new("application/json");
            this.ApiUrl = configuration.GetValue<string>("ApiUrls:ApiEmpleados");
        }

        public async Task<T?> CallApiAsync<T>(string request)
        {
            _httpClient.BaseAddress = new Uri(this.ApiUrl + request);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(this.Header);

            HttpResponseMessage response = await _httpClient.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                T data = await response.Content.ReadAsAsync<T>();
                return data;
            }

            return default;
        }

        public async Task<List<Empleado>?> GetEmpleadosAsync()
        {
            string request = "/api/empleados";
            List<Empleado>? emps = await this.CallApiAsync<List<Empleado>>(request);
            return emps;
        }

        public async Task<List<string>?> GetOficiosAsync()
        {
            string request = "/api/empleados/oficios";
            List<string>? oficios = await this.CallApiAsync<List<string>>(request);
            return oficios;
        }

        public async Task<Empleado> FindEmpleadoAsync(int idEmpleado)
        {
            string request = "/api/empleados/" + idEmpleado;
            Empleado? emp = await this.CallApiAsync<Empleado>(request);
            return emp;
        }

        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
        {
            string request = "/api/empleados/empleadosoficio/" + oficio;
            List<Empleado>? emps = await this.CallApiAsync<List<Empleado>>(request);
            return emps;
        }
    }
}
