using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PracticaMvcCore2FMB.Models;
using PracticaMvcCore2FMB.Repositories;
using PracticaMvcCore2FMB.Filters;

namespace PracticaMvcCore2FMB.Controllers
{
    public class ManagedController : Controller
    {
        private RepositoryLibros repositoryLibros;

        public ManagedController(RepositoryLibros repositoryLibros)
        {
            this.repositoryLibros = repositoryLibros;
        }

        public IActionResult Login()
        {
            return View();
        }

        [AuthorizeUsers]
        public async Task<IActionResult> Profile(int userId)
        {
            AppUser? user = await this.repositoryLibros.FindUser(userId);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Pass to findUser the userId
            AppUser? user = await this.repositoryLibros.Login(email, password);

            if (user == null)
            {
                ViewData["MESSAGE"] = "Usuario/password incorrectos";
                return View();
            }

            ClaimsIdentity identity = new(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            Claim claimEmail = new(ClaimTypes.Email, user.Email);
            identity.AddClaim(claimEmail);

            Claim claimName = new(ClaimTypes.Name, user.Nombre);
            identity.AddClaim(claimName);

            Claim claimId = new(ClaimTypes.NameIdentifier, user.IdUsuario.ToString());
            identity.AddClaim(claimId);

            Claim claimImage = new("IMAGE", user.Foto);
            identity.AddClaim(claimImage);

            ClaimsPrincipal userPrincipal = new(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

            string controller = TempData["controller"].ToString();
            string action = TempData["action"].ToString();

            return RedirectToAction(action, controller);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Libros");
        }
    }
}
