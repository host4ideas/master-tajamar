using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Models;
using MvcCoreUtilidades.Repositories;

namespace MvcCoreUtilidades.ViewComponents
{
    public class MenuCochesViewComponent : ViewComponent
    {
        RepositoryCoches repositoryCoches;

        public MenuCochesViewComponent(RepositoryCoches repositoryCoches)
        {
            this.repositoryCoches = repositoryCoches;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Coche> coches = this.repositoryCoches.GetCoches();
            return View(coches);
        }
    }
}
