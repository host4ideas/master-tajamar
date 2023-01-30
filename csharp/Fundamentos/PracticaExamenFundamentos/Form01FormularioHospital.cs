namespace PracticaExamenFundamentos
{
    public partial class Form01FormularioHospital : Form
    {
        public Form01FormularioHospital()
        {
            InitializeComponent();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only letters
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar) && char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtNumCamas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }
    }
}
