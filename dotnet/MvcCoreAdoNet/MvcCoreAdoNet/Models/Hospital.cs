namespace MvcCoreAdoNet.Models
{
    public class Hospital
    {
        public int IdHospital { get; set; }
        public string HospitalName { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Camas { get; set; }

        public Hospital() { }

        public Hospital(int idHospital, string hospitalName, string direccion, string telefono, int camas)
        {
            IdHospital = idHospital;
            HospitalName = hospitalName;
            Direccion = direccion;
            Telefono = telefono;
            Camas = camas;
        }
    }
}
