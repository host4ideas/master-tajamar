using AdoNet.Models;
using System.Data.SqlClient;

namespace AdoNet.Repositories
{
    public class RepositoryDepartamentos
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader? reader;

        public RepositoryDepartamentos()
        {
            this.cn = new SqlConnection("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.cmd = this.cn.CreateCommand();
        }

        public List<Departamento> GetDepartamentos()
        {
            string sql = "SELECT * FROM DEPT";
            List<Departamento> departamentos = new();
            this.cmd.CommandText = sql;

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            while (this.reader.Read())
            {
                departamentos.Add(new Departamento()
                {
                    IdDepartamento = (int)this.reader["DEPT_NO"],
                    Localidad = (string)this.reader["LOC"],
                    Nombre = (string)this.reader["DNOMBRE"]
                });
            }
            this.reader.Close();
            this.cn.Close();

            return departamentos;
        }

        public int DeleteDepartamento(int id)
        {
            string sql = "DELETE FROM DEPT WHERE DEPT_NO = @ID";
            SqlParameter paramId = new SqlParameter("@ID", id);
            this.cmd.Parameters.Add(paramId);
            this.cmd.CommandText = sql;

            this.cn.Open();
            int borrados = this.cmd.ExecuteNonQuery();
            this.cn.Close();
            this.cmd.Parameters.Clear();

            return borrados;
        }

        public int UpdateDepartamento(int id, string nombre, string localidad)
        {
            string sql = "UPDATE DEPT SET DNOMBRE=@NOM, LOC=@LOC WHERE DEPT_NO=@NUM";
            SqlParameter paramId = new("@NUM", id);
            SqlParameter paramNombre = new("@NOM", nombre);
            SqlParameter paramLoc = new("@LOC", localidad);
            this.cmd.Parameters.Add(paramId);
            this.cmd.Parameters.Add(paramNombre);
            this.cmd.Parameters.Add(paramLoc);
            this.cmd.CommandText = sql;

            this.cn.Open();
            int modificados = this.cmd.ExecuteNonQuery();
            this.cn.Close();
            this.cmd.Parameters.Clear();

            return modificados;
        }

        public int InsertDepartamento(int id, string nombre, string localidad)
        {
            string sql = "INSERT INTO DEPT VALUES (@NUM, @NOM, @LOC)";
            SqlParameter paramId = new("@NUM", id);
            SqlParameter paramNombre = new("@NOM", nombre);
            SqlParameter paramLoc = new("@LOC", localidad);
            this.cmd.Parameters.Add(paramId);
            this.cmd.Parameters.Add(paramNombre);
            this.cmd.Parameters.Add(paramLoc);
            this.cmd.CommandText = sql;
            this.cmd.CommandType = System.Data.CommandType.Text;

            this.cn.Open();
            int insertados = this.cmd.ExecuteNonQuery();
            this.cn.Close();
            this.cmd.Parameters.Clear();

            return insertados;
        }
    }
}
