using Microsoft.Azure.Cosmos;
using MvcAzureCosmosDb.Models;

namespace MvcAzureCosmosDb.Services
{
    public class ServiceCosmosDb
    {
        private readonly CosmosClient client;
        private readonly Container containerCosmos;

        public ServiceCosmosDb(CosmosClient client, Container containerCosmos)
        {
            this.client = client;
            this.containerCosmos = containerCosmos;
        }

        public async Task CreateDatabaseAsync()
        {
            ContainerProperties properties = new("containercoches", "/id");
            await this.client.CreateDatabaseIfNotExistsAsync("vehiculoscosmos");
            await this.client.GetDatabase("vehiculoscosmos").CreateContainerIfNotExistsAsync(properties);
        }

        public async Task InsertVehiculoAsync(Vehiculo car)
        {
            // No es necesario excepto si hay mas conectores por detras
            await this.containerCosmos.CreateItemAsync(car, new PartitionKey(car.Id));
        }

        public async Task<List<Vehiculo>> GetVehiculosAsync()
        {
            var query = this.containerCosmos.GetItemQueryIterator<Vehiculo>();
            List<Vehiculo> coches = new();

            while (query.HasMoreResults)
            {
                var results = await query.ReadNextAsync();
                coches.AddRange(results);
            }

            return coches;
        }

        public async Task UpdateVehiculoAsync(Vehiculo car)
        {
            await this.containerCosmos.UpsertItemAsync(car, new PartitionKey(car.Id));
        }

        public async Task DeleteVehiculoAsync(string id)
        {
            await this.containerCosmos.DeleteItemAsync<Vehiculo>(id, new PartitionKey(id));
        }

        public async Task<Vehiculo> FindVehiculoAsync(string id)
        {
            ItemResponse<Vehiculo> car = await this.containerCosmos.ReadItemAsync<Vehiculo>(id, new PartitionKey(id));
            return car.Resource;
        }
    }
}
