using NetCoreLinqToSqlInjection.Models;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;

namespace NetCoreLinqToSqlInjection.Repositories
{
    public class RepositoryDoctoresOracle : IRepository
    {
        private OracleConnection cn;
        private OracleCommand cmd;
        private OracleDataReader? reader;
        private OracleDataAdapter adapter;
        private DataTable tablaDoctores;

        public RepositoryDoctoresOracle()
        {
            //string connectionString = "Data Source=EX;User Id=system;Password=oracle;";
            //string connectionString = "User Id=system;Password=oracle;Data Source=localhost:1521/EX;";
            string connectionString = @"Data Source=LOCALHOST:1521/XE;Persist Security Info=false;User ID=SYSTEM;Password=oracle";
            // Ado net
            this.cn = new OracleConnection(connectionString);
            this.cmd = this.cn.CreateCommand();
            // Linq
            string sql = "SELECT * FROM DOCTOR";
            this.adapter = new(sql, connectionString);
            this.tablaDoctores = new DataTable();
            this.adapter.Fill(this.tablaDoctores);
        }

        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable()
                           select new Doctor
                           {
                               HospitalCod = datos.Field<int>("HOSPITAL_COD").ToString()!,
                               DoctorCod = datos.Field<int>("DOCTOR_NO").ToString()!,
                               Apellido = datos.Field<string>("APELLIDO")!,
                               Especialidad = datos.Field<string>("ESPECIALIDAD")!,
                               Salario = datos.Field<int>("SALARIO")
                           };

            return consulta.ToList();
        }

        public int GetMaximoDoctor()
        {
            var maximo = (from datos in this.tablaDoctores.AsEnumerable() select datos).Max(x => x.Field<int>("DOCTOR_NO")) + 1;
            return maximo;
        }

        public void InsertarDoctor(string hospitalCod, string apellido, string especialidad, int salario)
        {
            string sql = "INSERT INTO DOCTOR VALUES(:HOSPITALCOD,:DOCTORCOD,:APELLIDO,:ESPECIALIDAD,:SALARIO)";
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = sql;

            OracleParameter paramHospCod = new(":HOSPITALCOD", hospitalCod);
            this.cmd.Parameters.Add(paramHospCod);
            OracleParameter paramDoctorCod = new(":DOCTORCOD", this.GetMaximoDoctor());
            this.cmd.Parameters.Add(paramDoctorCod);
            OracleParameter paramApellido = new(":APELLIDO", apellido);
            this.cmd.Parameters.Add(paramApellido);
            OracleParameter paramEspecialidad = new(":ESPECIALIDAD", especialidad);
            this.cmd.Parameters.Add(paramEspecialidad);
            OracleParameter paramSalario = new(":SALARIO", salario);
            this.cmd.Parameters.Add(paramSalario);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }
    }
}
