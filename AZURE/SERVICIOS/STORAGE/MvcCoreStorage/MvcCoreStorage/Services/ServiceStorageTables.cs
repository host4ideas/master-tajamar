using Azure;
using Azure.Data.Tables;
using MvcCoreStorage.Models;

namespace MvcCoreStorage.Services
{
    public class ServiceStorageTables
    {
        private readonly TableClient tableClient;

        public ServiceStorageTables(TableServiceClient tableServiceClient)
        {
            this.tableClient = tableServiceClient.GetTableClient("clientes");
            Task.Run(async () => await this.tableClient.CreateIfNotExistsAsync());

            //this.tableClient.CreateIfNotExistsAsync().GetAwaiter().GetResult();
        }

        public async Task CreateClienteAsync(int id, string nombre, int salario, int edad, string empresa)
        {
            Cliente cliente = new()
            {
                IdCliente = id,
                Empresa = empresa,
                Edad = edad,
                Nombre = nombre,
                Salario = salario,
            };

            await this.tableClient.AddEntityAsync<Cliente>(cliente);
        }

        public Task<Response<Cliente>> FindClIenteAsync(string partitionKey, string rowKey)
        {
            return this.tableClient.GetEntityAsync<Cliente>(partitionKey, rowKey);
        }

        public async Task DeleteClienteAsync(string partitionKey, string rowKey)
        {
            await this.tableClient.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            List<Cliente> clientes = new();
            var query = this.tableClient.QueryAsync<Cliente>(filter: "");
            await foreach (var cliente in query)
            {
                clientes.Add(cliente);
            }
            return clientes;
        }

        public async Task<List<Cliente>> GetClientesEmpresaAsync(string empresa)
        {
            var query = this.tableClient.Query<Cliente>(x => x.Empresa == empresa);
            //var query = this.tableClient.QueryAsync<Cliente>(filter: "Empresa eq " + empresa);
            return query.ToList();
        }
    }
}
