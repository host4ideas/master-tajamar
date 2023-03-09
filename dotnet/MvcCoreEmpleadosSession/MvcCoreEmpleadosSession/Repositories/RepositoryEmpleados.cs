using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoreEmpleadosSession.Data;
using MvcCoreEmpleadosSession.Models;

namespace MvcCoreEmpleadosSession.Repositories
{
    public class RepositoryEmpleados : Controller
    {
        private EmpleadosContext _context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            _context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            return this._context.Empleados.ToList();
        }

        public Task<Empleado?> FindEmpleado(int id)
        {
            return this._context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == id);
        }

        public List<Empleado>? GetEmpleadosSession(List<int> ids)
        {
            var consulta = from datos in this._context.Empleados
                           where ids.Contains(datos.IdEmpleado)
                           select datos;


            if (!consulta.Any())
            {
                return null;
            }

            return consulta.ToList();
        }
    }
}
