using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MvcCoreSeguridadPersonalizada.Controllers
{
    public class ManagedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username.ToLower() == "admin" && password.ToLower() == "admin")
            {
                ClaimsIdentity identity = new
                    (
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        ClaimTypes.Name, ClaimTypes.Role
                    );
                Claim claimUserName = new(ClaimTypes.Name, username);
                Claim claimRole = new(ClaimTypes.Role, "ROLE");

                identity.AddClaim(claimUserName);
                identity.AddClaim(claimRole);

                ClaimsPrincipal userPrincipal = new(identity);

                await HttpContext.SignInAsync
                    (
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddMinutes(15) }
                    );

                return RedirectToAction("Perfil", "Usuarios");
            }
            else
            {
                ViewData["ERROR"] = "Credenciales incorrectas";
            }
            return View();
        }
    
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync
                (
                    CookieAuthenticationDefaults.AuthenticationScheme
                );
            return RedirectToAction("Index", "Home");
        }
    }
}
