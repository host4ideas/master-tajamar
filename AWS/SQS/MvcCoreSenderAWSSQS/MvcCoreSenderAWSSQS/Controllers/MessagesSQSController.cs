using Microsoft.AspNetCore.Mvc;
using MvcCoreSenderAWSSQS.Models;
using MvcCoreSenderAWSSQS.Services;

namespace MvcCoreSenderAWSSQS.Controllers
{
    public class MessagesSQSController : Controller
    {
        private readonly ServiceSQS serviceSQS;

        public MessagesSQSController(ServiceSQS serviceSQS)
        {
            this.serviceSQS = serviceSQS;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Mensaje mensaje)
        {
            await this.serviceSQS.SendMessageAsync(mensaje);
            ViewData["MENSAJE"] = "Mensaje enviado correctamente a SQS";
            return View();
        }
    }
}
