using System.Data;
using System.Data.SqlClient;

namespace AdoNet
{
    public partial class Form09ParametrosSalida : Form
    {
        private SqlCommand cmd;
        private SqlConnection conn;
        private SqlDataReader? reader;
        private List<int> departamentosIds;

        public Form09ParametrosSalida()
        {
            InitializeComponent();
            this.departamentosIds = new List<int>();
            this.conn = new("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.cmd = this.conn.CreateCommand();
            this.LoadDepartamentos();
        }

        private void LoadDepartamentos()
        {
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_DEPARTAMENTOS";
            this.conn.Open();
            this.reader = this.cmd.ExecuteReader();
            this.cmbDepartamentos.Items.Clear();
            while (this.reader.Read())
            {
                int id = (int)this.reader["DEPT_NO"];
                string nombre = (string)this.reader["DNOMBRE"];
                string localidad = (string)this.reader["LOC"];
                this.cmbDepartamentos.Items.Add(id + " - " + nombre + " - " + localidad);
                this.departamentosIds.Add(id);
            }
            this.reader.Close();
            this.conn.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_EMPLEADOS_DEPT";
            // Parametros entrada
            SqlParameter paramDeptNo = new("@DEPT_NO", this.departamentosIds[this.cmbDepartamentos.SelectedIndex]);
            this.cmd.Parameters.Add(paramDeptNo);

            // Parametros de salida
            SqlParameter paramSuma = new()
            {
                ParameterName = "@SUMA",
                Direction = ParameterDirection.Output,
                Value = 0
            };
            SqlParameter paramMedia = new()
            {
                ParameterName = "@MEDIA",
                Direction = ParameterDirection.Output,
                Value = 0
            };
            SqlParameter paramPersonas = new()
            {
                ParameterName = "@PERSONAS",
                Direction = ParameterDirection.Output,
                Value = 0
            };

            this.cmd.Parameters.Add(paramPersonas);
            this.cmd.Parameters.Add(paramMedia);
            this.cmd.Parameters.Add(paramSuma);

            this.conn.Open();
            this.reader = this.cmd.ExecuteReader();
            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                int id = (int)this.reader["EMP_NO"];
                string apellido = (string)this.reader["APELLIDO"];
                string oficio = (string)this.reader["OFICIO"];
                int salario = (int)this.reader["SALARIO"];
                this.lstEmpleados.Items.Add(id + " - " + apellido + " - " + oficio + " - " + salario);
            }
            this.reader.Close();
            
            this.txtMedia.Text = paramMedia.Value.ToString();
            this.txtPersonas.Text = paramPersonas.Value.ToString();
            this.txtSuma.Text = paramSuma.Value.ToString();

            this.cmd.Parameters.Clear();
            this.conn.Close();
        }

        private void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
