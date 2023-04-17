using MvcCoreApiCrudDoctores.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcCoreApiCrudDepartamentos.Services
{
    public class ServiceHospital
    {
        private readonly MediaTypeWithQualityHeaderValue Header;
        private readonly string UrlApi;

        public ServiceHospital(IConfiguration configuration)
        {
            this.Header =
                new MediaTypeWithQualityHeaderValue("application/json");
            this.UrlApi = configuration.GetValue<string>
                ("ApiUrls:ApiCrudDoctoresLocal");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            string request = "/api/doctores";
            List<Doctor> doctores =
                await this.CallApiAsync<List<Doctor>>(request);
            return doctores;
        }

        public async Task<Doctor> FindDoctorAsync(int id)
        {
            string request = "/api/doctores/" + id;
            Doctor doctor =
                await this.CallApiAsync<Doctor>(request);
            return doctor;
        }

        //LOS METODOS DE ACCION NO SUELEN SER GENERICOS,
        //YA QUE NORMALMENTE, CADA UNO RECIBE DISTINTOS PARAMETROS
        public async Task DeleteDoctorAsync(int id)
        {
            using (HttpClient client = new())
            {
                string request = "/api/doctores/" + id;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                //NO NECESITA EL HEADER PORQUE NO DEVUELVE NADA
                HttpResponseMessage response =
                    await client.DeleteAsync(request);
                //SI DESEAMOS PERSONALIZAR LA EXPERIENCIA DEVOLVIENDO
                //ALGUN VALOR PARA LA PETICION
                //return response.StatusCode;
            }
        }

        public async Task InsertDoctorAsync
            (string apellido, int idHospital, string especialidad, int salario)
        {
            using (HttpClient client = new())
            {
                string request = "/api/doctores";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                //TENEMOS QUE ENVIAR UN OBJETO JSON
                //NOS CREAMOS UN OBJETO DE LA CLASE DEPARTAMENTO
                Doctor doctor = new()
                {
                    Apellido = apellido,
                    Especialidad = especialidad,
                    IdHospital = idHospital,
                    Salario = salario,
                    Id = 0 // Auto generates
                };
                //CONVERTIMOS EL OBJETO A JSON
                string json = JsonConvert.SerializeObject(doctor);
                //PARA ENVIAR DATOS (data) AL SERVICIO SE UTILIZA
                //LA CLASE StringContent, DONDE DEBEMOS INDICAR
                //LOS DATOS, SU ENCODING Y SU TIPO
                StringContent content = new(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(request, content);
            }
        }

        public async Task UpdateDoctorAsync(int id, int idHospital, string apellido, string especialidad, int salario)
        {
            using (HttpClient client = new())
            {
                string request = "/api/doctores";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Doctor doctor =
                    new()
                    {
                        Id = id,
                        IdHospital = idHospital,
                        Especialidad = especialidad,
                        Apellido = apellido,
                        Salario = salario
                    };
                string json = JsonConvert.SerializeObject(doctor);
                StringContent content = new(json, Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }

        public async Task IncrementarSalarioAsync
            (int id, int incremento)
        {
            using (HttpClient client = new())
            {
                string request = "/api/doctores/incremento-salario/" + id + "/" + incremento;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                await client.PutAsync(request, null);
            }
        }
    }
}
