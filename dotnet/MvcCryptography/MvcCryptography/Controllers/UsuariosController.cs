﻿using Microsoft.AspNetCore.Mvc;
using MvcCryptography.Helpers;
using MvcCryptography.Models;
using MvcCryptography.Repositories;

namespace MvcCryptography.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly RepositoryUsuarios repo;
        private readonly HelperFile helperFile;

        public UsuariosController(RepositoryUsuarios repo, HelperFile helperFile)
        {
            this.repo = repo;
            this.helperFile = helperFile;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register
            (string nombre, string email, string password, IFormFile imagen)
        {
            string domainName = "https://" + HttpContext.Request.Host.Value.ToString();

            string maximo = this.repo.GetMaximo().ToString();

            string path = await this.helperFile.UploadFileAsync(imagen, maximo, domainName, Folders.Images);

            await this.repo.RegisterUser(nombre, email, password, path);
            ViewData["MENSAJE"] = "Usuario registrado correctamente";
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            Usuario? user = await this.repo.LoginUser(email, password);
            if (user == null)
            {
                ViewData["MENSAJE"] = "Credenciales incorrectas";
                return View();
            }
            return View(user);
        }
    }
}
