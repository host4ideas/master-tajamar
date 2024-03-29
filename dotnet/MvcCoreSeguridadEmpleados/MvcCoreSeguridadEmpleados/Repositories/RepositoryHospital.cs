﻿using Microsoft.EntityFrameworkCore;
using MvcCoreSeguridadEmpleados.Data;
using MvcCoreSeguridadEmpleados.Models;

namespace MvcCoreSeguridadEmpleados.Repositories
{
    public class RepositoryHospital
    {
        private readonly HospitalContext hospitalContext;

        public RepositoryHospital(HospitalContext hospitalContext)
        {
            this.hospitalContext = hospitalContext;
        }

        public Task<Empleado?> FindEmpleado(int empleadoId)
        {
            return this.hospitalContext.Empleados.FirstOrDefaultAsync(x => x.EmpNo == empleadoId);
        }

        public Task<Empleado?> FindEmpleado(string apellido, int empleadoId)
        {
            return this.hospitalContext.Empleados.FirstOrDefaultAsync(x => x.EmpNo == empleadoId && x.Apellido == apellido);
        }

        public Task<List<Departamento>> GetDepartamentos()
        {
            return this.hospitalContext.Departamentos.Distinct().ToListAsync();
        }

        public Task<List<Empleado>> GetEmpleados()
        {
            return this.hospitalContext.Empleados.ToListAsync();
        }

        public async Task SubirSalarioPorDept(int deptNo, int incremento)
        {
            List<Empleado> empleados = await this.hospitalContext.Empleados.Where(x => x.DeptNo == deptNo).ToListAsync();

            foreach (Empleado emp in empleados)
            {
                emp.Salario = emp.Salario + incremento;
            }

            await this.hospitalContext.SaveChangesAsync();
        }

        public Task<List<Empleado>> GetEmpleadosDepartamentoAsync(int deptId)
        {
            return this.hospitalContext.Empleados.Where(x => x.DeptNo == deptId).ToListAsync();
        }
    }
}
