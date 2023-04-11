using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF.Services;
using ServiceReference2;

namespace MvcCoreClienteWCF.Controllers
{
    public class ClientesController : Controller
    {
        private ServiceClientes serviceClientes;

        public ClientesController(ServiceClientes serviceClientes)
        {
            this.serviceClientes = serviceClientes;
        }

        public async Task<IActionResult> Index()
        {
            Cliente[] clientes = await this.serviceClientes.GetClientesAsync();
            return View(clientes);
        }

        public async Task<IActionResult> Details(int idCliente)
        {
            Cliente cliente = await this.serviceClientes.FindClienteAsync(idCliente);
            return View(cliente);
        }
    }
}
