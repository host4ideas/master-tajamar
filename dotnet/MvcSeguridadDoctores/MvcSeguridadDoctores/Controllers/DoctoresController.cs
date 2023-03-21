using Microsoft.AspNetCore.Mvc;
using MvcSeguridadDoctores.Filters;
using MvcSeguridadDoctores.Models;
using MvcSeguridadDoctores.Repositories;

namespace MvcSeguridadDoctores.Controllers
{
    public class DoctoresController : Controller
    {
        private readonly RepositoryDoctores repositoryDoctores;

        public DoctoresController(RepositoryDoctores repositoryDoctores)
        {
            this.repositoryDoctores = repositoryDoctores;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AuthorizeDoctores(Policy = "ADMIN_ONLY")]
        public IActionResult AdminDoctores()
        {
            return View();
        }


        [AuthorizeDoctores]
        public IActionResult Perfil()
        {
            return View();
        }
    }
}
