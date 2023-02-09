using MvcCrudDepartamentosAdo.Models;
using System.Data.SqlClient;

namespace MvcCrudDepartamentosAdo.Repositories
{
    public class RepositoryDepartamentos
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader? reader;

        public RepositoryDepartamentos()
        {
            this.cn = new("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.cmd = this.cn.CreateCommand();
        }

        public List<Departamento> GetDepartamentos()
        {
            string sql = "SELECT * FROM DEPT";
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = sql;
            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            List<Departamento> departamentos = new();
            while (this.reader.Read())
            {
                Departamento dept = new()
                {
                    IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString()!),
                    Localidad = this.reader["LOC"].ToString()!,
                    Nombre = this.reader["DNOMBRE"].ToString()!
                };
                departamentos.Add(dept);
            }

            this.reader.Close();
            this.cn.Close();
            return departamentos;
        }

        public Departamento FindDepartamento(int id)
        {
            string sql = "SELECT * FROM DEPT WHERE DEPT_NO = @ID";
            SqlParameter paramID = new("@ID", id);
            this.cmd.Parameters.Add(paramID);
            this.cmd.CommandText = sql;

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            this.reader.Read();
            Departamento dept = new()
            {
                IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString()!),
                Localidad = this.reader["LOC"].ToString()!,
                Nombre = this.reader["DNOMBRE"].ToString()!
            };
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();
            return dept;
        }

        public void InsertDepartamento(int id, string nombre, string localidad)
        {
            string sql = "INSERT INTO DEPT VALUES (@ID, @NOMBRE, @LOCALIDAD)";
            SqlParameter paramId = new("@ID", id);
            SqlParameter paramNombre = new("@NOMBRE", nombre);
            SqlParameter paramLoclidad = new("@LOCALIDAD", localidad);

            this.cmd.Parameters.Add(paramId);
            this.cmd.Parameters.Add(paramNombre);
            this.cmd.Parameters.Add(paramLoclidad);

            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = sql;

            this.cn.Open();
            this.cmd.ExecuteNonQuery();

            this.cmd.Parameters.Clear();
            this.cn.Close();
        }

        public void UpdateDepartamento(int id, string nombre, string localidad)
        {
            string sql = "UPDATE DEPT SET DNOMBRE = @NOMBRE, LOC = @LOCALIDAD WHERE DEPT_NO = @ID";
            SqlParameter paramId = new("@ID", id);
            SqlParameter paramNombre = new("@NOMBRE", nombre);
            SqlParameter paramLoclidad = new("@LOCALIDAD", localidad);

            this.cmd.Parameters.Add(paramId);
            this.cmd.Parameters.Add(paramNombre);
            this.cmd.Parameters.Add(paramLoclidad);

            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = sql;

            this.cn.Open();
            this.cmd.ExecuteNonQuery();

            this.cmd.Parameters.Clear();
            this.cn.Close();
        }

        public void DeleteDepartamento(int id)
        {
            string sql = "DELETE FROM DEPT WHERE DEPT_NO = @ID";
            SqlParameter paramId = new("@ID", id);
            this.cmd.Parameters.Add(paramId);

            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = sql;

            this.cn.Open();
            this.cmd.ExecuteNonQuery();

            this.cmd.Parameters.Clear();
            this.cn.Close();
        }
    }
}
