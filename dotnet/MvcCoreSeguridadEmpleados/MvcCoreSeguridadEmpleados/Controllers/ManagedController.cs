using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcCoreSeguridadEmpleados.Models;
using MvcCoreSeguridadEmpleados.Repositories;
using System.Security.Claims;

namespace MvcCoreSeguridadEmpleados.Controllers
{
    public class ManagedController : Controller
    {
        private readonly RepositoryHospital repositoryHospital;

        public ManagedController(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            Empleado? emp = await this.repositoryHospital.FindEmpleado(username, int.Parse(password));
            if (emp == null)
            {
                ViewData["MENSAJE"] = "Usuario/password incorrectos";
                return View();
            }

            ClaimsIdentity identity = new(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            Claim claimName = new(ClaimTypes.Name, username);
            identity.AddClaim(claimName);

            Claim claimId = new(ClaimTypes.NameIdentifier, emp.EmpNo.ToString());
            identity.AddClaim(claimId);

            Claim claimRole = new(ClaimTypes.Role, emp.Oficio);
            identity.AddClaim(claimRole);

            Claim claimSalario = new("SALARIO", emp.Salario.ToString());
            identity.AddClaim(claimSalario);

            Claim claimDept = new("DEPT", emp.DeptNo.ToString());
            identity.AddClaim(claimDept);

            ClaimsPrincipal userPrincipal = new(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

            string controller = TempData["controller"].ToString();
            string action = TempData["action"].ToString();

            return RedirectToAction(action, controller);
        }

        public IActionResult ErrorAcceso()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
