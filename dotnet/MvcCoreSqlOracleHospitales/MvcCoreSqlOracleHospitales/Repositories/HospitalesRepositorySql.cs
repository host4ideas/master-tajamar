using MvcCoreSqlOracleHospitales.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace MvcCoreSqlOracleHospitales.Repositories
{
    public class HospitalesRepositorySql : IHospitalesRepository
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        private DataTable tablaHospitales;

        public HospitalesRepositorySql()
        {
            string connectionString = "Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            // Linq
            string sql = "SELECT * FROM HOSPITAL";
            SqlDataAdapter adapter = new(sql, connectionString);
            this.tablaHospitales = new();
            adapter.Fill(tablaHospitales);
            // Ado.net
            this.cn = new SqlConnection(connectionString);
            this.cmd = this.cn.CreateCommand();
        }

        private int GetMaxHospital()
        {
            var maximo = (from datos in this.tablaHospitales.AsEnumerable() select datos).Max(x => x.Field<int>("HOSPITAL_COD") + 1);
            return maximo;
        }

        public void CreateHospital(string nombre, string direccion, string telefono, int numCamas)
        {
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_CREATE_HOSPITAL";

            SqlParameter paramCod = new("@HOSPITAL_COD", this.GetMaxHospital());
            this.cmd.Parameters.Add(paramCod);
            SqlParameter paramNombre = new("@NOMBRE", nombre);
            this.cmd.Parameters.Add(paramNombre);
            SqlParameter paramDireccion = new("@DIRECCION", direccion);
            this.cmd.Parameters.Add(paramDireccion);
            SqlParameter paramTelefono = new("@TELEFONO", telefono);
            this.cmd.Parameters.Add(paramTelefono);
            SqlParameter paramCamas = new("@NUM_CAMA", numCamas);
            this.cmd.Parameters.Add(paramCamas);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }

        public void DeleteHospital(int hospitalCod)
        {
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_DELETE_HOSPITAL";

            SqlParameter paramCod = new("@HOSPITAL_COD", hospitalCod);
            this.cmd.Parameters.Add(paramCod);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }

        public Hospital FindHospital(int hospitalCod)
        {
            var consulta = from datos in this.tablaHospitales.AsEnumerable()
                           where datos.Field<int>("HOSPITAL_COD") == hospitalCod
                           select datos;

            var row = consulta.First();

            var hospital = new Hospital()
            {
                Direccion = row.Field<string>("DIRECCION"),
                HospitalCod = row.Field<int>("HOSPITAL_COD"),
                Nombre = row.Field<string>("NOMBRE"),
                NumCamas = row.Field<int>("NUM_CAMA"),
                Telefono = row.Field<string>("TELEFONO")
            };

            return hospital;
        }

        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.tablaHospitales.AsEnumerable()
                           select new Hospital()
                           {
                               Direccion = datos.Field<string>("DIRECCION"),
                               HospitalCod = datos.Field<int>("HOSPITAL_COD"),
                               Nombre = datos.Field<string>("NOMBRE"),
                               NumCamas = datos.Field<int>("NUM_CAMA"),
                               Telefono = datos.Field<string>("TELEFONO")
                           };

            return consulta.ToList();
        }

        public void UpdateHospital(int hospitalCod, string nombre, string direccion, string telefono, int numCamas)
        {
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_UPDATE_HOSPITAL";

            SqlParameter paramCod = new("@HOSPITAL_COD", hospitalCod);
            this.cmd.Parameters.Add(paramCod);
            SqlParameter paramNombre = new("@NOMBRE", nombre);
            this.cmd.Parameters.Add(paramNombre);
            SqlParameter paramDireccion = new("@DIRECCION", direccion);
            this.cmd.Parameters.Add(paramDireccion);
            SqlParameter paramTelefono = new("@TELEFONO", telefono);
            this.cmd.Parameters.Add(paramTelefono);
            SqlParameter paramCamas = new("@NUM_CAMA", numCamas);
            this.cmd.Parameters.Add(paramCamas);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }
    }
}
