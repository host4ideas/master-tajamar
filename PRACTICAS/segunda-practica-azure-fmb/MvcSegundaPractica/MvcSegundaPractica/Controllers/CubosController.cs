using ApiSegundaPractica.Models;
using Microsoft.AspNetCore.Mvc;
using MvcApiHospitalPractica.Filters;
using MvcApiHospitalPractica.Services;
using MvcSegundaPractica.Services;

namespace MvcSegundaPractica.Controllers
{
    public class CubosController : Controller
    {
        private readonly ServiceSegundaPractica service;
        private readonly ServiceStorageBlob serviceStorageBlob;

        public CubosController(ServiceSegundaPractica service, ServiceStorageBlob serviceStorageBlob)
        {
            this.service = service;
            this.serviceStorageBlob = serviceStorageBlob;
        }

        public async Task<IActionResult> Index()
        {
            List<Cubo> cubos = await this.service.GetCubosAsync();

            foreach (var cubo in cubos)
            {
                cubo.Imagen = await this.serviceStorageBlob.GetBlobUriAsync("cubosimages", cubo.Imagen);
            }
            return View(cubos);
        }

        [HttpPost]
        public async Task<IActionResult> CubosMarca(string marca)
        {
            List<Cubo> cubos = await this.service.GetCubosMarcaAsync(marca);

            foreach (var cubo in cubos)
            {
                cubo.Imagen = await this.serviceStorageBlob.GetBlobUriAsync("cubosimages", cubo.Imagen);
            }

            return View("Index", cubos);
        }

        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(string nombre, string email, string password, IFormFile imagen)
        {
            string imagenName = nombre.ToLower();

            using (Stream stream = imagen.OpenReadStream())
            {
                await this.serviceStorageBlob.UploadBlobAsync("profileimages", nombre.ToLower(), stream);
            }

            InsertUserModel model = new()
            {
                Imagen = imagenName,
                Nombre = nombre,
                Email = email,
                Password = password
            };

            await this.service.RegisterUserAsync(model);
            return RedirectToAction("Perfil");
        }

        public IActionResult CrearCubo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCubo(string nombre, string marca, IFormFile imagen, int precio)
        {
            string imagenName = nombre.ToLower();

            using (Stream stream = imagen.OpenReadStream())
            {
                await this.serviceStorageBlob.UploadBlobAsync("cubosimages", nombre.ToLower(), stream);
            }

            InsertCuboModel model = new()
            {
                Nombre = nombre,
                Imagen = imagenName,
                Marca = marca,
                Precio = precio
            };

            await this.service.InsertarCuboAsync(model);
            return RedirectToAction("Index");
        }

        [AuthorizeUsuarios]
        public async Task<IActionResult> Perfil()
        {
            string? token = HttpContext.Session.GetString("TOKEN");
            Usuario user = await this.service.GetPerfilUsuarioAsync(token);

            user.Imagen = await this.serviceStorageBlob.GetBlobUriAsync("profileimages", user.Imagen);

            return View(user);
        }

        [AuthorizeUsuarios]
        public async Task<IActionResult> Pedidos()
        {
            string? token = HttpContext.Session.GetString("TOKEN");
            var pedidos = await this.service.GetPedidosUsuarioAsync(token);
            return View(pedidos);
        }

        [HttpPost]
        [AuthorizeUsuarios]
        public async Task<IActionResult> RealizarPedido(int idCubo)
        {
            string? token = HttpContext.Session.GetString("TOKEN");

            InsertCompraModel model = new()
            {
                IdCubo = idCubo,
                FechaPedido = DateTime.Now,
            };

            await this.service.RealizarPedidoAsync(model, token);
            return RedirectToAction("Pedidos");
        }
    }
}
