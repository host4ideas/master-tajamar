using MvcApiManagement.Models;
using System.Net.Http.Headers;
using System.Web;

namespace MvcApiManagement.Services
{
    public class ServiceApiManagement
    {
        private MediaTypeWithQualityHeaderValue Header;
        private string UrlApiEmpleados;
        private string UrlApiDepartamentos;

        public ServiceApiManagement(IConfiguration configuration)
        {
            this.Header = new("application/json");
            this.UrlApiDepartamentos = configuration.GetValue<string>("ApiUrls:ApiDepartamentos");
            this.UrlApiEmpleados = configuration.GetValue<string>("ApiUrls:ApiEmpleados");
        }

        public async Task<List<Empleado>?> GetEmpleadosAsync()
        {
            using (HttpClient client = new())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty);
                string request = "/api/empleados?" + queryString;

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");

                var response = await client.GetAsync(this.UrlApiEmpleados + request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Empleado>>();
                }

                return null;
            }
        }

        public async Task<List<Departamento>?> GetDepartamentosAsync(string subscription)
        {
            using (HttpClient client = new())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty);
                string request = "/api/departamentos?" + queryString;

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscription);

                var response = await client.GetAsync(this.UrlApiDepartamentos + request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Departamento>>();
                }

                return null;
            }
        }
    }
}
