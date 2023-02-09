using Microsoft.AspNetCore.Mvc;
using MvcCrudDepartamentosAdo.Models;
using MvcCrudDepartamentosAdo.Repositories;
using System.Data.SqlClient;

namespace MvcCrudDepartamentosAdo.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController()
        {
            this.repo = new RepositoryDepartamentos();
        }

        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();

            return View(departamentos);
        }

        public IActionResult Details(int id)
        {
            Departamento dept = this.repo.FindDepartamento(id);

            return View(dept);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            this.repo.InsertDepartamento(
                departamento.IdDepartamento,
                departamento.Nombre,
                departamento.Localidad
                );
            ViewData["MENSAGE"] = "Departamento insertado";
            //return View("Index");
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            this.repo.DeleteDepartamento(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Departamento dept = this.repo.FindDepartamento(id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Update(Departamento departamento)
        {
            this.repo.UpdateDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }
    }
}
