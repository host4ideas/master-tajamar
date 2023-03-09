using Microsoft.AspNetCore.Mvc;
using MvcCoreEmpleadosSession.Extensions;
using MvcCoreEmpleadosSession.Models;
using MvcCoreEmpleadosSession.Repositories;

namespace MvcCoreEmpleadosSession.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> SessionEmpleados(int? idempleado)
        {
            if (idempleado != null)
            {
                //QUEREMOS ALMACENAR ALGO
                Empleado? empleado = await this.repo.FindEmpleado(idempleado.Value);

                if (empleado != null)
                {
                    //ALMACENAREMOS UNA COLECCION DE EMPLEADOS
                    List<Empleado> empleadosSession;
                    if (HttpContext.Session.GetObject<List<Empleado>>("EMPLEADOS") != null)
                    {
                        //TENEMOS EMPLEADOS ALMACENADOS
                        empleadosSession =
                            HttpContext.Session.GetObject<List<Empleado>>("EMPLEADOS");
                    }
                    else
                    {
                        //NO EXISTEN EMPLEADOS TODAVIA
                        empleadosSession = new List<Empleado>();
                    }
                    //AGREGAMOS EL NUEVO EMPLEADO A NUESTRA COLECCION
                    empleadosSession.Add(empleado);
                    //REFRESCAMOS LOS DATOS DE SESSION
                    HttpContext.Session.SetObject("EMPLEADOS", empleadosSession);
                    ViewData["MENSAJE"] = "Empleado " + empleado.Apellido
                        + " almacenado en Session.";
                }
            }
            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }

        public IActionResult EmpleadosAlmacenados()
        {
            return View();
        }

        public IActionResult SessionSalarios(int? salario)
        {
            if (salario != null)
            {
                int sumaSalarial = 0;

                var sessionSumaSalarial = HttpContext.Session.GetString("SUMASALARIAL");
                if (sessionSumaSalarial != null)
                {
                    sumaSalarial = int.Parse(sessionSumaSalarial);
                }
                sumaSalarial += salario.Value;
                HttpContext.Session.SetString("SUMASALARIAL", sumaSalarial.ToString());

                ViewData["MENSAJE"] = "Salario almacenado: " + salario.Value;
            }

            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }

        public IActionResult SumaSalarios(int? salario)
        {
            return View();
        }

        public IActionResult EmpleadosSessionOK(int? idempleado)
        {
            if (idempleado != null)
            {
                List<int> empleadosIds = new();

                List<int>? listIds = HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS");

                if (listIds != null)
                {
                    empleadosIds = listIds;
                }

                empleadosIds.Add(idempleado.Value);

                HttpContext.Session.SetObject("IDSEMPLEADOS", empleadosIds);
                ViewData["MENSAJE"] = "Empleados almacenados: " + empleadosIds.Count;
            }

            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }

        public IActionResult EmpleadosAlmacenadosOK()
        {
            List<int>? idsEmpleados = HttpContext.Session.GetObject<List<int>>("IDSEMPLEADOS");

            if (idsEmpleados == null)
            {
                ViewData["MENSAJE"] = "No existen empleados almacenados";
                return View();
            }

            List<Empleado> empleadosSession = this.repo.GetEmpleadosSession(idsEmpleados);
            return View(empleadosSession);

        }
    }
}
