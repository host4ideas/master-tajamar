using ApiEmpleadosMultiplesRutas.Data;
using Microsoft.EntityFrameworkCore;
using NugetApiPaco.Models;

namespace ApiEmpleadosMultiplesRutas.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado> FindEmpleadoAsync(int id)
        {
            return await this.context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == id);
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return await consulta.ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio)
        {
            return await this.context.Empleados.Where(x => x.Oficio == oficio).ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosSalario(int salario)
        {
            return await this.context.Empleados.Where(x => x.Salario >= salario).ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosSalarioAsync(int salario, int iddepartamento)
        {
            return await this.context.Empleados.Where(x => x.Salario == salario && x.IdDepartamento == iddepartamento).ToListAsync();
        }
    }
}
