using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF.Services;

namespace MvcCoreClienteWCF.Controllers
{
    public class ConversorController : Controller
    {
        private readonly ServiceConversor service;

        public ConversorController(ServiceConversor service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
