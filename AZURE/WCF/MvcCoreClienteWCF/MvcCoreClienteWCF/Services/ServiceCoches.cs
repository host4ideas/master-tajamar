using ServiceReference1;

namespace MvcCoreClienteWCF.Services
{
    public class ServiceCoches
    {
        private ServiceReference1.CochesContractClient client;

        public ServiceCoches(ServiceReference1.CochesContractClient client)
        {
            this.client = client;
        }

        public async Task<Coche[]> GetCochesAsync()
        {
            return await this.client.GetCochesAsync();
        }

        public async Task<Coche> FindCocheAsync(int idCoche)
        {
            return await this.client.FindCocheAsync(idCoche);
        }
    }
}
