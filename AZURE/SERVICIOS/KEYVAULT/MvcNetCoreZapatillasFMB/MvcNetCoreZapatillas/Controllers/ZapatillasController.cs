using Microsoft.AspNetCore.Mvc;
using MvcNetCoreZapatillas.Models;
using MvcNetCoreZapatillas.Repositories;

namespace MvcNetCoreZapatillas.Controllers
{
    public class ZapatillasController : Controller
    {
        private RepositoryZapatillas repositoryZapatillas;

        public ZapatillasController(RepositoryZapatillas repositoryZapatillas)
        {
            this.repositoryZapatillas = repositoryZapatillas;
        }

        public async Task<IActionResult> Zapatillas()
        {
            List<Zapatilla> zapas = await this.repositoryZapatillas.GetZapatillas();
            return View(zapas);
        }

        public async Task<IActionResult> DetailsZapatilla(int idProducto)
        {
            Zapatilla zapa = await this.repositoryZapatillas.FindZapatilla(idProducto);
            return View(zapa);
        }

        public async Task<IActionResult> PartialZapaImages(int idProducto, int posicion = 1)
        {
            int numeroRegistros = this.repositoryZapatillas.GetNumeroRegistrosImagenZapa(idProducto);

            int siguiente = posicion + 1;

            if (siguiente > numeroRegistros)
            {
                siguiente = 1;
            }

            int anterior = posicion - 1;

            if (anterior < 1)
            {
                anterior = numeroRegistros;
            }

            ImagenZapatilla model = await this.repositoryZapatillas.PaginacionImagenesZapatillas(idProducto, posicion);
            ViewData["ULTIMO"] = numeroRegistros;
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;

            return PartialView("_ZapasImagesPartial", model);
        }
    }
}
