
using System.Diagnostics;

namespace Fundamentos
{
    public partial class Form11TiendaProductos : Form
    {
        public Form11TiendaProductos()
        {
            InitializeComponent();
            this.lstTienda.SelectionMode = SelectionMode.MultiExtended;
            Stopwatch krono;
        }

        private void MetodoInsert()
        {
            if (this.txtProducto.Text.Length > 0)
            {
                if (this.lstTienda.Items.IndexOf(this.txtProducto.Text) < 0)
                {
                    this.lstTienda.Items.Add(this.txtProducto.Text);
                }
                else
                {
                    this.lstTienda.SelectedIndex = this.lstTienda.Items.IndexOf(this.txtProducto.Text);
                }
            }
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MetodoInsert();
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Creating and initializing threads
            Thread thr1 = new Thread(MetodoInsert);
            thr1.Start();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int count = this.lstTienda.SelectedIndices.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                //int indiceSelccionado = this.lstTienda.SelectedIndices[i];
                //this.lstTienda.Items.RemoveAt(indiceSelccionado);

                int indiceSelccionado = this.lstTienda.SelectedIndices[i];
                int indiceAlmacen = this.lstAlmacen.Items.IndexOf(this.lstTienda.Items[indiceSelccionado]);
                this.lstTienda.Items.RemoveAt(indiceSelccionado);
                this.lstAlmacen.Items.RemoveAt(indiceAlmacen);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.txtProducto.Text.Length > 0)
            {
                int count = this.lstTienda.SelectedIndices.Count;

                for (int i = 0; i < count; i++)
                {
                    int indiceSelccionado = this.lstTienda.SelectedIndices[i];
                    int indiceAlmacen = this.lstAlmacen.Items.IndexOf(this.lstTienda.Items[indiceSelccionado]);
                    this.lstAlmacen.Items[indiceAlmacen] = this.txtProducto.Text;
                    this.lstTienda.Items[indiceSelccionado] = this.txtProducto.Text;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lstTienda.Items.Clear();
            this.lstAlmacen.Items.Clear();
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            int count = this.lstTienda.SelectedIndices.Count;
            for (int i = 0; i < count; i++)
            {
                int indiceSelccionado = this.lstTienda.SelectedIndices[i];
                this.lstAlmacen.Items.Add(this.lstTienda.Items[indiceSelccionado]);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            int count = this.lstTienda.Items.Count;
            for (int i = 0; i < count; i++)
            {
                this.lstAlmacen.Items.Add(this.lstTienda.Items[i]);
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (lstAlmacen.SelectedItem != null)
            {
                int oldIndex = this.lstAlmacen.Items.IndexOf(this.lstAlmacen.SelectedItem);

                if (oldIndex <= this.lstAlmacen.Items.Count)
                {
                    int newIndex = oldIndex - 1;

                    var item = this.lstAlmacen.Items[oldIndex];

                    this.lstAlmacen.Items.RemoveAt(oldIndex);

                    this.lstAlmacen.Items.Insert(newIndex, item);

                    this.lstAlmacen.SelectedIndex = newIndex;
                }
            }
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            if (lstAlmacen.SelectedItem != null)
            {
                int oldIndex = this.lstAlmacen.Items.IndexOf(this.lstAlmacen.SelectedItem);

                if (oldIndex + 1 < this.lstAlmacen.Items.Count)
                {
                    int newIndex = oldIndex + 1;

                    var item = this.lstAlmacen.Items[oldIndex];

                    this.lstAlmacen.Items.RemoveAt(oldIndex);

                    this.lstAlmacen.Items.Insert(newIndex, item);

                    this.lstAlmacen.SelectedIndex = newIndex;
                }
            }
        }
    }
}
