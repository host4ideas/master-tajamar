using ServiceReference2;

namespace MvcCoreClienteWCF.Services
{
    public class ServiceClientes
    {
        private ClientesContractClient clientesContract;

        public ServiceClientes(ClientesContractClient clientesContract)
        {
            this.clientesContract = clientesContract;
        }

        public async Task<Cliente[]> GetClientesAsync()
        {
            return await this.clientesContract.GetClientesAsync();
        }

        public async Task<Cliente> FindClienteAsync(int idCliente)
        {
            return await this.clientesContract.FindClienteAsync(idCliente);
        }
    }
}
