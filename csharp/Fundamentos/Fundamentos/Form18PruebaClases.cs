using ProyectoClases;

namespace Fundamentos
{
    public partial class Form18PruebaClases : Form
    {
        public Form18PruebaClases()
        {
            InitializeComponent();
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.Nombre = "Alumno";
            //persona.Apellidos = "Net Core";
            //persona.Edad = -9;

            persona.Domicilio = new Direccion("Calle Pepito", 36987, "Barcelona");
            //persona.DomicilioVacaciones = new Direccion("Calle Pez", 28564, "Madrid");

            this.lstDatos.Items.Add("Domicilio: " + persona.Domicilio.Ciudad);
            this.lstDatos.Items.Add("Domicilio Vacaciones: " + persona.DomicilioVacaciones.Ciudad);

            persona.Edad = 9;
            persona.Nacionalidad = Paises.España;
            persona.Genero = TipoGenero.Masculino;
            //this.lstDatos.Items.Add(persona.Nombre + " " + persona.Apellidos + " " + persona.Edad + " " + persona.Nacionalidad + " " + persona.Genero);
            //this.lstDatos.Items.Add(persona.GetNombreCompleto());
            persona.MetodoParametrosOpciones(77);
            persona.MetodoParametrosOpciones(77, 88);
            persona.MetodoParametrosOpciones(77, numero3: 55);
            persona.GetNombreCompleto();
            persona.GetNombreCompleto(true);
            persona.GetNombreCompleto(1, 2);
        }
    }
}
