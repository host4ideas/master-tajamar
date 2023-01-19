using ProyectoClases;

namespace Fundamentos
{
    public partial class Form17MesesTemp : Form
    {
        List<string> meses;
        List<int> temperaturas;

        public Form17MesesTemp()
        {
            InitializeComponent();
            this.meses = new List<string>() { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviebre", "Diciembre" };
            this.temperaturas = new List<int>();
            GenerarMesesTemps();
        }

        private void GenerarMesesTemps()
        {
            this.lstMeses.Items.Clear();
            this.temperaturas = new List<int>();
            Random random = new();
            for (int i = 0; i < this.meses.Count; i++)
            {
                this.temperaturas.Add(random.Next(-15, 40));
                this.lstMeses.Items.Add(this.meses[i] + ":" + this.temperaturas[i]);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarMesesTemps();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int tempMax = 0;
            int tempMin = 0;

            for (int i = 0; i < this.meses.Count; i++)
            {
                if (this.temperaturas[i] < tempMin)
                {
                    tempMin = this.temperaturas[(int)i];
                }
                if (this.temperaturas[i] > tempMax)
                {
                    tempMax = this.temperaturas[(int)i];
                }
            }

            this.txtTempMax.Text = tempMax.ToString();
            this.txtTempMin.Text = tempMin.ToString();
        }
    }
}
