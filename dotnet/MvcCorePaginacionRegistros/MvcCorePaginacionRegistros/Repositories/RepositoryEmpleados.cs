using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCorePaginacionRegistros.Data;
using MvcCorePaginacionRegistros.Models;
using System.Collections.Generic;
using System.Drawing;

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
//(@OFICIO NVARCHAR(50), @POSICION INT, @NUMEROREGISTROS INT OUT)
//AS
//    SELECT @NUMEROREGISTROS = COUNT(EMP_NO) FROM EMP WHERE OFICIO = @OFICIO;

//SELECT* FROM(SELECT CAST(ROW_NUMBER() OVER(ORDER BY EMP_NO) AS INT) AS POSICION,
//EMP_NO, APELLIDO, OFICIO, SALARIO, FECHA_ALT, DEPT_NO
//	FROM EMP
//	WHERE OFICIO = @OFICIO) AS QUERY
//	WHERE QUERY.POSICION >= @POSICION AND QUERY.POSICION < (@POSICION + 3);
//GO

//DECLARE @CONTADOR INT
//SET @CONTADOR = 1
//WHILE (@CONTADOR <= 20)
//BEGIN
//    INSERT INTO EMP VALUES 
//	((SELECT MAX(EMP_NO) +1  FROM EMP),
//	'ALUMNO ' + CAST(@CONTADOR AS NVARCHAR),
//	'ALUMNO', 1, GETDATE(), 10000, 0, 40)
//	SET @CONTADOR = @CONTADOR + 1
//END
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

        public async Task<ModelPaginarEmpleado> GetEmpleadosProcedure(string oficio, int posicion, int numeroEmpleados)
        {
            string sql = "SP_GRUPO_EMPLEADOS_OFICIO @OFICIO, @POSICION, @NUMEROEMPS, @NUMEROREGISTROS OUT";

            SqlParameter paramOficio = new("@OFICIO", oficio);
            SqlParameter paramPosicion = new("@POSICION", posicion);
            SqlParameter paramNumEmps = new("@NUMEROEMPS", numeroEmpleados);
            SqlParameter outNumRegistros = new("@NUMEROREGISTROS", -1)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            List<Empleado> empleados = await this.context.Empleados.FromSqlRaw(sql, paramOficio, paramPosicion, paramNumEmps, outNumRegistros).ToListAsync();
            int registros = (int)outNumRegistros.Value;

            return new ModelPaginarEmpleado()
            {
                Empleados = empleados,
                NumeroRegistros = registros
            };
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
