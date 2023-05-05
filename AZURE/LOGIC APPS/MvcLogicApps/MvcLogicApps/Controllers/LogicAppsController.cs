using Microsoft.AspNetCore.Mvc;
using MvcLogicApps.Services;

namespace MvcLogicApps.Controllers
{
    public class LogicAppsController : Controller
    {
        private ServiceLogicApps serviceLogic;

        public LogicAppsController(ServiceLogicApps serviceLogic)
        {
            this.serviceLogic = serviceLogic;
        }

        public IActionResult Mail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Mail(string email, string mensaje, string asunto)
        {
            await this.serviceLogic.SendMailAsync(email, mensaje, asunto);
            ViewData["MENSAJE"] = "Procesando Mail Logic Apps!!!";
            return View();
        }
    }
}
