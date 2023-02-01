using AdoNet.Models;
using System.Data;
using System.Data.SqlClient;
using AdoNet.Helpers;

namespace AdoNet.Repositories
{
    public class RepositoryHospital
    {
        readonly SqlConnection cn;
        readonly SqlCommand com;
        SqlDataReader? reader;

        public RepositoryHospital()
        {
            this.cn = new SqlConnection(HelperConfiguration.GetConnectionString());
            this.com = this.cn.CreateCommand();
        }

        //NECESITAMOS UN METODO PARA DEVOLVER TODOS LOS HOSPITALES
        public List<string> GetHospitales()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_HOSPITALES";
            List<string> hospitales = new();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string nombre = (string)this.reader["NOMBRE"];
                hospitales.Add(nombre);
            }
            this.reader.Close();
            this.cn.Close();
            return hospitales;
        }

        public DatosHospital GetDatosHospital(string nombre)
        {
            SqlParameter pamnombre = new("@NOMBRE", nombre);
            this.com.Parameters.Add(pamnombre);
            SqlParameter pamsuma = new("@SUMA", 0)
            {
                Direction = ParameterDirection.Output
            };
            this.com.Parameters.Add(pamsuma);
            SqlParameter pammedia = new("@MEDIA", 0)
            {
                Direction = ParameterDirection.Output
            };
            this.com.Parameters.Add(pammedia);
            SqlParameter pampersonas = new("@PERSONAS", 0)
            {
                Direction = ParameterDirection.Output
            };
            this.com.Parameters.Add(pampersonas);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_EMPLEADOS_HOSPITAL";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<EmpleadoHospital> empleados = new();
            while (this.reader.Read())
            {
                int idempleado = int.Parse((string)this.reader["IDEMPLEADO"]);
                string apellido = (string)this.reader["APELLIDO"];
                int salario = int.Parse(this.reader["SALARIO"].ToString()!);
                EmpleadoHospital empleado = new()
                {
                    IdEmpleado = idempleado,
                    Apellido = apellido,
                    Salario = salario,
                };
                empleados.Add(empleado);
            }
            this.reader.Close();
            DatosHospital datos = new()
            {
                Empleados = empleados,
                SumaSalarial = int.Parse(pamsuma.Value.ToString()!),
                MediaSalarial = int.Parse(pammedia.Value.ToString()!),
                Personas = int.Parse(pampersonas.Value.ToString()!)
            };
            this.cn.Close();
            this.com.Parameters.Clear();
            return datos;
        }
    }
}
