namespace MvcCoreAdoNet.Models
{
    public class Mascota
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public Mascota(string nombre, string tipo)
        {
            Nombre = nombre;
            Tipo = tipo;
        }
    }
}
