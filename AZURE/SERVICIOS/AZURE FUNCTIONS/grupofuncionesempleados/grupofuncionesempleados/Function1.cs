using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace grupofuncionesempleados
{
    public static class Function1
    {
        [FunctionName("functionlikeempleado")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string idEmpleado = req.Query["IDEMPLEADO"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            idEmpleado = idEmpleado ?? data?.idEmpleado;

            if (idEmpleado == null)
            {
                return new BadRequestObjectResult("Debe enviar el parametro: IDEMPLEADO");
            }

            string connectionString = Environment.GetEnvironmentVariable("SqlAzure");
            //string connectionString = "Data Source=sqlfmb.database.windows.net;Initial Catalog=AZURETAJAMAR;Persist Security Info=True;User ID=adminsql;Password=Admin123";

            string sqlUpdate = "UPDATE EMP SET SALARIO = SALARIO + 1 WHERE EMP_NO=" + idEmpleado;
            SqlConnection sqlConnection = new(connectionString);
            SqlCommand command = sqlConnection.CreateCommand();
            command.CommandText = sqlUpdate;
            command.CommandType = System.Data.CommandType.Text;

            await sqlConnection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            string sqlSelect = "SELECT * FROM EMP WHERE EMP_NO=" + idEmpleado;
            command.CommandText = sqlSelect;
            command.CommandType = System.Data.CommandType.Text;

            SqlDataReader reader = await command.ExecuteReaderAsync();
            string apellido = "", oficio = "";
            int salario = 0;

            if (reader.Read())
            {
                apellido = reader["APELLIDO"].ToString();
                oficio = reader["OFICIO"].ToString();
                salario = int.Parse(reader["SALARIO"].ToString());
            }

            await sqlConnection.CloseAsync();

            if (salario == 0)
            {
                return new BadRequestObjectResult("No existe el empleado " + idEmpleado);
            }
            else
            {
                return new OkObjectResult($"El empleado {apellido} con oficio {oficio} tiene un salario nuevo de {salario}");
            }
        }
    }
}
