using ProyectoClases.Models;
using System.Xml.Serialization;

namespace Fundamentos
{
    public partial class Form24ColeccionXMLMascotas : Form
    {
        readonly XmlSerializer serializer;
        List<Mascota> coleccionMascotas;

        public Form24ColeccionXMLMascotas()
        {
            InitializeComponent();
            this.coleccionMascotas = new();
            serializer = new(typeof(List<Mascota>));
        }

        private void btnNuevaMascota_Click(object sender, EventArgs e)
        {
            Mascota mascota = new()
            {
                Nombre = this.txtNombre.Text,
                Raza = this.txtRaza.Text,
                Years = int.Parse(this.txtEdad.Text)
            };

            this.coleccionMascotas.Add(mascota);
            this.txtRaza.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtEdad.Text = string.Empty;
            this.DibujarMascotas();
        }

        private void DibujarMascotas()
        {
            this.lstMascotas.Items.Clear();
            foreach (Mascota mascota in this.coleccionMascotas)
            {
                this.lstMascotas.Items.Add(mascota.Nombre!);
            }
        }

        private async void btnGuardarRegistros_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new("coleccionMascotas.xml"))
            {
                this.serializer.Serialize(writer, this.coleccionMascotas);
                await writer.FlushAsync();
                writer.Close();
            }

            this.lstMascotas.Items.Clear();
            this.coleccionMascotas.Clear();
        }

        private void btnLeerRegistros_Click(object sender, EventArgs e)
        {
            this.lstMascotas.Items.Clear();
            this.coleccionMascotas.Clear();

            using (StreamReader reader = new("coleccionMascotas.xml"))
            {
                this.coleccionMascotas = (List<Mascota>)this.serializer.Deserialize(reader)!;
                this.DibujarMascotas();
            }
        }

        private void lstMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lstMascotas.SelectedIndex != -1)
            {
                Mascota mascotaSeleccionada = this.coleccionMascotas[this.lstMascotas.SelectedIndex];
                this.txtEdad.Text = mascotaSeleccionada.Years.ToString();
                this.txtNombre.Text = mascotaSeleccionada.Nombre;
                this.txtRaza.Text = mascotaSeleccionada.Raza;
            }
        }
    }
}
