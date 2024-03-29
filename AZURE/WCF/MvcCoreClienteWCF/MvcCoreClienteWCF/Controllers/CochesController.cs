﻿using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF.Services;
using ServiceReference1;

namespace MvcCoreClienteWCF.Controllers
{
    public class CochesController : Controller
    {
        private ServiceCoches service;

        public CochesController(ServiceCoches service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            Coche[] cars = await this.service.GetCochesAsync();
            return View(cars);
        }

        public async Task<IActionResult> Details(int idCoche)
        {
            Coche car = await this.service.FindCocheAsync(idCoche);
            return View(car);
        }
    }
}
