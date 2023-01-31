using System.Data.SqlClient;

namespace AdoNet
{
    public partial class Form10HospitalEmpleados : Form
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader? reader;
        private List<int> hospitales;

        public Form10HospitalEmpleados()
        {
            InitializeComponent();
            this.hospitales = new List<int>();
            this.cn = new("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023");
            this.cmd = this.cn.CreateCommand();
            this.LoadHospitales();
        }

        private void LoadHospitales()
        {
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_HOSPITALES";

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            this.cmbHospital.Items.Clear();
            while (this.reader.Read())
            {
                string nombre = (string)this.reader["NOMBRE"];
                int hospitalCod = int.Parse((string)this.reader["HOSPITAL_COD"]);
                this.hospitales.Add(hospitalCod);
                this.cmbHospital.Items.Add(nombre);
            }
            this.reader.Close();
            this.cn.Close();
        }

        private void cmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmd.CommandType = System.Data.CommandType.StoredProcedure;
            this.cmd.CommandText = "SP_EMPLEADOS_HOSPITAL";

            SqlParameter paramHospitalCod = new("@HOSPITAL_COD", this.hospitales[this.cmbHospital.SelectedIndex]);
            this.cmd.Parameters.Add(paramHospitalCod);

            SqlParameter paramSuma = new()
            {
                ParameterName = "@SUMA",
                Direction = System.Data.ParameterDirection.Output,
                Value = 0
            };
            SqlParameter paramMedia = new()
            {
                ParameterName = "@MEDIA",
                Direction = System.Data.ParameterDirection.Output,
                Value = 0
            };
            SqlParameter paramPersonas = new()
            {
                ParameterName = "@PERSONAS",
                Direction = System.Data.ParameterDirection.Output,
                Value = 0
            };

            this.cmd.Parameters.Add(paramSuma);
            this.cmd.Parameters.Add(paramMedia);
            this.cmd.Parameters.Add(paramPersonas);

            this.cn.Open();
            this.reader = this.cmd.ExecuteReader();
            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                string nombre = (string)this.reader["APELLIDO"];
                this.lstEmpleados.Items.Add(nombre);
            }
            this.reader.Close();

            this.txtMedia.Text = paramMedia.Value.ToString();
            this.txtPersonas.Text = paramPersonas.Value.ToString();
            this.txtSuma.Text = paramSuma.Value.ToString();

            this.cmd.Parameters.Clear();
            this.cn.Close();
        }
    }
}
