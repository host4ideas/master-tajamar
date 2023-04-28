using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcApiTokenEmpleados.Services;
using System.Security.Claims;

namespace MvcApiTokenEmpleados.Controllers
{
    public class ManagedController : Controller
    {
        private ServiceEmpleados serviceEmpleados;

        public ManagedController(ServiceEmpleados serviceEmpleados)
        {
            this.serviceEmpleados = serviceEmpleados;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            string? token = await this.serviceEmpleados.GetTokenAsync(username, password);
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
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, password));

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
