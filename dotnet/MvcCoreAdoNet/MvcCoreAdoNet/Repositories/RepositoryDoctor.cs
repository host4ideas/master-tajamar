using MvcCoreAdoNet.Models;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryDoctor
    {
        private readonly SqlConnection cn;
        private readonly SqlCommand cmd;
        private SqlDataReader? reader;

        public RepositoryDoctor()
        {
            this.cn = new("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.cmd = this.cn.CreateCommand();
        }

        public List<Doctor> GetDoctores()
        {
            List<Doctor> doctores = new();

            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "SELECT * FROM DOCTOR";

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();

            while (this.reader.Read())
            {
                doctores.Add(new Doctor()
                {
                    Apellido = (string)this.reader["APELLIDO"],
                    DoctorCod = int.Parse(this.reader["DOCTOR_NO"].ToString()!),
                    Especialidad = (string)this.reader["ESPECIALIDAD"],
                    HospitalCod = this.reader["HOSPITAL_COD"].ToString()!,
                    Salario = int.Parse(this.reader["SALARIO"].ToString()!)
                });
            }
            this.cn.Close();
            this.reader.Close();

            return doctores;
        }

        public Doctor FindDoctor(int doctorCod)
        {
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "SELECT * FROM DOCTOR WHERE DOCTOR_NO = @DOCTORCOD";

            this.cmd.Parameters.AddWithValue("@DOCTORCOD", doctorCod);

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            this.reader.Read();

            var doctor = new Doctor()
            {
                Apellido = (string)this.reader["APELLIDO"],
                DoctorCod = int.Parse(this.reader["DOCTOR_NO"].ToString()!),
                Especialidad = (string)this.reader["ESPECIALIDAD"],
                HospitalCod = this.reader["HOSPITAL_COD"].ToString()!,
                Salario = int.Parse(this.reader["SALARIO"].ToString()!)
            };

            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();

            return doctor;
        }

        public List<Doctor> FindDoctorEspecialidad(string especialidad)
        {
            List<Doctor> doctores = new();
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "SELECT * FROM DOCTOR WHERE ESPECIALIDAD LIKE @ESPECIALIDAD";

            this.cmd.Parameters.AddWithValue("@ESPECIALIDAD", especialidad);

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();

            while (this.reader.Read())
            {
                doctores.Add(new Doctor()
                {
                    Apellido = (string)this.reader["APELLIDO"],
                    DoctorCod = int.Parse(this.reader["DOCTOR_NO"].ToString()!),
                    Especialidad = (string)this.reader["ESPECIALIDAD"],
                    HospitalCod = this.reader["HOSPITAL_COD"].ToString()!,
                    Salario = int.Parse(this.reader["SALARIO"].ToString()!)
                });
            }

            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();

            return doctores;
        }

        public List<string> GetEspecialidades()
        {
            List<string> especialidades = new();
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "SELECT DISTINCT ESPECIALIDAD FROM DOCTOR";

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();

            while (this.reader.Read())
            {
                especialidades.Add((string)this.reader["ESPECIALIDAD"]);
            }

            this.reader.Close();
            this.cn.Close();
            return especialidades;
        }

        public List<Doctor> FindDoctorHospital(string hospitalCod)
        {
            List<Doctor> doctores = new();
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "SELECT * FROM DOCTOR WHERE HOSPITAL_COD = @HOSPITAL";

            this.cmd.Parameters.AddWithValue("@HOSPITAL", hospitalCod);

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();

            while (this.reader.Read())
            {
                doctores.Add(new Doctor()
                {
                    Apellido = (string)this.reader["APELLIDO"],
                    DoctorCod = int.Parse(this.reader["DOCTOR_NO"].ToString()!),
                    Especialidad = (string)this.reader["ESPECIALIDAD"],
                    HospitalCod = this.reader["HOSPITAL_COD"].ToString()!,
                    Salario = int.Parse(this.reader["SALARIO"].ToString()!)
                });
            }

            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();

            return doctores;
        }
    }
}
