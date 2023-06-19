using Microsoft.AspNetCore.Mvc;
using MvcApiPersonajesAWS.Models;
using MvcApiPersonajesAWS.Services;

namespace MvcApiPersonajesAWS.Controllers
{
    public class PersonajesController : Controller
    {
        private readonly ServiceApiPersonajes apiPersonajes;

        public PersonajesController(ServiceApiPersonajes apiPersonajes)
        {
            this.apiPersonajes = apiPersonajes;
        }

        public IActionResult ApiPersonajes()
        {
            return View();
        }

        public async Task<IActionResult> ApiEC2Personajes()
        {
            return View(await this.apiPersonajes.GetPersonajesEC2Async());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string imagen)
        {
            await this.apiPersonajes.SPCreatePersonajeAsync(nombre, imagen);
            return RedirectToAction(nameof(ApiEC2Personajes));
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await this.apiPersonajes.FindPersonajeAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Personaje personaje)
        {
            await this.apiPersonajes.SPUpdatePersonajeAsync(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen);
            return RedirectToAction(nameof(ApiEC2Personajes));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.apiPersonajes.SPDeletePersonajeAsync(id);
            return RedirectToAction(nameof(ApiEC2Personajes));
        }
    }
}
