using Microsoft.AspNetCore.Mvc;
using MvcAzureCosmosDb.Models;
using MvcAzureCosmosDb.Services;

namespace MvcAzureCosmosDb.Controllers
{
    public class CochesController : Controller
    {
        private readonly ServiceCosmosDb serviceCosmos;

        public CochesController(ServiceCosmosDb serviceCosmos)
        {
            this.serviceCosmos = serviceCosmos;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string accion)
        {
            await this.serviceCosmos.CreateDatabaseAsync();
            ViewData["MENSAJE"] = "Recursos creados en Azre Cosmos DB";
            return View();
        }

        public async Task<IActionResult> Vehiculos()
        {
            return View(await this.serviceCosmos.GetVehiculosAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehiculo car)
        {
            await this.serviceCosmos.InsertVehiculoAsync(car);
            return RedirectToAction("Vehiculos");
        }

        public async Task<IActionResult> Details(string id)
        {
            return View(await this.serviceCosmos.FindVehiculoAsync(id));
        }

        public async Task<IActionResult> Update(string id)
        {
            return View(await this.serviceCosmos.FindVehiculoAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Vehiculo car)
        {
            await this.serviceCosmos.UpdateVehiculoAsync(car);
            return RedirectToAction("Vehiculos");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.serviceCosmos.DeleteVehiculoAsync(id);
            return RedirectToAction("Vehiculos");
        }
    }
}
