using Microsoft.AspNetCore.Mvc;
using MvcCrudDoctoresAdo.Models;
using System.Data.SqlClient;

namespace MvcCrudDoctoresAdo.Repositories
{
    public class RepositoryDoctores
    {
        private readonly SqlCommand cmd;
        private readonly SqlConnection cn;
        private SqlDataReader? reader;

        public RepositoryDoctores()
        {
            this.cn = new SqlConnection("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023");
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
                    DoctorNo = (string)this.reader["DOCTOR_NO"],
                    Especialdad = (string)this.reader["ESPECIALIDAD"],
                    HospitalCod = (string)this.reader["HOSPITAL_COD"],
                    Salario = int.Parse(this.reader["SALARIO"].ToString()!)
                });
            }
            this.reader.Close();
            this.cn.Close();

            return doctores;
        }

        public List<Doctor> GetDoctoresHospital(string idHospital)
        {
            List<Doctor> doctores = new();

            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "SELECT * FROM DOCTOR WHERE HOSPITAL_COD = @ID";

            SqlParameter paramId = new("@ID", idHospital);
            this.cmd.Parameters.Add(paramId);

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();

            while (this.reader.Read())
            {
                doctores.Add(new Doctor()
                {
                    Apellido = (string)this.reader["APELLIDO"],
                    DoctorNo = (string)this.reader["DOCTOR_NO"],
                    Especialdad = (string)this.reader["ESPECIALIDAD"],
                    HospitalCod = (string)this.reader["HOSPITAL_COD"],
                    Salario = int.Parse(this.reader["SALARIO"].ToString()!)
                });
            }
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();

            return doctores;
        }

        public void Delete(string id)
        {
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "DELETE FROM DOCTOR WHERE DOCTOR_NO = @ID";

            SqlParameter paramId = new("@ID", id);
            this.cmd.Parameters.Add(paramId);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();

            this.cmd.Parameters.Clear();
            this.cn.Close();
        }

        public Doctor FindDoctor(string id)
        {
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "SELECT * FROM DOCTOR WHERE DOCTOR_NO = @ID";

            SqlParameter paramId = new("@ID", id);
            this.cmd.Parameters.Add(paramId);

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            this.reader.Read();
            var doctor = new Doctor()
            {
                Apellido = (string)this.reader["APELLIDO"],
                DoctorNo = (string)this.reader["DOCTOR_NO"],
                Especialdad = (string)this.reader["ESPECIALIDAD"],
                HospitalCod = (string)this.reader["HOSPITAL_COD"],
                Salario = int.Parse(this.reader["SALARIO"].ToString()!)
            };
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();

            return doctor;
        }

        public void CreateDoctor(Doctor doctor)
        {
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "INSERT INTO DOCTOR VALUES (@HOSPITALCOD, @DOCTORNO, @APELLIDO, @ESPECIALIDAD, @SALARIO)";

            SqlParameter paramHospital = new("@HOSPITALCOD", doctor.HospitalCod);
            this.cmd.Parameters.Add(paramHospital);

            SqlParameter paramId = new("@DOCTORNO", doctor.DoctorNo);
            this.cmd.Parameters.Add(paramId);

            SqlParameter paramApellido = new("@APELLIDO", doctor.Apellido);
            this.cmd.Parameters.Add(paramApellido);

            SqlParameter paramEspecialidad = new("@ESPECIALIDAD", doctor.Especialdad);
            this.cmd.Parameters.Add(paramEspecialidad);

            SqlParameter paramSalario = new("@SALARIO", doctor.Salario);
            this.cmd.Parameters.Add(paramSalario);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }

        public void Update(Doctor doctor)
        {
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "UPDATE DOCTOR SET HOSPITAL_COD = @HOSPITALCOD, APELLIDO = @APELLIDO, ESPECIALIDAD = @ESPECIALIDAD, SALARIO = @SALARIO WHERE DOCTOR_NO = @DOCTORNO";

            SqlParameter paramHospital = new("@HOSPITALCOD", doctor.HospitalCod);
            this.cmd.Parameters.Add(paramHospital);

            SqlParameter paramId = new("@DOCTORNO", doctor.DoctorNo);
            this.cmd.Parameters.Add(paramId);

            SqlParameter paramApellido = new("@APELLIDO", doctor.Apellido);
            this.cmd.Parameters.Add(paramApellido);

            SqlParameter paramEspecialidad = new("@ESPECIALIDAD", doctor.Especialdad);
            this.cmd.Parameters.Add(paramEspecialidad);

            SqlParameter paramSalario = new("@SALARIO", doctor.Salario);
            this.cmd.Parameters.Add(paramSalario);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }

        public List<Hospital> GetHospitales()
        {
            List<Hospital> hospitales = new();
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "SELECT * FROM HOSPITAL";

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            this.reader.Read();

            while (this.reader.Read())
            {
                hospitales.Add(new Hospital()
                {
                    IdHospital = this.reader["HOSPITAL_COD"].ToString()!,
                    Nombre = (string)this.reader["NOMBRE"]
                });
            }

            this.reader.Close();
            this.cn.Close();

            return hospitales;
        }
    }
}
