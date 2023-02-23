using Microsoft.EntityFrameworkCore;
using MvcCoreMultiplesBBDD.Data;
using MvcCoreMultiplesBBDD.Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

#region PROCEDIMIENTOS ALMACENADOS
//CREATE OR REPLACE PROCEDURE SP_DELETE_EMPLEADO
//(P_IDEMPLEADO EMP.EMP_NO%TYPE)
//AS
//BEGIN
//  DELETE FROM EMP WHERE EMP_NO = P_IDEMPLEADO;
//COMMIT;
//END;

//CREATE OR REPLACE PROCEDURE SP_UPDATE_EMPLEADO
//(P_IDEMPLEADO EMP.EMP_NO%TYPE, P_SALARIO EMP.SALARIO%TYPE, P_OFICIO EMP.OFICIO%TYPE)
//AS
//BEGIN
//  UPDATE EMP SET SALARIO = P_SALARIO, OFICIO = P_OFICIO WHERE EMP_NO = P_IDEMPLEADO;
//COMMIT;
//END;

//CREATE OR REPLACE PROCEDURE SP_ALL_EMPLOYEES
//AS
//BEGIN
//  SELECT * FROM EMP;
//END;

//CREATE OR REPLACE PROCEDURE SP_ALL_EMPLOYEES
//(P_CURSOR_EMPLEADOS OUT SYS_REFCURSOR)
//AS
//BEGIN
//  open P_CURSOR_EMPLEADOS for
//  SELECT * FROM EMP;
//END;

//CREATE OR REPLACE PROCEDURE SP_DETAILS_EMPLEADO
//(P_IDEMPLEADO EMP.EMP_NO%TYPE, P_CURSOR_EMPLEADO OUT SYS_REFCURSOR)
//AS
//BEGIN
//  OPEN P_CURSOR_EMPLEADO FOR
//  SELECT * FROM EMP WHERE EMP_NO = P_IDEMPLEADO;
//END;
#endregion

namespace MvcCoreMultiplesBBDD.Repositories
{
    public class RepositoryEmpleadosOracle : IRepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleadosOracle(HospitalContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            string sql = @"BEGIN SP_ALL_EMPLOYEES(:P_CURSOR_EMPLEADOS); END;";
            OracleParameter paramCursor = new(":P_CURSOR_EMPLEADOS", null);
            paramCursor.Direction = ParameterDirection.Output;
            paramCursor.OracleDbType = OracleDbType.RefCursor;

            var consulta = this.context.Empleados.FromSqlRaw(sql, paramCursor);
            List<Empleado> empleados = consulta.ToList();
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
            string sql = @"BEGIN SP_DELETE_EMPLEADO(:P_IDEMPLEADO); END;";
            OracleParameter paramID = new(":P_IDEMPLEADO", id);
            await this.context.Database.ExecuteSqlRawAsync(sql, paramID);
        }

        public async Task UpdateEmpleado(int id, int salario, string oficio)
        {
            string sql = @"BEGIN SP_UPDATE_EMPLEADO(:P_IDEMPLEADO, :P_SALARIO, :P_OFICIO); END;";
            OracleParameter paramID = new(":P_IDEMPLEADO", id);
            OracleParameter paramSalario = new(":P_SALARIO", salario);
            OracleParameter paramOficio = new(":P_OFICIO", oficio);
            await this.context.Database.ExecuteSqlRawAsync(sql, paramID, paramSalario, paramOficio);
        }

        public Empleado EmpleadoDetails(int id)
        {
            string sql = "BEGIN SP_DETAILS_EMPLEADO(:P_IDEMPLEADO, :P_CURSOR_EMPLEADO); END;";
            OracleParameter paramID = new(":P_IDEMPLEADO", id);
            OracleParameter paramCursor = new(":P_CURSOR_EMPLEADO", null);
            paramCursor.Direction = ParameterDirection.Output;
            paramCursor.OracleDbType = OracleDbType.RefCursor;

            var consulta = this.context.Empleados.FromSqlRaw(sql, paramID, paramCursor);
            Empleado emp = consulta.ToList().FirstOrDefault();
            return emp;
        }
    }
}
