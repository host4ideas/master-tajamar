using MvcCoreSqlOracleHospitales.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;

namespace MvcCoreSqlOracleHospitales.Repositories
{
    public class HospitalesRepositoryOracle : IHospitalesRepository
    {
        private OracleConnection cn;
        private OracleCommand cmd;
        private DataTable tablaHospitales;

        public HospitalesRepositoryOracle()
        {
            string connectionString = @"Data Source=LOCALHOST:1521;Persist Security Info=false;User ID=system;Password=oracle";
            // Linq
            string sql = "SELECT * FROM HOSPITAL";
            OracleDataAdapter adapter = new(sql, connectionString);
            this.tablaHospitales = new();
            adapter.Fill(tablaHospitales);
            // Ado.net
            this.cn = new(connectionString);
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

            OracleParameter paramCod = new(":HOSPITAL_COD", this.GetMaxHospital());
            this.cmd.Parameters.Add(paramCod);
            OracleParameter paramNombre = new(":NOMBRE", nombre);
            this.cmd.Parameters.Add(paramNombre);
            OracleParameter paramDireccion = new(":DIRECCION", direccion);
            this.cmd.Parameters.Add(paramDireccion);
            OracleParameter paramTelefono = new(":TELEFONO", telefono);
            this.cmd.Parameters.Add(paramTelefono);
            OracleParameter paramCamas = new(":NUM_CAMA", numCamas);
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

            OracleParameter paramCod = new(":HOSPITAL_COD", hospitalCod);
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

            OracleParameter paramCod = new(":HOSPITAL_COD", hospitalCod);
            this.cmd.Parameters.Add(paramCod);
            OracleParameter paramNombre = new(":NOMBRE", nombre);
            this.cmd.Parameters.Add(paramNombre);
            OracleParameter paramDireccion = new(":DIRECCION", direccion);
            this.cmd.Parameters.Add(paramDireccion);
            OracleParameter paramTelefono = new(":TELEFONO", telefono);
            this.cmd.Parameters.Add(paramTelefono);
            OracleParameter paramCamas = new(":NUM_CAMA", numCamas);
            this.cmd.Parameters.Add(paramCamas);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }
    }
}
