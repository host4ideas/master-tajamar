using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AdoNet
{
    public partial class Form05DepartamentosEmpleados : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader? reader;

        public Form05DepartamentosEmpleados()
        {
            InitializeComponent();
            this.cn = new SqlConnection("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.com = new SqlCommand();
            this.com.Connection = cn;
            this.LoadDepartamentos();
        }

        private void LoadEmpleados()
        {
            if (this.lstDepartamentos.SelectedIndex == -1)
            {
                return;
            }

            string departamento = (string)this.lstDepartamentos.SelectedItem;

            string sql = "SELECT EMP.APELLIDO FROM EMP INNER JOIN DEPT ON EMP.DEPT_NO = DEPT.DEPT_NO WHERE DEPT.DNOMBRE = @DEPARTAMENTO";
            SqlParameter paramDepartamento = new("@DEPARTAMENTO", departamento);
            this.com.Parameters.Add(paramDepartamento);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.lstEmpleados.Items.Clear();

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string nombre = (string)this.reader["APELLIDO"];
                this.lstEmpleados.Items.Add(nombre);
            }
            this.com.Parameters.Clear();
            this.cn.Close();
        }

        private void LoadDepartamentos()
        {
            string sql = "SELECT DNOMBRE FROM DEPT GROUP BY DEPT.DNOMBRE";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.lstDepartamentos.Items.Clear();

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string nombre = (string)this.reader["DNOMBRE"];
                this.lstDepartamentos.Items.Add(nombre);
            }
            this.cn.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string empleado = (string)this.lstEmpleados.SelectedItem;
            string nuevoOficio = this.txtOficio.Text;
            string nuevoSalario = this.txtSalario.Text;

            string sql1 = "UPDATE EMP SET OFICIO = @OFICIO, SALARIO = @SALARIO WHERE EMP.APELLIDO = @EMPLEADO";

            SqlParameter paramEmpleado = new("@EMPLEADO", empleado);
            SqlParameter paramOficio = new("@OFICIO", nuevoOficio);
            SqlParameter paramSalario = new("@SALARIO", nuevoSalario);
            this.com.Parameters.Add(paramEmpleado);
            this.com.Parameters.Add(paramOficio);
            this.com.Parameters.Add(paramSalario);

            // Update
            this.com.CommandText = sql1;
            this.cn.Open();
            int elementosModificados1 = this.com.ExecuteNonQuery();

            this.cn.Close();
            this.com.Parameters.Clear();

            MessageBox.Show($"{elementosModificados1} empleado modificado");
            this.LoadDepartamentos();
            this.LoadEmpleados();
        }

        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadEmpleados();
        }

        private void lstEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string apellido = (string)this.lstEmpleados.SelectedItem;

            string sql = "SELECT EMP.SALARIO, EMP.APELLIDO, EMP.OFICIO FROM EMP GROUP BY EMP.APELLIDO, EMP.OFICIO, EMP.SALARIO HAVING EMP.APELLIDO = @APELLIDO";
            SqlParameter paramApellido= new("@APELLIDO", apellido);
            this.com.Parameters.Add(paramApellido);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                int salario = (int)this.reader["SALARIO"];
                string oficio = (string)this.reader["OFICIO"];
                this.txtOficio.Text = oficio;
                this.txtSalario.Text = salario.ToString();
            }
            this.com.Parameters.Clear();
            this.cn.Close();
        }
    }
}
