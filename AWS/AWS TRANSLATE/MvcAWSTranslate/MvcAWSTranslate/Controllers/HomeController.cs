using Microsoft.AspNetCore.Mvc;
using MvcAWSTranslate.Models;
using MvcAWSTranslate.Services;
using System.Diagnostics;

namespace MvcAWSTranslate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ServiceTextModeration textModeration;

        public HomeController(ILogger<HomeController> logger, ServiceTextModeration textModeration)
        {
            _logger = logger;
            this.textModeration = textModeration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                ViewData["MODERATED_TEXT"] = await this.textModeration.TranslatingTextAsync(text);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}