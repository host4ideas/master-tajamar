using Microsoft.AspNetCore.Mvc;
using ServiceCountries;

namespace MvcCoreClienteWCF.Controllers
{
    public class CountriesController : Controller
    {
        private readonly Services.ServiceCountries service;

        public CountriesController(Services.ServiceCountries service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            tCountryCodeAndName[] countries = await this.service.GetCountriesAsync();
            return View(countries);
        }

        public async Task<IActionResult> Details(string isoCode)
        {
            tCountryInfo info = await this.service.GetCountryInfoAsync(isoCode);
            return View(info);
        }
    }
}
