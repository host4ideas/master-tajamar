namespace Fundamentos
{
    public partial class Form09ColeccionMultiple : Form
    {
        public Form09ColeccionMultiple()
        {
            InitializeComponent();
            this.lstElementos.SelectionMode = SelectionMode.MultiExtended;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string ele = this.txtEle.Text;
            lstElementos.Items.Add(ele);
            this.txtEle.Focus();
            this.txtEle.SelectAll();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // No podemos eliminar elemtnos utilizando un bucle de referencia
            // Debemos de recorrer todos lso elementos seleccionados
            // Nos interesa el index de cada elemento
            // Número de elementos seleccionados
            int numSeleccionados = this.lstElementos.SelectedItems.Count;
            for (int i = numSeleccionados - 1; i >= 0; i--)
            {
                // Recuperamos el índice seleccionado
                int indice = this.lstElementos.SelectedIndices[i];
                // Por último eliminamos el elemento por su indice
                this.lstElementos.Items.RemoveAt(indice);
            }
        }

        private void btnSeleccionados_Click(object sender, EventArgs e)
        {
            string indices = "";
            foreach (int indice in this.lstElementos.SelectedIndices)
            {
                indices += indice;
            }
            this.lblIndice.Text = indices.Trim(',');
            string items = "";
            foreach (string elem in this.lstElementos.SelectedItems)
            {
                items += elem + ",";
            }
            this.lblItem.Text = items;
        }

        private void btnEliminarTodo_Click(object sender, EventArgs e)
        {
            this.lstElementos.Items.Clear();
        }
    }
}
