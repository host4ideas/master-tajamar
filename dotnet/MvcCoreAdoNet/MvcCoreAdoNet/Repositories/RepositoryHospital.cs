using MvcCoreAdoNet.Models;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryHospital
    {
        private readonly SqlConnection cn;
        private readonly SqlCommand cmd;
        private SqlDataReader? reader;

        public RepositoryHospital()
        {
            this.cn = new("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.cmd = this.cn.CreateCommand();
        }

        public List<Hospital> GetHospitales()
        {
            var hospitales = new List<Hospital>();
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = "SELECT * FROM HOSPITAL";

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            while (this.reader.Read())
            {
                hospitales.Add(new Hospital(
                    idHospital: int.Parse((string)this.reader["HOSPITAL_COD"]),
                    hospitalName: (string)this.reader["NOMBRE"],
                    telefono: (string)this.reader["TELEFONO"],
                    camas: int.Parse((string)this.reader["NUM_CAMA"])
                    ));
            }
            this.reader.Close();
            this.cn.Close();
            return hospitales;
        }

        public Hospital FindHospital(int idHospital)
        {
            string sql = "SELECT * FROM HOSPITAL WHERE HOSPITAL_COD = @IDHOSPITAL";
            SqlParameter idParam = new("@IDHOSPITAL", idHospital);
            this.cmd.Parameters.Add(idParam);

            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.CommandText = sql;

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            Hospital hospital = new(
                idHospital: int.Parse((string)this.reader["HOSPITAL_COD"]),
                hospitalName: (string)this.reader["NOMBRE"],
                telefono: (string)this.reader["TELEFONO"],
                camas: int.Parse((string)this.reader["NUM_CAMA"])
                );
            this.cmd.Parameters.Clear();
            this.reader.Close();
            this.cn.Close();
            return hospital;
        }
    }
}
