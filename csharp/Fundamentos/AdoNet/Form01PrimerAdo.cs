using System.Data;
using System.Data.SqlClient;

namespace AdoNet
{
    public partial class Form01PrimerAdo : Form
    {
        private string connectionString;
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public Form01PrimerAdo()
        {
            InitializeComponent();
            this.connectionString = "Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.cn = new SqlConnection(this.connectionString);
            this.com = new();
            this.cn.StateChange += Cn_StateChange;
        }

        private void Cn_StateChange(object sender, StateChangeEventArgs e)
        {
            this.lblMensaje.Text = "La conexion esta cambiando de: " + e.OriginalState + " a " + e.CurrentState;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cn.State == System.Data.ConnectionState.Closed)
                {
                    this.cn.Open();
                    this.lblMensaje.BackColor = Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = "Error: " + ex.Message;
                this.lblMensaje.BackColor = Color.Red;
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                this.cn.Close();
                this.lblMensaje.BackColor = Color.IndianRed;
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = "Error: " + ex.Message;
                this.lblMensaje.BackColor = Color.Red;
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            try
            {
                //// Create command
                //SqlCommand cmd = new("SELECT * FROM EMP", cn);

                //// 1. get an instance of the SqlDataReader
                //this.reader = cmd.ExecuteReader();

                //var columns = new List<string>();

                //for (int i = 0; i < reader.FieldCount; i++)
                //{
                //    this.lstColumnas.Items.Add(reader.GetName(i));
                //    this.lstTiposDato.Items.Add(reader.GetDataTypeName(i));
                //}

                //while (this.reader.Read())
                //{
                //    // get the results of each column
                //    string apellidos = (string)this.reader["APELLIDO"];
                //    this.lstApellidos.Items.Add(apellidos);
                //}

                this.reader.Close();

                string sql = "SELECT * FROM EMP";
                this.com.Connection = this.cn;
                this.com.CommandType = CommandType.Text;
                this.com.CommandText = sql;
                this.reader = this.com.ExecuteReader();

                /*
                    Get only one result

                    string columna = this.reader.GetName(0);
                    string tipo = this.reader.GetDataTypeName(0);
                    this.lstColumnas.Items.Add(columna);
                    this.lstTiposDato.Items.Add(tipo);

                    this.reader.Read();

                    string apellido = (string)this.reader["APELLIDO"];
                    this.lstApellidos.Items.Add(apellido);
                 */

                // Get all results
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    this.lstColumnas.Items.Add(reader.GetName(i));
                    this.lstTiposDato.Items.Add(reader.GetDataTypeName(i));
                }

                while (this.reader.Read())
                {
                    // get the results of each column
                    string apellidos = (string)this.reader["APELLIDO"];
                    this.lstApellidos.Items.Add(apellidos);
                }
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = "Error: " + ex.Message;
                this.lblMensaje.BackColor = Color.Red;
            }
        }
    }
}
