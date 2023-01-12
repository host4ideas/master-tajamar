namespace Fundamentos
{
    public partial class Form10ColeccionRandom : Form
    {
        public Form10ColeccionRandom()
        {
            InitializeComponent();
            this.lstElementos.SelectionMode = SelectionMode.MultiExtended;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int valor = random.Next(1, 200);
            this.lstElementos.Items.Add(valor);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int count = this.lstElementos.Items.Count;
            int suma = 0;
            int sumaPares = 0;
            int sumaImpares = 0;

            for (int i = 0; i < count; i++)
            {
                int itemParsed = int.Parse(this.lstElementos.Items[i].ToString()!);

                suma += itemParsed;
                if (itemParsed % 2 == 0)
                {
                    sumaPares += itemParsed;
                }
                else
                {
                    sumaImpares += itemParsed;
                }
            }

            this.txtPares.Text = sumaPares.ToString();
            this.txtImpares.Text = sumaImpares.ToString();
            this.txtSuma.Text = suma.ToString();
        }

        private void btnMostrarSeleccionados_Click(object sender, EventArgs e)
        {
            int suma = 0;
            int sumaPares = 0;
            int sumaImpares = 0;

            foreach (int item in this.lstElementos.SelectedItems)
            {
                suma += item;

                if (item % 2 == 0)
                {
                    sumaPares += item;
                }
                else
                {
                    sumaImpares += item;
                }
            }

            this.txtPares.Text = sumaPares.ToString();
            this.txtImpares.Text = sumaImpares.ToString();
            this.txtSuma.Text = suma.ToString();
        }
    }
}
