using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCoreEfProcedures.Data;
using MvcCoreEfProcedures.Models;
using System.Data.Common;
using System.Diagnostics.Metrics;

namespace MvcCoreEfProcedures.Repositories
{
    #region PROCEDURES
    //    CREATE OR ALTER PROCEDURE SP_TODOS_ENFERMOS
    //AS

    //    SELECT* FROM ENFERMO;
    //GO

    //CREATE OR ALTER PROCEDURE SP_BUSCAR_ENFERMO
    //(@INSCRIPCION INT)
    //AS

    //    SELECT* FROM ENFERMO WHERE

    //    INSCRIPCION = @INSCRIPCION;
    //GO

    //CREATE OR ALTER PROCEDURE SP_DELETE_ENFERMO
    //(@INSCRIPCION INT)
    //AS
    //    DELETE FROM ENFERMO WHERE INSCRIPCION = @INSCRIPCION;
    //    GO
    #endregion
    public class RepositoryEnfermos
    {
        private EnfermosContext context;
        public RepositoryEnfermos(EnfermosContext context)
        {
            this.context = context;
        }

        public List<Enfermo> GetEnfermos()
        {
            using (DbCommand cmd = this.context.Database.GetDbConnection().CreateCommand())
            {
                string sql = "SP_TODOS_ENFERMOS";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sql;
                cmd.Connection.Open();
                DbDataReader reader = cmd.ExecuteReader();

                List<Enfermo> enfermos = new();
                while (reader.Read())
                {
                    enfermos.Add(new Enfermo()
                    {
                        Apellido = (string)reader["APELLIDO"],
                        Direccion = (string)reader["DIRECCION"],
                        FechaNac = DateTime.Parse(reader["FECHA_NAC"].ToString()),
                        Inscripcion = (string)reader["INSCRIPCION"],
                        Sexo = (string)reader["S"]
                    });
                }

                reader.Close();
                cmd.Connection.Close();
                return enfermos;
            }
        }

        public Enfermo FindEnfermo2(string ins)
        {
            string sql = "SP_BUSCAR_ENFERMO @INSCRIPCION";
            SqlParameter paramIns = new("@INSCRIPCION", ins);

            var consulta = this.context.Enfermos.FromSqlRaw(sql, paramIns);
            Enfermo enfermo = consulta.AsEnumerable().FirstOrDefault();

            return enfermo;
        }

        public Enfermo FindEnfermo(string ins)
        {
            var consulta = from datos in this.context.Enfermos
                           where datos.Inscripcion == ins
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void DeleteEnfermo(string ins)
        {
            string sql = "SP_DELETE_ENFERMO @INSCRIPCION";
            SqlParameter paramIns = new("@INSCRIPCION", ins);

            this.context.Database.ExecuteSqlRaw(sql, paramIns);
        }
    }
}
