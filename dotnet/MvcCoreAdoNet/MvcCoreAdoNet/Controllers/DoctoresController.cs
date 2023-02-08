using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctor repo;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctor();
        }

        public IActionResult DoctoresEspecialidad()
        {
            var especialidades = this.repo.GetEspecialidades();
            var doctores = this.repo.GetDoctores();

            DatosDoctor datos = new()
            {
                Doctores = doctores,
                Especialidades = especialidades
            };

            return View(datos);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidad(string especialidad)
        {
            var doctores = this.repo.FindDoctorEspecialidad(especialidad);
            var especialidades = this.repo.GetEspecialidades();

            DatosDoctor datos = new()
            {
                Doctores = doctores,
                Especialidades = especialidades
            };

            return View(datos);
        }
    }
}
