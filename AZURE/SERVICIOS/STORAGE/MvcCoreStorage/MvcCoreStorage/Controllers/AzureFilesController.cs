using Microsoft.AspNetCore.Mvc;
using MvcCoreStorage.Services;
using System.Text;

namespace MvcCoreStorage.Controllers
{
    public class AzureFilesController : Controller
    {
        private readonly ServiceStorageFiles service;

        public AzureFilesController(ServiceStorageFiles service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<string> files = await this.service.GetFilesAsync();
            return View(files);
        }

        public async Task<IActionResult> DeleteFile(string fileName)
        {
            await this.service.DeleteFilesAsync(fileName);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ReadFile(string fileName)
        {
            var data = await this.service.ReadFileAsync(fileName);

            ViewData["CONTENT"] = data.Item1;
            
            if (data.Item2.StartsWith("image"))
            {
                ViewData["CONTENT"] = File(Encoding.ASCII.GetBytes(data.Item1), "image/jpeg");
            }

            ViewData["CONTENT_TYPE"] = data.Item2;
            return View();
        }

        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            string fileName = file.FileName;
            using (Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync(fileName, stream);
            }
            ViewData["MENSAJE"] = "Fichero subido correctamente";
            return View();
        }
    }
}
