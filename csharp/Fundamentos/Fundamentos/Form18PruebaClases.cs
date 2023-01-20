using ProyectoClases;
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

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            //Empleado empleado = new()
            //{
            //    Nombre = "Empleado",
            //    Apellidos = "Empleado"
            //};
            Empleado empleado = new("Empleado", "Curro");
            // Al estar el SalarioMinimo como protected no podemos acceder desde cualquier clase que no herede de Empleado
            //empleado.SalarioMinimo = 4000;
            this.lstDatos.Items.Add(empleado.GetNombreCompleto() + " " + empleado.GetSalarioMinimo() + " " + empleado.GetDiasVacaciones());
            Director director = new();
            director.Nombre = "Dire";
            director.Apellidos = "Dire";
            //this.lstDatos.Items.Add(director.GetNombreCompleto() + " " + director.GetSalarioMinimo() + " " + director.GetDiasVacaciones());
            this.lstDatos.Items.Add(director);
        }
    }
}
