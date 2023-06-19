using ApiSegundaPractica.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcSegundaPractica.Services;
using System.Security.Claims;

namespace MvcApiHospitalPractica.Controllers
{
    public class ManagedController : Controller
    {
        private ServiceSegundaPractica service;

        public ManagedController(ServiceSegundaPractica service)
        {
            this.service = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            string? token = await this.service.GetTokenAsync(email, password);
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

                identity.AddClaim(new Claim(ClaimTypes.Name, email));
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
