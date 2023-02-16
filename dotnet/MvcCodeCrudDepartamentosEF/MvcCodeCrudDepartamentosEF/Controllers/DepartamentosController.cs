using Microsoft.AspNetCore.Mvc;
using MvcCodeCrudDepartamentosEF.Models;
using MvcCodeCrudDepartamentosEF.Repositories;

namespace MvcCodeCrudDepartamentosEF.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }
    }
}
