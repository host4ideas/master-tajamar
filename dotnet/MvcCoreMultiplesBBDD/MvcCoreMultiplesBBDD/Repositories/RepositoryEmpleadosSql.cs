using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCoreMultiplesBBDD.Data;
using MvcCoreMultiplesBBDD.Models;

#region PROCEDURES
//CREATE OR ALTER PROCEDURE SP_ALL_EMPLOYEES
//AS
//	SELECT * FROM EMP;
//GO
//CREATE OR ALTER PROCEDURE SP_DETAILS_EMPLEADO
//(@IDEMPLEADO INT)
//AS
//	SELECT * FROM EMP WHERE EMP_NO = @IDEMPLEADO;
//GO
#endregion

namespace MvcCoreMultiplesBBDD.Repositories
{
    public class RepositoryEmpleadosSql : IRepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleadosSql(HospitalContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            string sql = "SP_ALL_EMPLOYEES";
            List<Empleado> empleados = this.context.Empleados.FromSqlRaw(sql).ToList();
            return empleados;
        }

        public Empleado FindEmpleado(int idEmpleado)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.IdEmpleado == idEmpleado
                           select datos;
            return consulta.ToList().FirstOrDefault();
        }

        public async Task DeleteEmpleado(int id)
        {
            Empleado emp = this.FindEmpleado(id);
            this.context.Empleados.Remove(emp);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateEmpleado(int id, int salario, string oficio)
        {
            Empleado emp = this.FindEmpleado(id);
            emp.Salario = salario;
            emp.Oficio = oficio;
            await this.context.SaveChangesAsync();
        }

        public Empleado EmpleadoDetails(int id)
        {
            
            string sql = "SP_DETAILS_EMPLEADO @IDEMPLEADO";

            SqlParameter paramId = new("@IDEMPLEADO", id);
            var consulta = this.context.Empleados.FromSqlRaw(sql, paramId);
            return consulta.ToList().FirstOrDefault();
        }
    }
}
