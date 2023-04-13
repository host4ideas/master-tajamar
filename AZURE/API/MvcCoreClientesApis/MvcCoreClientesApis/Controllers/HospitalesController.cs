using Microsoft.AspNetCore.Mvc;
using MvcCoreClientesApis.Models;
using MvcCoreClientesApis.Services;

namespace MvcCoreClientesApis.Controllers
{
    public class HospitalesController : Controller
    {
        private ServiceHospital serviceHospital;

        public HospitalesController(ServiceHospital serviceHospital)
        {
            this.serviceHospital = serviceHospital;
        }

        public async Task<IActionResult> Servidor()
        {
            List<Hospital> hospitales = await this.serviceHospital.GetHospitalesAsync();
            return View(hospitales);
        }
    }
}
