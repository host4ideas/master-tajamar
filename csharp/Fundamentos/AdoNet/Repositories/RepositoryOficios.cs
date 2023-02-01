using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet.Helpers;
using AdoNet.Models;

namespace AdoNet.Repositories
{
    public class RepositoryOficios
    {
        private SqlDataReader? reader;
        private readonly SqlConnection cn;
        private readonly SqlCommand cmd;

        public RepositoryOficios()
        {
            this.cn = new(HelperConfiguration.GetConnectionString());
            this.cmd = this.cn.CreateCommand();
        }

        public List<string> GetOficios()
        {
            var oficios = new List<string>();
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_OFICIOS";

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();

            while (this.reader.Read())
            {
                oficios.Add((string)this.reader["OFICIO"]);
            }
            this.reader.Close();
            this.cn.Close();

            return oficios;
        }

        public DatosOficio GetDatosOficio(string? oficio = null)
        {
            if (oficio == null)
            {
                var datosOficio1 = new DatosOficio();
                this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
                this.cmd.CommandText = "SP_EMPLEADOS_OFICIO";

                this.cn.Open();
                this.reader = this.cmd.ExecuteReader();

                datosOficio1.Tipo = "";
                datosOficio1.Empleados = new();

                while (this.reader.Read())
                {
                    datosOficio1.Empleados.Add(new Empleado()
                    {
                        Apellido = (string)this.reader["APELLIDO"],
                        Id = (int)this.reader["EMP_NO"],
                        Oficio = (string)this.reader["OFICIO"],
                        Salario = (int)this.reader["SALARIO"]
                    });
                }
                this.cmd.Parameters.Clear();
                this.reader.Close();
                this.cn.Close();

                return datosOficio1;
            }

            var datosOficio = new DatosOficio();
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_EMPLEADOS_OFICIO";

            SqlParameter paramOficio = new("@OFICIO", oficio);
            this.cmd.Parameters.Add(paramOficio);

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();

            datosOficio.Tipo = oficio;
            datosOficio.Empleados = new();

            while (this.reader.Read())
            {
                datosOficio.Empleados.Add(new Empleado()
                {
                    Apellido = (string)this.reader["APELLIDO"],
                    Id = (int)this.reader["EMP_NO"],
                    Oficio = (string)this.reader["OFICIO"],
                    Salario = (int)this.reader["SALARIO"]
                });
            }
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();

            return datosOficio;
        }

        public int DeleteEmpleado(int empleadoId)
        {
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_ELIMINAR_EMPLEADO";

            SqlParameter paramId = new("@EMP_NO", empleadoId);
            this.cmd.Parameters.Add(paramId);

            this.cn.Open();
            int affectedRows = this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();

            return affectedRows;
        }

        public int IncrementarSalario(string oficio, int incremento)
        {
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_INCREMENTAR_SALARIO_OFICIO";

            SqlParameter paramOficio = new("@OFICIO", oficio);
            this.cmd.Parameters.Add(paramOficio);

            SqlParameter paramIncremento = new("@INCREMENTO", incremento);
            this.cmd.Parameters.Add(paramIncremento);

            this.cn.Open();
            int affectedRows = this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();

            return affectedRows;
        }
    }
}
