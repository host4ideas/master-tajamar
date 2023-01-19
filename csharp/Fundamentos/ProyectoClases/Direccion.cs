using System.Diagnostics;

namespace ProyectoClases
{
    public class Direccion
    {
        #region CAMPOS DE PROPIEDAD
        public string Calle { get; set; }
        public int CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        #endregion

        public Direccion()
        {
            Debug.WriteLine("Constructor Direccion sin parametros");
        }

        public Direccion(string calle, string ciudad)
        {
            Calle = calle;
            Ciudad = ciudad;
            Debug.WriteLine("Contructor Direccion DOS parametros");
        }

        public Direccion(string calle, int codigoPostal, string ciudad)
        {
            Calle = calle;
            CodigoPostal = codigoPostal;
            Ciudad = ciudad;

            Debug.WriteLine("Contructor Direccion TRES parametros");
        }
    }
}
