using Microsoft.AspNetCore.Mvc;
using MvcLogicApps.Services;

namespace MvcLogicApps.Controllers
{
    public class ServiceBusController : Controller
    {
        private readonly ServiceServiceBus serviceBus;

        public ServiceBusController(ServiceServiceBus serviceBus)
        {
            this.serviceBus = serviceBus;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string mensaje, string accion)
        {
            if (accion.ToLower() == "enviar")
            {
                await this.serviceBus.SendMEssageAsync(mensaje);
                ViewData["MENSAJE"] = "Mensaje enviado al Topic";
                return View();
            }
            else
            {
                List<string> mensajes = await this.serviceBus.ReceiveMessageAsync();
                ViewData["MENSAJE"] = "Recibiendo mensajes: " + mensajes.Count;
                return View(mensajes);
            }

        }
    }
}
