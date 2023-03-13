using Microsoft.AspNetCore.Mvc;
using MvcCorePaginacionRegistros.Models;
using MvcCorePaginacionRegistros.Repositories;

namespace MvcCoreUtilidades.ViewComponents
{
    public class MenuDepartamentosViewComponent : ViewComponent
    {
        private readonly RepositoryDepartamentos repositoryDepartamentos;

        public MenuDepartamentosViewComponent(RepositoryDepartamentos repositoryDepartamentos)
        {
            this.repositoryDepartamentos = repositoryDepartamentos;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Departamento> depts = this.repositoryDepartamentos.GetDepartamentos();
            return View(depts);
        }
    }
}
