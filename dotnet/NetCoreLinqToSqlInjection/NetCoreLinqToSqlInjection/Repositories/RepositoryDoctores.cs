using NetCoreLinqToSqlInjection.Models;
using System.Data;
using System.Data.SqlClient;

namespace NetCoreLinqToSqlInjection.Repositories
{
    public class RepositoryDoctores
    {
        public DataTable tablaDoctores;

        public RepositoryDoctores()
        {
            string connectionString = "Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            string sql = "SELECT * FROM DOCTOR";
            SqlDataAdapter adpter = new SqlDataAdapter(sql, connectionString);

            this.tablaDoctores = new DataTable();
            adpter.Fill(this.tablaDoctores);
        }

        public List<Doctor> GetDoctores()
        {
            var consulta = from datos in this.tablaDoctores.AsEnumerable() select datos;
            List<Doctor> doctores = new();

            foreach (var row in consulta)
            {
                doctores.Add(new Doctor()
                {
                    Apellido = row.Field<string>("APELLIDO"),
                    DoctorCod = row.Field<string>("DOCTOR_NO"),
                    Especialidad = row.Field<string>("ESPECIALIDAD"),
                    HospitalCod = row.Field<string>("HOSPITAL_COD"),
                    Salario = row.Field<int>("SALARIO")
                });
            }
        }
    }
}
