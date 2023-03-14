using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCorePaginacionRegistros.Data;
using MvcCorePaginacionRegistros.Models;
using System.Collections.Generic;

#region SQL
//CREATE OR ALTER VIEW V_DEPARTAMENTOS_INDIVIDUAL
//AS
//	SELECT CAST(ROW_NUMBER() OVER(ORDER BY DEPT_NO) AS INT) AS POSICION,
//    ISNULL(DEPT_NO, 0) AS DEPT_NO, DNOMBRE, LOC
//	FROM DEPT
//GO

//DECLARE @POSICION INT;
//SET @POSICION = 1;
//SELECT* FROM V_DEPARTAMENTOS_INDIVIDUAL WHERE POSICION >= @POSICION AND POSICION < (@POSICION + 2);

//CREATE OR ALTER PROCEDURE SP_GRUPO_DEPARTAMENTO
//(@POSICION INT)
//AS
//    SELECT DEPT_NO, DNOMBRE, LOC
//	FROM V_DEPARTAMENTOS_INDIVIDUAL
//	WHERE POSICION >= @POSICION AND POSICION < (@POSICION + 2);
//GO
#endregion

namespace MvcCorePaginacionRegistros.Repositories
{
    public class RepositoryDepartamentos
    {
        private readonly HospitalContext context;

        public RepositoryDepartamentos(HospitalContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            return this.context.Departamentos.ToList();
        }

        public int GetNumeroRegistrosVistaDepartamentos()
        {
            return this.context.VistaDepartamentos.Count();
        }

        public async Task<VistaDepartamento?> GetVistaDepartamento(int posicion)
        {
            return await this.context.VistaDepartamentos.FirstOrDefaultAsync(x => x.Posicion.Equals(posicion));
        }

        public async Task<List<VistaDepartamento>> GetGrupoVistaDepartamento(int posicion)
        {
            var consulta = from datos in this.context.VistaDepartamentos
                           where datos.Posicion >= posicion && datos.Posicion < (posicion + 2)
                           select datos;
            return await consulta.ToListAsync();
        }

        public Task<List<Departamento>> GetGrupoDepartamentosAsync(int posicion)
        {
            string sql = "SP_GRUPO_DEPARTAMENTO @POSICION";

            SqlParameter paramPos = new("@POSICION", posicion);

            var consulta = this.context.Departamentos.FromSqlRaw(sql, paramPos);

            return consulta.ToListAsync();
        }
    }
}
