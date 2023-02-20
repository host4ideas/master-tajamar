using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcCoreEfProcedures.Data;
using MvcCoreEfProcedures.Models;
using System.Data.Common;
using System.Net;

namespace MvcCoreEfProcedures.Repositories
{
    public class RepositoryDoctores
    {
        private EnfermosContext context;
        public RepositoryDoctores(EnfermosContext context)
        {
            this.context = context;
        }

        public List<Doctor> GetDoctores()
        {
            using (DbCommand cmd = this.context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_DOCTORES";

                List<Doctor> doctors = new();

                cmd.Connection.Open();
                DbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    doctors.Add(new Doctor()
                    {
                        Apellido = (string)reader["APELLIDO"],
                        Especialidad = (string)reader["ESPECIALIDAD"],
                        HospitalCod = int.Parse(reader["HOSPITAL_COD"].ToString()!),
                        Id = int.Parse(reader["DOCTOR_NO"].ToString()!),
                        Salario = int.Parse(reader["SALARIO"].ToString()!)
                    });
                }
                reader.Close();
                cmd.Connection.Close();

                return doctors;
            }
        }

        public List<string> GetEspecialidades()
        {
            using (DbCommand cmd = this.context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_ESPECIALIDADES";

                List<string> especialidades = new();

                cmd.Connection.Open();
                DbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    especialidades.Add((string)reader["ESPECIALIDAD"]);
                }
                reader.Close();
                cmd.Connection.Close();

                return especialidades;
            }
        }
        
        public List<Doctor> GetDoctoresEspecialidad(string especialidad)
        {
            string sql = "SP_DOCTORES_ESPECIALIDAD @ESPECIALIDAD";

            SqlParameter paramEspecialidad = new("@ESPECIALIDAD", especialidad);
            var consulta = this.context.Doctores.FromSqlRaw(sql, paramEspecialidad);

            return consulta.AsEnumerable().ToList();
        }

        public async Task IncrementarSalario(string especialidad, int incremento)
        {
            string sql = "SP_INCREMENTAR_SALARIO @ESPECIALIDAD, @INCREMENTO";
            SqlParameter paramIncremento = new("@INCREMENTO", incremento);
            SqlParameter paramEspecialidad = new("@ESPECIALIDAD", especialidad);

            await this.context.Database.ExecuteSqlRawAsync(sql, paramEspecialidad, paramIncremento);
        }
    }
}
