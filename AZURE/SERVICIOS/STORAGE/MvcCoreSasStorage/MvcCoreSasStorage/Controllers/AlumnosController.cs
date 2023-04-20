using Microsoft.AspNetCore.Mvc;
using MvcCoreSasStorage.Models;
using MvcCoreSasStorage.Repositories;
using MvcCoreSasStorage.Services;

namespace MvcCoreSasStorage.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ServiceStorageTables serviceStorage;
        private readonly RepositoryXML repositoryXML;

        public AlumnosController(ServiceStorageTables serviceStorage, RepositoryXML repositoryXML)
        {
            this.serviceStorage = serviceStorage;
            this.repositoryXML = repositoryXML;
        }

        public IActionResult AlumnosXML()
        {
            return View(this.repositoryXML.GetAlumnos());
        }

        public async Task<IActionResult> AlumnosAzure()
        {
            return View(await this.serviceStorage.GetAlumnosAsync());
        }

        public IActionResult FindAlumnosCursoAzure()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindAlumnosCursoAzure(string curso)
        {
            return View(this.serviceStorage.GetAlumnosCurso(curso));
        }

        public async Task<IActionResult> SaveAlumno(int idAlumno)
        {
            Alumno? alumno = this.repositoryXML.FindAlumno(idAlumno);

            if (alumno != null)
            {
                await this.serviceStorage.SaveAlumnoAsync(alumno);
            }

            return RedirectToAction("AlumnosAzure");
        }
    }
}
