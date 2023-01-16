namespace Fundamentos
{
    public partial class Form16TablaMultiplicar : Form
    {
        List<TextBox> lista;
        public Form16TablaMultiplicar()
        {
            InitializeComponent();
            this.lista = new List<TextBox>();

            foreach (Control control in this.panelTabla.Controls)
            {
                if (control is TextBox txtBox)
                {
                    this.lista.Add(txtBox);
                }
            }

            this.lista.Reverse();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            for (int i = lista.Count - 1; i >= 0; i--)
            {
                int multiplicando = i + 1;
                lista[i].Text = (int.Parse(txtNum.Text) * multiplicando).ToString();
            }
        }
    }
}
