using ApiPracticoAWSFMB.Models;
using Microsoft.AspNetCore.Mvc;
using MvcCubosAWS.Models;
using MvcExamenPracticoAWSFMB.Services;

namespace MvcExamenPracticoAWSFMB.Controllers
{
    public class ConciertosController : Controller
    {
        private readonly ServiceConciertos serviceConciertos;
        private readonly ServiceStorageS3 serviceStorageS3;
        private readonly string BucketName;

        public ConciertosController(ServiceConciertos serviceConciertos, ServiceStorageS3 serviceStorageS3, KeysModel keysModel)
        {
            this.serviceConciertos = serviceConciertos;
            this.serviceStorageS3 = serviceStorageS3;
            this.BucketName = keysModel.BucketName;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.serviceConciertos.GetEventosAsync();
            foreach (var evento in eventos)
            { // Sirve para ambos (Public y Private)
                try
                {
                    evento.Imagen = $"https://{this.BucketName}.s3.amazonaws.com/" + evento.Imagen;
                }
                catch (Exception ex)
                {
                    evento.Imagen = null;
                }
            }
            return View(eventos);
        }

        public async Task<IActionResult> EventosCategoria(int idCategoria)
        {
            return View(nameof(Index), await this.serviceConciertos.GetEventosCategoriaAsync(idCategoria));
        }

        public async Task<IActionResult> Categorias()
        {
            return View(await this.serviceConciertos.GetCategoriasAsync());
        }

        public IActionResult CreateEvento()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvento(Evento evento, IFormFile file)
        {
            string fileName = file.FileName;
            evento.Imagen = fileName;
            await this.serviceStorageS3.UploadFileAsync(fileName, file.OpenReadStream());
            await this.serviceConciertos.CreateEventoAsync(evento);
            return RedirectToAction(nameof(Index));
        }
    }
}
