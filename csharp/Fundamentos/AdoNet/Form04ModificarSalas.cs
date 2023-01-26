using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet
{
    public partial class Form04ModificarSalas : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader? reader;

        public Form04ModificarSalas()
        {
            InitializeComponent();
            this.cn= new SqlConnection("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.com= new SqlCommand();
            this.com.Connection= cn;
            this.LoadSalas();
        }

        private void LoadSalas()
        {
            string sql = "SELECT SALA.NOMBRE FROM SALA GROUP BY SALA.NOMBRE";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.lstSalas.Items.Clear();

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string nombre = (string)this.reader["NOMBRE"];
                this.lstSalas.Items.Add(nombre);
            }
            this.cn.Close();
        }

        private void btnModificarSalas_Click(object sender, EventArgs e)
        {
            if(this.lstSalas.SelectedIndex == -1)
            {
                return;
            }

            string nuevo = this.txtNuevoNombre.Text;
            string salaModificar = (string)this.lstSalas.SelectedItem;

            string sql = "UPDATE SALA SET NOMBRE = @NOMBRE WHERE SALA.NOMBRE = @SALA";
            SqlParameter paramNuevo = new("@NOMBRE", nuevo);
            SqlParameter paramSala = new("@SALA", salaModificar);
            this.com.Parameters.Add(paramNuevo);
            this.com.Parameters.Add(paramSala);
            this.com.CommandText = sql;

            this.cn.Open();
            int elementosModificados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();

            MessageBox.Show($"{elementosModificados} sala(s) modificada");
            this.LoadSalas();
        }
    }
}
