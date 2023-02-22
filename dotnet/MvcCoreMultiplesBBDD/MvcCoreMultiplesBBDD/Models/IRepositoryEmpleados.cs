namespace MvcCoreMultiplesBBDD.Models
{
    public interface IRepositoryEmpleados
    {
        public List<Empleado> GetEmpleados();
        public Empleado FindEmpleado(int idEmpleado);
    }
}
