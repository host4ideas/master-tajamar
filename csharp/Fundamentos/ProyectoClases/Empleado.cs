using System.Diagnostics;

namespace ProyectoClases
{
    public class Empleado : Persona
    {
        protected int SalarioMinimo { get; set; }

        public Empleado()
        {
            Debug.WriteLine("Constuctor EMPLEADO vacío");
            this.SalarioMinimo = 1000;
        }

        // Poniendo :base podemos evitar pasar por el constructor por defecto de la clase Persona
        public Empleado(string nombre, string apellidos) : base(nombre, apellidos)
        {
            Debug.WriteLine("Constructor EMPLEADO dos parámetros");
            this.SalarioMinimo = 1000;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
        }

        public int GetSalarioMinimo()
        {
            return this.SalarioMinimo;
        }

        public virtual int GetDiasVacaciones()
        {
            Debug.WriteLine("GetVacaciones() EMPLEADO");
            return 22;
        }
    }
}
