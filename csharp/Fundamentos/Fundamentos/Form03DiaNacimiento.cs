namespace Fundamentos
{
    public partial class Form03DiaNacimiento : Form
    {
        public Form03DiaNacimiento()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string[] diasSemana = new string[] { "sábado", "domingo", "lunes", "martes", "miércoles", "jueves", "viernes" };

            int diaNacimiento = int.Parse(this.textDay.Text);
            int mesNacimiento = int.Parse(this.textMonth.Text);
            int anioNacimiento = int.Parse(this.textYear.Text);

            if (mesNacimiento == 1)
            {
                mesNacimiento = 13;
                anioNacimiento -= 1;
            }
            else if (mesNacimiento == 2)
            {
                mesNacimiento = 14;
                anioNacimiento -= 1;
            }

            double stepOne = ((mesNacimiento + 1) * 3) / 5;

            double stepTwo = anioNacimiento / 4;

            double stepThree = anioNacimiento / 100;

            double stepFour = anioNacimiento / 400;

            double stepFive = diaNacimiento + (2 * mesNacimiento) + anioNacimiento + stepOne + stepTwo - stepThree + stepFour + 2;

            double stepSix = Math.Truncate(stepFive / 7);

            int stepSeven = (int)(stepFive - (stepSix * 7));
              
            string diaSemanaFinal = diasSemana[stepSeven];

            this.lblResult.Text = diaSemanaFinal;
        }
    }
}
