namespace MvcCoreMultiplesBBDD.Models
{
    public interface IRepositoryEmpleados
    {
        public List<Empleado> GetEmpleados();
        public Empleado FindEmpleado(int idEmpleado);
        public Task DeleteEmpleado(int id);
        public Task UpdateEmpleado(int id, int salario, string oficio);
        public Empleado EmpleadoDetails(int id);
    }
}
