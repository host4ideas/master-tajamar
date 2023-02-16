using MvcCodeCrudDepartamentosEF.Data;
using MvcCodeCrudDepartamentosEF.Models;

namespace MvcCodeCrudDepartamentosEF.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;
        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int idDeptartamento)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDeptartamento == idDeptartamento
                           select datos;
            return consulta.FirstOrDefault();
        }
    }
}
