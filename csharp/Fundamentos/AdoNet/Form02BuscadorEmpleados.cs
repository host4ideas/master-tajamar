using System.Data;
using System.Data.SqlClient;

namespace AdoNet
{
    public partial class Form02BuscadorEmpleados : Form
    {
        private string connectionString;
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public Form02BuscadorEmpleados()
        {
            InitializeComponent();
            this.connectionString = "Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.cn = new SqlConnection(this.connectionString);
            this.com = new();
            this.cn.StateChange += Cn_StateChange;
        }

        private void Cn_StateChange(object sender, StateChangeEventArgs e)
        {
            //this.lblMensaje.Text = "La conexion esta cambiando de: " + e.OriginalState + " a " + e.CurrentState;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int salario = int.Parse(this.txtSalario.Text);

            if(salario < 0 )
            {
                return;
            }

            string sql = "SELECT * FROM EMP WHERE SALARIO > " + salario;

            this.com.Connection = cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            // Abrimos conexion: ENTRAMOS
            this.cn.Open();
            // Ejecutamos consulta
            this.reader = com.ExecuteReader();

            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                string apellidoEmp = (string)this.reader["APELLIDO"];
                int salarioEmp = (int)this.reader["SALARIO"];

                this.lstEmpleados.Items.Add(apellidoEmp + " - " + salarioEmp);
            }

            this.reader.Close();
            this.cn.Close();
        }

        private void btnBuscarOficio_Click(object sender, EventArgs e)
        {
            string oficio = this.txtOficio.Text;

            string sql = $"SELECT * FROM EMP WHERE OFICIO = '{oficio}'";

            this.com.CommandType= CommandType.Text;
            this.com.CommandText= sql;
            this.com.Connection= cn;

            this.cn.Open();
            this.reader = com.ExecuteReader();
            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                string apellidos = (string)this.reader["APELLIDO"];
                this.lstEmpleados.Items.Add(apellidos);
            }
            this.cn.Close();
        }
    }
}
