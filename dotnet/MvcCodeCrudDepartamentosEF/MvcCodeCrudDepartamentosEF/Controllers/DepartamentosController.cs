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

        public IActionResult BorrarDept(int id)
        {
            this.repo.DeleteDepartamento(id);
            return RedirectToAction("Index");
        }

        public IActionResult Detalles(int id)
        {
            Departamento dept = this.repo.FindDepartamento(id);
            return View(dept);
        }

        public IActionResult CrearDept()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearDept(string nombre, string localidad)
        {
            this.repo.CreateDepartamento(nombre, localidad);
            return RedirectToAction("Index");
        }

        public IActionResult ActualizarDept(int id)
        {
            Departamento dept = this.repo.FindDepartamento(id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult ActualizarDept(Departamento dept)
        {
            this.repo.UpdateDepartamento(dept);
            return RedirectToAction("Index");
        }
    }
}
