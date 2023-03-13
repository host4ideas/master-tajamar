using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Models;

namespace MvcCoreUtilidades.Controllers
{
    public class CochesController : Controller
    {
        private List<Coche> Cars;

        public CochesController()
        {
            this.Cars = new()
            {
                new Coche()
                {
                    IdCoche = 1, Marca = "Pontiac", Modelo = "Firebird", Imagen = "https://acnews.blob.core.windows.net/imgnews/medium/NAZ_52b15eb25b4a4b2d9db3d15c12f137e1.jpg"
                },
                new Coche()
                {
                    IdCoche = 2, Marca = "Hyundai", Modelo = "30N", Imagen = "https://cdn.motor1.com/images/mgl/pEeOJ/s1/hyundai-i20-n-2021.jpg"
                },
                new Coche()
                {
                    IdCoche = 3, Marca = "Mustang", Modelo = "Mach E", Imagen = "https://www.ford.es/content/dam/guxeu/rhd/central/cars/2021-mustang-mach-e-gt/launch/gallery/exterior/ford-mustang_mach_e_gt-FoE-front_34_dynamic-16x9-2160x1215-ga.jpg.renditions.original.png"
                },
                new Coche()
                {
                    IdCoche = 4, Marca = "Mercedes", Modelo = "CLA", Imagen = "https://d1eip2zddc2vdv.cloudfront.net/dphotos/750x400/1740491-1553611631.jpg"
                },
                new Coche()
                {
                    IdCoche = 5, Marca = "Ferrari", Modelo = "F40", Imagen = "https://phantom-marca.unidadeditorial.es/7b78119ebc8cda8d862743b4da06aea3/resize/1320/f/jpg/assets/multimedia/imagenes/2022/11/07/16678170689786.jpg"
                },
                new Coche()
                {
                    IdCoche = 6, Marca = "Lamborghini", Modelo = "Gallardo", Imagen = ""
                }
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _CochesPartial()
        {
            return PartialView("_CochesPartial", this.Cars);
        }

        public IActionResult _DetailsCoche(int cocheId)
        {
            Coche? car = this.Cars.FirstOrDefault(x => x.IdCoche == cocheId);

            if (car == null)
            {
                return PartialView("_CochesPartial", this.Cars);
            }

            return PartialView("_DetailsCoche", car);
        }

        public IActionResult Details(int cocheId)
        {
            Coche? car = this.Cars.FirstOrDefault(x => x.IdCoche == cocheId);

            return View(car);
        }
    }
}
