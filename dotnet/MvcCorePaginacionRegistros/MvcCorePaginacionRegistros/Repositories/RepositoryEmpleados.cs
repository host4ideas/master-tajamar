using MvcCorePaginacionRegistros.Data;
using MvcCorePaginacionRegistros.Models;

namespace MvcCorePaginacionRegistros.Repositories
{
    public class RepositoryEmpleados
    {
        private readonly HospitalContext context;

        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            return this.context.Empleados.ToList();
        }

        public List<Empleado> GetEmpleadosDept(int deptNo)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.DeptNo == deptNo
                           select datos;
            return consulta.ToList();
        }
    }
}
