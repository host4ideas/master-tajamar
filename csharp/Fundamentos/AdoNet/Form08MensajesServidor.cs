using System.Data;
using System.Data.SqlClient;

namespace AdoNet
{
    public partial class Form08MensajesServidor : Form
    {
        private SqlCommand cmd;
        private SqlConnection cn;
        private SqlDataReader? reader;

        public Form08MensajesServidor()
        {
            InitializeComponent();
            this.cn = new("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.cmd = this.cn.CreateCommand();
            this.LoadDepartamentos();
            this.cn.InfoMessage += Cn_InfoMessage;
        }

        private void Cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.lblMensajes.Text = e.Message;
        }

        private void LoadDepartamentos()
        {
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_DEPARTAMENTOS";
            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            this.lstDepartamentos.Items.Clear();
            while (this.reader.Read())
            {
                int id = (int)this.reader["DEPT_NO"];
                string nombre = (string)this.reader["DNOMBRE"];
                string localidad = (string)this.reader["LOC"];
                this.lstDepartamentos.Items.Add(id + " - " + nombre + " - " + localidad);
            }
            this.reader.Close();
            this.cn.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.lblMensajes.Text = "";

            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_INSERT_DEPARTAMENTO";
            SqlParameter paramID = new SqlParameter("@ID", int.Parse(this.txtId.Text));
            SqlParameter paramNombre = new SqlParameter("@NOMBRE", this.txtNombre.Text);
            SqlParameter paramLoc = new SqlParameter("@LOCALIDAD", this.txtLoc.Text);
            this.cmd.Parameters.Add(paramID);
            this.cmd.Parameters.Add(paramNombre);
            this.cmd.Parameters.Add(paramLoc);

            this.cn.Open();
            int afectedRows = this.cmd.ExecuteNonQuery();
            this.cmd.Parameters.Clear();
            this.cn.Close();

            MessageBox.Show("Departamentos insertados: " + afectedRows.ToString());
            this.LoadDepartamentos();
        }
    }
}
