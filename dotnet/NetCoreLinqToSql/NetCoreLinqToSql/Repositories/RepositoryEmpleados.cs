using NetCoreLinqToSql.Models;
using System.Data;
using System.Data.SqlClient;

namespace NetCoreLinqToSql.Repositories
{
    public class RepositoryEmpleados
    {
        private DataTable tablaEmpleados;

        public RepositoryEmpleados()
        {
            string connectioString = "Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            string sql = "SELECT * FROM EMP";
            SqlDataAdapter adpter = new SqlDataAdapter(sql, connectioString);

            this.tablaEmpleados = new DataTable();
            adpter.Fill(this.tablaEmpleados);
        }

        /// <summary>
        /// Recuperar los empleados
        /// </summary>
        /// <returns></returns>
        public List<Empleado> GetEmpleados()
        {
            // La tabla esta compuesta por filas (DataRow)
            // La consulta debe de ser sobre todas las filas de la tabla
            var consulta = from datos in this.tablaEmpleados.AsEnumerable() select datos;

            // Vamos a recorrer dotos los datos de la consulta y extraerlos
            List<Empleado> empleados = new();

            foreach (var row in consulta)
            {
                Empleado emp = new()
                {
                    IdEmpleado = row.Field<int>("EMP_NO"),
                    Apellido = row.Field<string>("APELLIDO")!,
                    Oficio = row.Field<string>("OFICIO")!,
                    Salario = row.Field<int>("SALARIO"),
                    IdDepartamento = row.Field<int>("DEPT_NO"),
                };
                empleados.Add(emp);
            }

            return empleados;
        }

        public Empleado FindEmpleado(int idEmpleado)
        {
            var consulta = from datos in this.tablaEmpleados.AsEnumerable()
                           where datos.Field<int>("EMP_NO") == idEmpleado
                           select datos;

            var row = consulta.First();

            Empleado emp = new()
            {
                IdEmpleado = row.Field<int>("EMP_NO"),
                Apellido = row.Field<string>("APELLIDO")!,
                Oficio = row.Field<string>("OFICIO")!,
                Salario = row.Field<int>("SALARIO"),
                IdDepartamento = row.Field<int>("DEPT_NO"),
            };

            return emp;
        }

        public List<Empleado> GetEmpleados(string oficio, int salario)
        {
            var consulta = from datos in this.tablaEmpleados.AsEnumerable()
                           where datos.Field<string>("OFICIO") == oficio && datos.Field<int>("SALARIO") == salario
                           select datos;

            if (consulta.Count() == 0)
            {
                List<Empleado> empleados = new();

                foreach (var row in consulta)
                {
                    empleados.Add(new Empleado
                    {
                        Apellido = row.Field<string>("APELLIDO"),
                        IdDepartamento = row.Field<int>("DEPT_NO"),
                        IdEmpleado = row.Field<int>("EMP_NO"),
                        Oficio = row.Field<string>("OFICIO"),
                        Salario = row.Field<int>("SALARIO")
                    });
                }

                return empleados;
            }
            return null;
        }
    }
}
