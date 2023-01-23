using ProyectoClases.Models;
using System.Xml.Serialization;

namespace Fundamentos
{
    public partial class Form23ObjetoXMLMascota : Form
    {
        XmlSerializer serializer;
        public Form23ObjetoXMLMascota()
        {
            InitializeComponent();
            // En el momento de isntanciar el bjeto, será necesario indicar el tipo que utilizara
            this.serializer = new(typeof(Mascota));
        }

        private void btnLeerDato_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new("mascotas.xml"))
            {
                Mascota mascota = (Mascota)this.serializer.Deserialize(reader)!;
                this.txtNombre.Text = mascota.Nombre;
                this.txtRaza.Text = mascota.Raza;
                this.txtEdad.Text = mascota.Years.ToString();
                reader.Close();
            }
        }

        private async void btnGuardarDato_Click(object sender, EventArgs e)
        {
            Mascota mascota = new(
                nombre: this.txtNombre.Text,
                raza: this.txtRaza.Text,
                years: int.Parse(this.txtEdad.Text));

            using (StreamWriter writer = new("mascotas.xml"))
            {
                // El serializador XML tiene un método llmada Serialize() que utiliza el fichero para guardar el objeto
                this.serializer.Serialize(writer, mascota);
                await writer.FlushAsync();
                writer.Close();
            }

            this.txtRaza.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtEdad.Text = string.Empty;
        }
    }
}
