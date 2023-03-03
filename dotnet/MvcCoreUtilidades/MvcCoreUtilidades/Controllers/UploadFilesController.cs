using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;
using System.Net.Mime;

namespace MvcCoreUtilidades.Controllers
{
    public class UploadFilesController : Controller
    {
        private HelperPathProvider helperPath;

        private IHttpContextAccessor contextAccessor;

        public UploadFilesController(HelperPathProvider helperPath, IHttpContextAccessor contextAccessor)
        {
            this.helperPath = helperPath;
            this.contextAccessor = contextAccessor;
        }

        public IActionResult SubirFichero()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirFichero(IFormFile fichero)
        {
            string tempFolder = Path.GetTempPath();
            string fileName = fichero.FileName;

            string path = helperPath.MapPath(fileName, Folders.Uploads);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }
            ViewData["MENSAJE"] = "Fichero subido a: " + path;
            //ViewData["UPLOADED_PATH"] = Path.Combine(this.contextAccessor.HttpContext., fileName);
            return View();
        }
    }
}
