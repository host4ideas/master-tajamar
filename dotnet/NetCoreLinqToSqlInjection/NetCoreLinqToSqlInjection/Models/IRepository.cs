namespace NetCoreLinqToSqlInjection.Models
{
    public interface IRepository
    {
        List<Doctor> GetDoctores();
        void InsertarDoctor(string hospitalCod, string apellido, string especialidad, int salario);
        void DeleteDoctor(int iddoctor);
    }
}
