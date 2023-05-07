using Microsoft.AspNetCore.Mvc;
using MvcApiHospitalPractica.Filters;
using MvcApiHospitalPractica.Models;
using MvcApiHospitalPractica.Services;

namespace MvcApiHospitalPractica.Controllers
{
    public class HospitalController : Controller
    {
        private ServiceHospitales service;
        private ServiceStorageBlob storageBlob;

        public HospitalController(ServiceHospitales service, ServiceStorageBlob serviceStorageBlob)
        {
            this.service = service;
            this.storageBlob = serviceStorageBlob;
        }

        [AuthorizeEmpleados]
        public async Task<IActionResult> Index()
        {
            List<Hospital> hospitales = new();
            string? token = HttpContext.Session.GetString("TOKEN");

            if (token == null)
            {
                ViewData["MENSAJE"] = "Debe realizar login para visualizar datos";
            }
            else
            {
                hospitales = await this.service.GetHospitalesAsync(token);

                foreach (var hospital in hospitales)
                {
                    if (hospital.Imagen != null)
                    {
                        hospital.Imagen = await this.storageBlob.GetBlobUriAsync("blobimages", hospital.Imagen);
                    }
                }
            }

            return View(hospitales);
        }
        public async Task<IActionResult> Details(int id)
        {
            Hospital hospital = await this.service.FindHospital(id);
            return View(hospital);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHospital hospital)
        {
            string image = hospital.Nombre.ToLower();

            if (hospital.Imagen != null)
            {
                using (Stream stream = hospital.Imagen.OpenReadStream())
                {
                    await this.storageBlob.UploadBlobAsync("blobimages", image, stream);
                }
            }

            await this.service.InsertHospital(hospital.Hospital_cod, hospital.Nombre, hospital.Direccion, hospital.Telelfono, hospital.Num_cama, image);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Hospital hospital = await this.service.FindHospital(id);
            return View(hospital);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateHospital hospital)
        {
            string image = hospital.Nombre.ToLower();

            using (Stream stream = hospital.Imagen.OpenReadStream())
            {
                await this.storageBlob.UploadBlobAsync("blobimages", image, stream);
            }

            await this.service.UpdateHospital(hospital.Hospital_cod, hospital.Nombre, hospital.Direccion, hospital.Telelfono, hospital.Num_cama, image);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeleteHospital(id);
            return RedirectToAction("Index");
        }

    }
}
