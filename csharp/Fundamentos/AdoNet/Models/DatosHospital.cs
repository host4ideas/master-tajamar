namespace AdoNet.Models
{
    public class DatosHospital
    {
        public List<EmpleadoHospital> Empleados { get; set; }
        public int SumaSalarial { get; set; }
        public int MediaSalarial { get; set; }
        public int Personas { get; set; }
    }
}
