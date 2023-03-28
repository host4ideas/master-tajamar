using Microsoft.AspNetCore.Mvc;
using PracticaMvcCore2FMB.Models;
using PracticaMvcCore2FMB.Repositories;

namespace PracticaMvcCore2FMB.ViewComponents
{
    public class MenuGenerosViewComponent : ViewComponent
    {
        private RepositoryLibros repositoryLibros;

        public MenuGenerosViewComponent(RepositoryLibros repositoryLibros)
        {
            this.repositoryLibros = repositoryLibros;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> generos = await this.repositoryLibros.AllGeneros();
            return View(generos);
        }
    }
}
