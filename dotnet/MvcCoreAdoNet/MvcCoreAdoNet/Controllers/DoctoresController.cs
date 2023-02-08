using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctor repo;
        private RepositoryHospital repoHospital;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctor();
            this.repoHospital = new RepositoryHospital();
        }

        public IActionResult DoctoresEspecialidad()
        {
            //var doctores = this.repo.GetDoctores();
            //var especialidades = this.repo.GetEspecialidades();

            //DatosDoctor datos = new()
            //{
            //    Doctores = doctores,
            //    Especialidades = especialidades
            //};

            //return View(datos);

            var doctores = this.repo.GetDoctores();
            var especialidades = this.repo.GetEspecialidades();

            ViewData["ESPECIALIDADES"] = especialidades;

            return View(doctores);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidad(string especialidad)
        {
            //var doctores = this.repo.FindDoctorEspecialidad(especialidad);
            //var especialidades = this.repo.GetEspecialidades();

            //DatosDoctor datos = new()
            //{
            //    Doctores = doctores,
            //    Especialidades = especialidades
            //};

            //return View(datos);

            var doctores = this.repo.FindDoctorEspecialidad(especialidad);
            var especialidades = this.repo.GetEspecialidades();

            ViewData["ESPECIALIDADES"] = especialidades;

            return View(doctores);
        }


        public IActionResult DoctoresHospital()
        {
            var hospitales = this.repoHospital.GetHospitales();
            var doctores = this.repo.GetDoctores();

            ViewData["HOSPITALES"] = hospitales;
            return View(doctores);
        }

        [HttpPost]
        public IActionResult DoctoresHospital(string hospital)
        {
            var hospitales = this.repoHospital.GetHospitales();
            var doctores = this.repo.FindDoctorHospital(hospital);

            ViewData["HOSPITALES"] = hospitales;
            return View(doctores);
        }
    }
}
