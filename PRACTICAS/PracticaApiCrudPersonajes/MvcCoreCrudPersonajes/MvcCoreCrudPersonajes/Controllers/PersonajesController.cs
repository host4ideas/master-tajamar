using ApiCoreCrudPersonajes.Models;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudPersonajes.Services;

namespace MvcCoreCrudPersonajes.Controllers
{
    public class PersonajesController : Controller
    {
        private readonly ServicePersonajes servicePersonajes;

        public PersonajesController(ServicePersonajes servicePersonajes)
        {
            this.servicePersonajes = servicePersonajes;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.servicePersonajes.GetPersonajesAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.servicePersonajes.FindPersonajeAsync(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.servicePersonajes.DeletePersonajeAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string imagen)
        {
            await this.servicePersonajes.InsertPersonajeAsync(nombre, imagen);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await this.servicePersonajes.FindPersonajeAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Personaje personaje)
        {
            await this.servicePersonajes.UpdatePersonajeAsync(personaje);
            return RedirectToAction("Index");
        }
    }
}
