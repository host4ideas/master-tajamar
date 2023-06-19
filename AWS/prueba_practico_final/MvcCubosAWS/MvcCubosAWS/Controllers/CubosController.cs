using Microsoft.AspNetCore.Mvc;
using MvcCubosAWS.Models;
using MvcCubosAWS.Services;

namespace MvcCubosAWS.Controllers {
    public class CubosController : Controller {

        private ServiceCubos service;
        private ServiceStorageS3 serviceS3;

        public CubosController(ServiceCubos service, ServiceStorageS3 serviceS3) {
            this.service = service;
            this.serviceS3 = serviceS3;
        }

        public async Task<IActionResult> Index() {
            List<Cubo> cubos = await this.service.GetCubosAsync();
            foreach (var cubo in cubos) { // Sirve para ambos (Public y Private)
                try {
                    using (Stream imageStream = await this.serviceS3.GetFileAsync(cubo.Imagen)) {
                        using (MemoryStream memoryStream = new MemoryStream()) {
                            await imageStream.CopyToAsync(memoryStream);
                            byte[] bytes = memoryStream.ToArray();
                            string base64Image = Convert.ToBase64String(bytes);
                            cubo.Imagen = "data:image;base64," + base64Image;
                        }
                    }
                } catch (Exception ex) {
                    cubo.Imagen = null;
                }
            }
            return View(cubos);
        }

        public async Task<IActionResult> Details(int id) {
            Cubo? cubo = await this.service.FindCuboAsync(id);
            return View(cubo);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cubo cubo, IFormFile file) {
            cubo.Imagen = file.FileName;
            using (Stream stream = file.OpenReadStream()) {
                await this.serviceS3.UploadFileAsync(cubo.Imagen, stream);
            }
            await this.service.CreateCuboAsync(cubo);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Update(int id) {
            Cubo? cubo = await this.service.FindCuboAsync(id);
            return View(cubo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Cubo cubo) {
            await this.service.UpdateCubosAsync(cubo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) {
            await this.service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
