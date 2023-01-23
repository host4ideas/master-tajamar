using ProyectoClases.Helpers;
using ProyectoClases.Models;

namespace Fundamentos
{
    public partial class Form22Mascotas : Form
    {
        readonly HelperMascotas helper;

        public Form22Mascotas()
        {
            InitializeComponent();
            this.helper = new();
        }

        private void DibujarMascotas()
        {
            this.lstMascotas.Items.Clear();
            foreach (Mascota mascota in this.helper.Mascotas)
            {
                this.lstMascotas.Items.Add(mascota.Nombre!);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Mascota newMascota = new(this.txtNombre.Text, this.txtRaza.Text);

            this.helper.Mascotas.Add(newMascota);
            this.DibujarMascotas();
        }

        private async void btnLeerRegistros_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                await this.helper.ReadFileMascotasAsync(path);
                this.DibujarMascotas();
            }
        }

        private async void btnGuardarRegistros_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                await this.helper.SaveFileMascotasAsync(path);
                this.DibujarMascotas();
            }
        }

        private void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstMascotas.SelectedIndex != -1)
            {
                Mascota mascota = this.helper.Mascotas[this.lstMascotas.SelectedIndex];
                this.txtNombre.Text = mascota.Nombre;
                this.txtRaza.Text = mascota.Raza;
            }
        }
    }
}
