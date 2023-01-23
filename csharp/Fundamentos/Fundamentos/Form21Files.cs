using ProyectoClases.Helpers;

namespace Fundamentos
{
    public partial class asdf : Form
    {

        public asdf()
        {
            InitializeComponent();
        }

        private async void btnWriteFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new();
            if (save.ShowDialog() == DialogResult.OK)
            {
                string path = save.FileName;
                string contenido = this.GetStringNombres();
                await HelperFiles.WriteFileAsync(path, contenido);
                MessageBox.Show("Datos guardados");

                // Recargamos el fichero
                string fileContent = await HelperFiles.ReadFileAsync(path);
                this.txtFileContent.Text = fileContent;

                // Dibujamos los datos en un listbox
                this.SetStringNombres(fileContent);
            }
        }

        private async void btnReadFile_Click(object sender, EventArgs e)
        {
            // Objeto para abrir files
            OpenFileDialog ofd = new();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                string contenido = await HelperFiles.ReadFileAsync(path);
                this.txtFileContent.Text = contenido;

                // Dibujamos los datos en un listbox
                this.SetStringNombres(contenido);
            }
        }

        /// <summary>
        /// Metodo para recuperar todos los nombres de la lista separados por comas
        /// </summary>
        /// <returns></returns>
        public string GetStringNombres()
        {
            string datos = "";

            foreach (string nombre in this.lstNames.Items)
            {
                datos += nombre + ",";
            }

            datos = datos.Trim(',');
            return datos;
        }

        /// <summary>
        /// Metodo para recoger los nombres que tengamos en un string en el listbox
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void SetStringNombres(string data)
        {
            // Antonio, Adrian, Lucia
            string[] nombres = data.Split(',');
            this.lstNames.Items.Clear();
            foreach (string name in nombres)
            {
                this.lstNames.Items.Add(name);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nombre = this.txtName.Text;
            this.lstNames.Items.Add(nombre);
            this.txtName.SelectAll();
            this.txtName.Focus();
        }
    }
}
