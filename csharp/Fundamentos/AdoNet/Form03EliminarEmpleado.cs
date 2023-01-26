using System.Data;
using System.Data.SqlClient;

namespace AdoNet
{
    public partial class Form03EliminarEmpleado : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader? reader;

        public Form03EliminarEmpleado()
        {
            InitializeComponent();
            this.cn = new("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.com = new();
            this.com.Connection = cn;
            try
            {
                this.LoadEnfermos();
            }
            catch (Exception)
            {

            }
        }

        private void LoadEnfermos()
        {
            string sql = "SELECT * FROM ENFERMO";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.cn.Open();
            this.reader = com.ExecuteReader();

            this.lstEnfermos.Items.Clear();
            while (this.reader.Read())
            {
                string apellido = (string)this.reader["APELLIDO"];
                string inscripcion = (string)this.reader["INSCRIPCION"];
                this.lstEnfermos.Items.Add(apellido + " - " + inscripcion);
            }

            this.reader.Close();
            this.cn.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int inscripcion = int.Parse(this.txtInscripcion.Text);

            string sql = "DELETE FROM ENFERMO WHERE INSCRIPCION = @INSCRIPCION";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            SqlParameter paminscripcion = new("@INSCRIPCION", inscripcion);
            this.com.Parameters.Add(paminscripcion);

            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.cn.Close();
            // Borramos parametros para que no se dupliquen
            this.com.Parameters.Clear();

            MessageBox.Show("Enfermos eliminados " + eliminados);
            this.LoadEnfermos();
        }
    }
}
