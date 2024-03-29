﻿using ApiOAuthEmpleados.Data;
using ApiOAuthEmpleados.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiOAuthEmpleados.Repositories
{
    public class RepositoryEmpleados
    {
        private readonly EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public Task<List<Empleado>> GetEmpleadosAsync()
        {
            return this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado?> FindEmpleadoAsync(int idEmpleado)
        {
            return await this.context.Empleados.FindAsync(idEmpleado);
        }

        public async Task<List<Empleado>> GetCompisCurroAsync(int idDepartamento)
        {
            return await this.context.Empleados.Where(x => x.IdDepartamento == idDepartamento).ToListAsync();
        }

        public async Task<Empleado?> ExisteEmpleadoAsync(string apellido, int idEmpleado)
        {
            return await this.context.Empleados.FirstOrDefaultAsync(x => x.Apellido == apellido && x.IdEmpleado == idEmpleado);
        }
    }
}
