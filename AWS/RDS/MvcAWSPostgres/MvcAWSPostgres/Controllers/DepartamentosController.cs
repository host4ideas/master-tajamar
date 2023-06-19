using Microsoft.AspNetCore.Mvc;
using MvcAWSPostgres.Models;
using MvcAWSPostgres.Repositories;

namespace MvcAWSPostgres.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly RepositoryDepartamentos repositoryDepartamentos;

        public DepartamentosController(RepositoryDepartamentos repositoryDepartamentos)
        {
            this.repositoryDepartamentos = repositoryDepartamentos;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.repositoryDepartamentos.GetDepartamentosAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.repositoryDepartamentos.FindDepartamentoAsync(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(Departamento departamento)
        {
            await this.repositoryDepartamentos.CreateDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction(nameof(Index));
        }
    }
}
