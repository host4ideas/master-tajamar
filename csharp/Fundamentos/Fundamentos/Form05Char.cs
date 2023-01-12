namespace Fundamentos
{
    public partial class Form05Char : Form
    {
        public Form05Char()
        {
            InitializeComponent();
        }

        private void btnRecorrer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 255; i++)
            {
                char caracter = (char)i;
                if (char.IsLetter(caracter))
                {
                    this.txtLetras.Text += caracter;

                }
                else if (char.IsNumber(caracter))
                {
                    this.txtNumeros.Text += caracter;
                }
                else if (char.IsSymbol(caracter))
                {
                    this.txtSimbolos.Text += caracter;
                }
                else if (char.IsPunctuation(caracter))
                {
                    this.txtPuntuacion.Text += caracter;
                }
            }
        }
    }
}
