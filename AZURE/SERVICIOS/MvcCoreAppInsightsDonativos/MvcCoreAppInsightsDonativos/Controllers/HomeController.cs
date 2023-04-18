using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using MvcCoreAppInsightsDonativos.Models;
using System.Diagnostics;

namespace MvcCoreAppInsightsDonativos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TelemetryClient telemetryClient;

        public HomeController(ILogger<HomeController> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            this.telemetryClient = telemetryClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string usuario, int cantidad)
        {
            ViewData["MENSAJE"] = "Su donativo de " + cantidad + " ha sido aceptado. Muchas gracias Sr/Sra " + usuario;
            this.telemetryClient.TrackEvent("DonativosRequest");

            // Resumen con metricas
            MetricTelemetry metric = new()
            {
                Name = "Donativos",
                Sum = cantidad
            };
            this.telemetryClient.TrackMetric(metric);

            // Trazas
            string mesage = usuario + " " + cantidad + "€";
            SeverityLevel level;

            if (cantidad == 0)
            {
                level = SeverityLevel.Error;
            }
            else if (cantidad <= 5)
            {
                level = SeverityLevel.Critical;
            }
            else if (cantidad <= 20)
            {
                level = SeverityLevel.Warning;
            }
            else
            {
                level = SeverityLevel.Information;
            }

            TraceTelemetry trace = new(mesage, level);
            this.telemetryClient.TrackTrace(trace);

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