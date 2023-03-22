using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MvcSeguridadDoctores.Models;
using MvcSeguridadDoctores.Repositories;

namespace MvcSeguridadDoctores.Controllers
{
    public class ManagedController : Controller
    {
        private readonly RepositoryDoctores repositoryDoctores;

        public ManagedController(RepositoryDoctores repositoryDoctores)
        {
            this.repositoryDoctores = repositoryDoctores;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            Doctor? doctor = await this.repositoryDoctores.FindDoctor(username, int.Parse(password));
            if (doctor == null)
            {
                ViewData["MENSAJE"] = "Usuario/password incorrectos";
                return View();
            }

            ClaimsIdentity identity = new(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            identity.AddClaim(new Claim(ClaimTypes.Name, username));

            identity.AddClaim(new Claim(ClaimTypes.Role, doctor.Especialidad));

            identity.AddClaim(new Claim("SALARIO", doctor.Salario.ToString()));

            if (doctor.DoctorNo == 982)
            {
                identity.AddClaim(new Claim("ADMIN", "Soy el admin"));
            }

            ClaimsPrincipal userPrincipal = new(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

            string controller = TempData["controller"].ToString();
            string action = TempData["action"].ToString();
            string insc = TempData["insc"].ToString();

            return RedirectToAction(action, controller, new { insc });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ErrorAcceso()
        {
            return View();
        }
    }
}
