namespace Fundamentos
{
    public partial class Form01SumarNumeros : Form
    {
        public Form01SumarNumeros()
        {
            InitializeComponent();
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            if (this.textNum1.Text != "" && this.textNum2.Text != "")
            {
                int numero1 = int.Parse(this.textNum1.Text);
                int numero2 = int.Parse(this.textNum2.Text);
                this.lblResult.Text = (numero1 + numero2).ToString();
            }
        }
    }
}
