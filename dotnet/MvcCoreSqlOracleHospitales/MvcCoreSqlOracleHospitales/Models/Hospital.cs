namespace MvcCoreSqlOracleHospitales.Models
{
    public class Hospital
    {
        public int HospitalCod { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int NumCamas { get; set; }
    }
}
