namespace MvcCoreAdoNet.Models
{
    public class Hospital
    {
        public int IdHospital { get; set; }
        public string HospitalName { get; set; }
        public string Telefono { get; set; }
        public int Camas { get; set; }

        public Hospital(int idHospital, string hospitalName, string telefono, int camas)
        {
            IdHospital = idHospital;
            HospitalName = hospitalName;
            Telefono = telefono;
            Camas = camas;
        }
    }
}
