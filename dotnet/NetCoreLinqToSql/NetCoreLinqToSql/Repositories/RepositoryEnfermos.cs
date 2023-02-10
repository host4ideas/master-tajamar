using NetCoreLinqToSql.Models;
using System.Data;
using System.Data.SqlClient;

namespace NetCoreLinqToSql.Repositories
{
    public class RepositoryEnfermos
    {
        private DataTable tablaEnfermos;
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader? reader;

        public RepositoryEnfermos()
        {
            string connectioNString = "Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            // Ado
            this.cn = new(connectioNString);
            this.cmd = this.cn.CreateCommand();
            // Linq
            string sql = "SELECT * FROM ENFERMO";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connectioNString);
            this.tablaEnfermos = new();
            adapter.Fill(this.tablaEnfermos);
        }

        public List<Enfermo> GetEnfermos()
        {
            var consulta = from datos in this.tablaEnfermos.AsEnumerable() select datos;

            List<Enfermo> enfermos = new();

            foreach (var row in consulta)
            {
                enfermos.Add(new Enfermo
                {
                    Apellido = row.Field<string>("APELLIDO"),
                    Direccion = row.Field<string>("DIRECCION"),
                    FechaNacimiento = row.Field<DateTime>("FECHA_NAC"),
                    Inscripcion = row.Field<string>("INSCRIPCION"),
                    Nss = row.Field<string>("NSS"),
                    Sexo = row.Field<string>("S")
                });
            }
            return enfermos;
        }

        public List<Enfermo> GetEnfermos(DateTime fechaNacimiento)
        {
            var consulta = from datos in this.tablaEnfermos.AsEnumerable()
                           where datos.Field<DateTime>("FECHA_NAC") == fechaNacimiento
                           select datos;

            if (!consulta.Any())
            {
                return null;
            }

            List<Enfermo> enfermos = new();

            foreach (var row in consulta)
            {
                enfermos.Add(new Enfermo
                {
                    Apellido = row.Field<string>("APELLIDO"),
                    Direccion = row.Field<string>("DIRECCION"),
                    FechaNacimiento = row.Field<DateTime>("FECHA_NAC"),
                    Inscripcion = row.Field<string>("INSCRIPCION"),
                    Nss = row.Field<string>("NSS"),
                    Sexo = row.Field<string>("S")
                });
            }
            return enfermos;
        }

        public void Delete(string inscripcion)
        {
            this.cmd.CommandType = CommandType.Text;
            this.cmd.CommandText = "DELETE FROM ENFERMO WHERE INSCRIPCION = @INSCRIPCION";
            SqlParameter paramIns = new("@INSCRIPCION", inscripcion);
            this.cmd.Parameters.Add(paramIns);

            this.cn.Open();
            this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();
        }
    }
}
