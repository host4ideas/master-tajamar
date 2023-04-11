using ServicioWCFLogicaClientes.Models;
using ServicioWCFLogicaClientes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioWCFLogicaClientes
{
    public class ClientesClass : IClientesContract
    {
        private RepositoryClientes repositoryClientes;

        public ClientesClass()
        {
            this.repositoryClientes = new RepositoryClientes();
        }

        public Cliente FindCliente(int idCliente)
        {
            return this.repositoryClientes.FindCliente(idCliente);
        }

        public List<Cliente> GetClientes()
        {
            return repositoryClientes.GetClientes();
        }
    }
}
