using NetCoreLinqToSqlInjection.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace NetCoreLinqToSqlInjection.Repositories
{
    public class RepositoryDoctores : IRepository
    {
        public DataTable tablaDoctores;
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader? reader;

        public RepositoryDoctores()
        {
            string connectionString = "Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            // Linq
            string sql = "SELECT * FROM DOCTOR";
            SqlDataAdapter adpter = new SqlDataAdapter(sql, connectionString);
            this.tablaDoctores = new DataTable();
            adpter.Fill(this.tablaDoctores);
            // Ado.net
            this.cn = new(connectionString);
            this.cmd = this.cn.CreateCommand();
        }

        public int GetMaximoDoctor()
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable()
                           select datos;
            if (consulta.Any())
            {
                return 1;
            }
            else
            {
                return consulta.Max(x => x.Field<int>("DOCTOR_NO")) + 1;
            }
        }

        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable() select datos;
            List<Doctor> doctores = new();

            foreach (var row in consulta)
            {
                doctores.Add(new Doctor()
                {
                    Apellido = row.Field<string>("APELLIDO")!,
                    DoctorCod = row.Field<string>("DOCTOR_NO")!,
                    Especialidad = row.Field<string>("ESPECIALIDAD")!,
                    HospitalCod = row.Field<string>("HOSPITAL_COD")!,
                    Salario = row.Field<int>("SALARIO")
                });
            }
            return doctores;
        }

        public void InsertarDoctor(string hospitalCod, string apellido, string especialidad, int salario)
        {
            string sql = "INSERT INTO DOCTOR VALUES(@HOSPITALCOD, @DOCTORCOD, @APELLIDO, @ESPECIALIDAD, @SALARIO)";
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            SqlParameter paramHospCod = new("@HOSPITALCOD", hospitalCod);
            SqlParameter paramDoctorCod = new("@DOCTORCOD", this.GetMaximoDoctor());
            SqlParameter paramApellido = new("@APELLIDO", apellido);
            SqlParameter paramEspecialidad = new("@ESPECIALIDAD", especialidad);
            SqlParameter paramSalario = new("@SALARIO", salario);

            this.cmd.Parameters.Add(paramSalario);
            this.cmd.Parameters.Add(paramApellido);
            this.cmd.Parameters.Add(paramEspecialidad);
            this.cmd.Parameters.Add(paramDoctorCod);
            this.cmd.Parameters.Add(paramHospCod);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }

        public void DeleteDoctor(int iddoctor)
        {
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_DELETE_DOCTOR";

            SqlParameter paramDocId = new("@IDDOCTOR", iddoctor);
            this.cmd.Parameters.Add(paramDocId);
            
            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }
    }
}
