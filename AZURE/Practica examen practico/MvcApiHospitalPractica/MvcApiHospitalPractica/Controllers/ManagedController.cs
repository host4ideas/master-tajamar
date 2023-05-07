using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcApiHospitalPractica.Services;
using System.Security.Claims;

namespace MvcApiHospitalPractica.Controllers
{
    public class ManagedController : Controller
    {
        private ServiceHospitales serviceHospitales;

        public ManagedController(ServiceHospitales serviceHospitales)
        {
            this.serviceHospitales = serviceHospitales;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, int password)
        {
            string? token = await this.serviceHospitales.GetTokenAsync(username, password);
            if (token == null)
            {
                ViewData["MENSAJE"] = "Usuario/password incorrectos";
            }
            else
            {
                ViewData["MENSAJE"] = "Bienvenido a mi App!!!";
                HttpContext.Session.SetString("TOKEN", token);
                ClaimsIdentity identity = new(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    ClaimTypes.Name,
                    ClaimTypes.Role);

                identity.AddClaim(new Claim(ClaimTypes.Name, username));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, password.ToString()));

                ClaimsPrincipal userPrincipal = new(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                    });
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("TOKEN");
            return RedirectToAction("Index", "Home");
        }
    }
}
