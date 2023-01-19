using ProyectoClases;
using System.Diagnostics;

namespace Fundamentos
{
    public partial class Form19TemperaturaClases : Form
    {
        List<string> meses;
        List<Temperatura> temperaturas;

        public Form19TemperaturaClases()
        {
            this.meses = new List<string>() { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviebre", "Diciembre" };
            this.temperaturas = new List<Temperatura>();
            //GenerarMesesTemps();
            InitializeComponent();
        }

        private void GenerarMesesTemps()
        {
            Debug.WriteLine(this.lstMeses);
            if(this.lstMeses.SelectedItems.Count > 0)
            {
                this.lstMeses.Items.Clear();
            }
            this.temperaturas = new List<Temperatura>();
            Random random = new();

            for (int i = 0; i < this.meses.Count; i++)
            {
                this.temperaturas.Add(new Temperatura(random.Next(-15, 40), random.Next(-15, 40)));
                this.lstMeses.Items.Add(this.meses[i] + ":" + this.temperaturas[i]);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarMesesTemps();
        }

        private void btnMostrar_Click_1(object sender, EventArgs e)
        {
            this.txtTempMax.Text = this.temperaturas[this.lstMeses.SelectedIndex].TempMax.ToString();
            this.txtTempMin.Text = this.temperaturas[this.lstMeses.SelectedIndex].TempMin.ToString();
            this.txtTempMedia.Text = this.temperaturas[this.lstMeses.SelectedIndex].TempMedia.ToString();
        }
    }
}
