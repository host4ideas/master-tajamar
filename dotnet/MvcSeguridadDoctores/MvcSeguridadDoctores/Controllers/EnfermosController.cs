using Microsoft.AspNetCore.Mvc;
using MvcSeguridadDoctores.Filters;
using MvcSeguridadDoctores.Models;
using MvcSeguridadDoctores.Repositories;

namespace MvcSeguridadDoctores.Controllers
{
    public class EnfermosController : Controller
    {
        private readonly RepositoryEnfermo repositoryEnfermo;

        public EnfermosController(RepositoryEnfermo repositoryEnfermo)
        {
            this.repositoryEnfermo = repositoryEnfermo;
        }

        public async Task<IActionResult> Enfermos()
        {
            List<Enfermo> enfermos = await this.repositoryEnfermo.GetEnfermos();
            return View(enfermos);
        }

        [AuthorizeDoctores(Policy = "PERMISOS_ELEVADOS")]
        public async Task<IActionResult> DeleteEnfermo(string insc)
        {
            await this.repositoryEnfermo.DeleteEnfermo(insc);
            return RedirectToAction("Enfermos", "Enfermos");
        }
    }
}
