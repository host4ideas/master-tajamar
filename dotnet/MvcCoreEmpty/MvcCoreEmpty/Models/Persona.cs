namespace MvcCoreEmpty.Models
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }

        public Persona(string nombre, string email, int edad)
        {
            Nombre = nombre;
            Email = email;
            Edad = edad;
        }
    }
}
