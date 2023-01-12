namespace Fundamentos
{
    public partial class Form06Email : Form
    {
        public Form06Email()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            Boolean isError = false;
            string email = this.txtEmail.Text;

            if (email.Length > 0)
            {
                int indexofArroba = email.IndexOf('@');
                if (indexofArroba > 0)
                {
                    email = email.Trim();
                    email = email.Trim('@');
                    int indexOfDot = email.IndexOf(".");

                    if (indexofArroba < 0 || indexofArroba > indexOfDot)
                    {
                        this.txtResult.Text = "El punto está antes de la @";
                        isError = true;
                    }

                    string[] splittedEmail = email.Split("@");
                    if (splittedEmail.Length > 2)
                    {
                        this.txtResult.Text = "Existe más de una @";
                        isError = true;
                    }

                    if (indexOfDot < 0 || email.Substring(indexOfDot).Length <= 2 || email.Substring(indexOfDot).Length >= 5)
                    {
                        this.txtResult.Text = "El dominio no es válido";
                        isError = true;
                    }
                }
                else
                {
                    this.txtResult.Text = "No existe una @ o la has insertado al principio";
                    isError = true;
                }
            }
            else
            {
                this.txtResult.Text = "Introduce un email";
                isError = true;
            }

            if (!isError)
            {
                this.txtResult.Text = "El email es válido";
            }
        }
    }
}
