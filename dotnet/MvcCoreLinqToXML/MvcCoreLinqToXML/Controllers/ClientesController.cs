using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqToXML.Helpers;
using MvcCoreLinqToXML.Models;
using MvcCoreLinqToXML.Repositories;

namespace MvcCoreLinqToXML.Controllers
{
    public class ClientesController : Controller
    {
        private readonly RepositoryXML repositoryXML;

        public ClientesController(RepositoryXML repositoryXML)
        {
            this.repositoryXML = repositoryXML;
        }

        public IActionResult Index()
        {
            List<Cliente> clientes = this.repositoryXML.GetClientes();
            return View(clientes);
        }

        public IActionResult Details(int clienteId)
        {
            Cliente cliente = this.repositoryXML.FindCliente(clienteId);
            return View(cliente);
        }

        public IActionResult Update(int clienteId)
        {
            Cliente cliente = this.repositoryXML.FindCliente(clienteId);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Update(Cliente cliente)
        {
            this.repositoryXML.UpdateCliente(cliente.IdCliente, cliente.Nombre, cliente.Email, cliente.Direccion, cliente.Imagen);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            this.repositoryXML.CreateCliente(cliente.IdCliente, cliente.Nombre, cliente.Email, cliente.Direccion, cliente.Imagen);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int clienteId)
        {
            this.repositoryXML.DeleteCliente(clienteId);
            return RedirectToAction("Index");
        }
    }
}
