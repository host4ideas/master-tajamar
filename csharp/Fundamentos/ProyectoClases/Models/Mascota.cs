using System.Drawing;

namespace ProyectoClases.Models
{
    public class Mascota
    {
        public string? Nombre { get; set; }
        public string? Raza { get; set; }
        public int? Years { get; set; }

        public byte[] Imagen { get; set; }

        public Mascota() { }

        public Mascota(string nombre, string raza, int years = 0)
        {
            this.Nombre = nombre;
            this.Raza = raza;
            if (years != 0)
            {
                Years = years;
            }
        }
    }
}
