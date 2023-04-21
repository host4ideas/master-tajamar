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
        private ServiceAzureAlumnos serviceAzureAlumnos;

        public AlumnosController(ServiceStorageTables serviceStorage, RepositoryXML repositoryXML, ServiceAzureAlumnos serviceAzureAlumnos)
        {
            this.serviceStorage = serviceStorage;
            this.repositoryXML = repositoryXML;
            this.serviceAzureAlumnos = serviceAzureAlumnos;
        }

        public IActionResult Token()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Token(string curso)
        {
            if (curso != null)
            {
                ViewData["TOKEN"] = await this.serviceAzureAlumnos.GetTokenAsync(curso);
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string token)
        {
            if (token != null)
            {
                List<Alumno> alumnos = await this.serviceAzureAlumnos.GetAlumnosAsync(token);
                return View(alumnos);
            }

            return View();
        }

        #region MIGRATION ACTIONS


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
            if (curso == null)
            {
                return View();
            }
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

        public async Task<IActionResult> DeleteAlumnoAzure(string partitionKey, string rowKey)
        {
            await this.serviceStorage.DeleteAlumnoAsync(partitionKey, rowKey);
            return RedirectToAction("AlumnosAzure");
        }
    }

    #endregion
}
