using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCorePaginacionRegistros.Data;
using MvcCorePaginacionRegistros.Models;
using System.Collections.Generic;

#region SQL
//CREATE OR ALTER VIEW V_GRUPO_EMPLEADOS
//AS
//	SELECT CAST(ROW_NUMBER() OVER(ORDER BY EMP_NO) AS INT) AS POSICION,
//    ISNULL(EMP_NO, 0) AS EMP_NO, APELLIDO, OFICIO, SALARIO, FECHA_ALT, DEPT_NO
//	FROM EMP
//GO

//--DECLARE @POSICION INT;
//--SET @POSICION = 1;
//--SELECT * FROM V_GRUPO_EMPLEADOS WHERE POSICION >= @POSICION AND POSICION < (@POSICION + 3);

//CREATE OR ALTER PROCEDURE SP_GRUPO_EMPLEADOS
//(@POSICION INT)
//AS
//    SELECT EMP_NO, APELLIDO, OFICIO, SALARIO, FECHA_ALT, DEPT_NO
//	FROM V_GRUPO_EMPLEADOS
//	WHERE POSICION >= @POSICION AND POSICION < (@POSICION + 3);
//GO

//CREATE OR ALTER PROCEDURE SP_GRUPO_EMPLEADOS_OFICIO
//(@OFICIO NVARCHAR(50), @POSICION INT)
//AS
//	SELECT * FROM (SELECT CAST(ROW_NUMBER() OVER(ORDER BY EMP_NO) AS INT) AS POSICION,
//    EMP_NO, APELLIDO, OFICIO, SALARIO, FECHA_ALT, DEPT_NO
//	FROM EMP
//	WHERE OFICIO = @OFICIO) AS QUERY
//	WHERE QUERY.POSICION >= @POSICION AND QUERY.POSICION < (@POSICION + 3);
//GO
#endregion

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

        public List<Empleado> GetEmpleadosProcedure(string oficio, int posicion)
        {
            string sql = "SP_GRUPO_EMPLEADOS_OFICIO @OFICIO, @POSICION";

            SqlParameter paramOficio = new("@OFICIO", oficio);
            SqlParameter paramPosicion = new("@POSICION", posicion);

            return this.context.Empleados.FromSqlRaw(sql, paramOficio, paramPosicion).ToList();
        }

        public List<Empleado> GetEmpleadosDept(int deptNo)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.DeptNo == deptNo
                           select datos;
            return consulta.ToList();
        }

        public int GetNumeroRegistrosVistaEmpleados()
        {
            return this.context.Empleados.Count();
        }

        public Task<List<Empleado>> GetGrupoEmpleadosAsync(int posicion)
        {
            string sql = "SP_GRUPO_EMPLEADOS @POSICION";

            SqlParameter paramPos = new("@POSICION", posicion);

            var consulta = this.context.Empleados.FromSqlRaw(sql, paramPos);

            return consulta.ToListAsync();
        }
    }
}
