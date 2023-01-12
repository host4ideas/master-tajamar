namespace Fundamentos
{
    public partial class Form08ColeccionGrafica : Form
    {
        public Form08ColeccionGrafica()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string ele = this.txtEle.Text;
            this.lstElementos.Items.Add(ele);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //string seleccionado = this.lstElementos.SelectedItem.ToString()!;
            //this.lstElementos.Items.Remove(seleccionado);
            int indice = this.lstElementos.SelectedIndex;
            this.lstElementos.Items.RemoveAt(indice);
        }

        private void btnEliminarTodo_Click(object sender, EventArgs e)
        {
            this.lstElementos.Items.Clear();
        }

        private void lstElementos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstElementos.SelectedIndex != -1)
            {
                this.lblIndice.Text = this.lstElementos.SelectedIndex.ToString();
                this.lblItem.Text = this.lstElementos.SelectedItem.ToString();
            }
        }
    }
}
