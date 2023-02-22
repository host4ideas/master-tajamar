using Microsoft.AspNetCore.Mvc;
using MvcCoreEfProcedures.Data;
using MvcCoreEfProcedures.Models;

#region SQL
//CREATE OR ALTER VIEW V_EMPLEADOS_DEPT
//AS
//	SELECT ISNULL(
//			ROW_NUMBER() OVER(ORDER BY EMP.APELLIDO),  0) AS CLAVE
//    , EMP.APELLIDO, EMP.OFICIO
//	, DEPT.DNOMBRE AS NOMBRE
//	, DEPT.LOC AS LOCALIDAD
//	FROM EMP
//	INNER JOIN DEPT
//	ON EMP.DEPT_NO = DEPT.DEPT_NO
//GO

//CREATE OR ALTER VIEW V_TRABAJADORES
//AS
//	SELECT ISNULL(EMP_NO, 0) AS IDTRABAJADOR, APELLIDO, OFICIO, SALARIO
//	FROM EMP UNION
//	SELECT DOCTOR_NO, APELLIDO, ESPECIALIDAD, SALARIO
//	FROM DOCTOR UNION
//	SELECT EMPLEADO_NO, APELLIDO, FUNCION, SALARIO
//	FROM PLANTILLA;
//GO

//CREATE OR ALTER PROCEDURE SP_TRABAJADORES_OFICIO
//(@OFICIO NVARCHAR(50), @PERSONAS INT OUT, @MEDIA INT OUT, @SUMA INT OUT)
//AS
//    -- Devolver todos los trabajadores de la vista
//	SELECT * FROM V_TRABAJADORES WHERE OFICIO = @OFICIO;
//--Devolver las personas, media y suma
//	SELECT @PERSONAS = COUNT(IDTRABAJADOR), @MEDIA = AVG(SALARIO), @SUMA = SUM(SALARIO)

//    FROM V_TRABAJADORES WHERE OFICIO = @OFICIO;
//GO
#endregion

namespace MvcCoreEfProcedures.Repositories
{
    public class RepositoryVistaEmpleados
    {
        private EnfermosContext context;

        public RepositoryVistaEmpleados(EnfermosContext context)
        {
            this.context = context;
        }

        public List<VistaEmpleado> GetEmpleados()
        {
            var consulta = from datos in this.context.VistaEmpleados
                           select datos;
            return consulta.ToList();
        }
    }
}
