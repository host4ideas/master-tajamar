namespace Fundamentos
{
    public partial class Form12Metodos : Form
    {
        public Form12Metodos()
        {
            InitializeComponent();
        }

        private void GetDouble(int numero)
        {
            numero *= 2;
        }

        private void GetDoubleRef(ref int numero)
        {
            numero *= numero;
        }

        private int GetDoubleNum(int numero)
        {
            return numero *= 2;
        }

        private void btnDoubleVal_Click(object sender, EventArgs e)
        {
            int num = int.Parse(this.txtNum.Text);
            this.GetDouble(num);
            this.lblResult.Text = num.ToString();
        }

        private void btnDoubleRef_Click(object sender, EventArgs e)
        {
            int num = int.Parse(this.txtNum.Text);
            this.GetDoubleRef(ref num);
            this.lblResult.Text = num.ToString();
        }

        private void ChangeColor(Button button)
        {
            int r, g, b;
            r = new Random().Next(0, 255);
            g = new Random().Next(0, 255);
            b = new Random().Next(0, 255);
            button.BackColor = Color.FromArgb(r, g, b);
        }

        private void btnObjRef_Click(object sender, EventArgs e)
        {
            this.ChangeColor(this.btnDoubleNum);
            this.ChangeColor(this.btnDoubleVal);
            this.ChangeColor(this.btnDoubleRef);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int doubleNum = GetDoubleNum(int.Parse(this.txtNum.Text));
            this.lblResult.Text = doubleNum.ToString();
        }


        private void lblMouseHover_MouseMove(object sender, MouseEventArgs e)
        {
            this.lblMouseHover.Text = "X: " + e.X + ", Y: " + e.Y;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Tecla pulsada
            // e.KeyChar
            // No dejara que se dibuje el texto en el input
            // e.Handled = true;
            // Codigo de letras
            // char teclaBorrar = (char)8;
            char teclaBorrar = (char)Keys.Back;
            if (char.IsDigit(e.KeyChar) && e.KeyChar != teclaBorrar)
            {
                e.Handled = true; return;
            }
        }

        private void txtSoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            char teclaBorrar = (char)Keys.Delete;
            if (char.IsLetter(e.KeyChar) && e.KeyChar != teclaBorrar)
            {
                e.Handled = true; return;
            }
        }
    }
}
