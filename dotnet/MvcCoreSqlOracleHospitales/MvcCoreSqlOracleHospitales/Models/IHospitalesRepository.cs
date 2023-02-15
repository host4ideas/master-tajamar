namespace MvcCoreSqlOracleHospitales.Models
{
    public interface IHospitalesRepository
    {
        public List<Hospital> GetHospitales();
        public void UpdateHospital(int hospitalCod, string nombre, string direccion, string telefono, int numCamas);
        public Hospital FindHospital(int hospitalCod);
        public void DeleteHospital(int hospitalCod);
        public void CreateHospital(string nombre, string direccion, string telefono, int numCamas);
    }
}
