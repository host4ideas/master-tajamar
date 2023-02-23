using MvcFrameworkReto.Data;
using MvcFrameworkReto.Models;
using MvcFrameworkReto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFrameworkReto.Controllers
{
    public class EmpleadosController : Controller
    {
        private HospitalesRepository repo;

        public EmpleadosController(HospitalesRepository repo)
        {
            this.repo = repo;
        }

        // GET: Empleados
        public ActionResult Index()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }
    }
}
