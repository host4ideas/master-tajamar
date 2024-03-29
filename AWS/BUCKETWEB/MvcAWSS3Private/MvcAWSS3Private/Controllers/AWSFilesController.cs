﻿using Microsoft.AspNetCore.Mvc;
using MvcAWSS3Private.Services;

namespace MvcAWSS3Private.Controllers
{
    public class AWSFilesController : Controller
    {
        private ServiceStorageS3 service;

        //COMO NUESTRO BUCKET ES PUBLICO, VAMOS A MOSTRAR
        //LAS IMAGENES EN LA PAGINA INDEX
        private string BucketUrl;
        public AWSFilesController
            (ServiceStorageS3 service, IConfiguration configuration)
        {
            this.BucketUrl = configuration.GetValue<string>("AWS:BucketUrl");
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            //List<string> filesS3 = await this.service.GetVersionsFilesAsync();
            ViewData["BUCKETURL"] = this.BucketUrl;
            return View(new List<string>());
        }

        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            using (Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync(file.FileName, stream);
            }
            return RedirectToAction("Index");
        }

        //SI DESEAMOS VISUALIZAR EL FICHERO POR SI FUERA PRIVADO
        public async Task<IActionResult> FileAWS(string fileName)
        {
            Stream stream = await this.service.GetFileAsync(fileName);
            return File(stream, "image/png");
        }

        public async Task<IActionResult> DeleteFile(string fileName)
        {
            await this.service.DeleteFileAsync(fileName);
            return RedirectToAction("Index");
        }
    }
}
