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

        public void DeleteDepartamento(int idDept)
        {
            //Departamento dept = this.FindDepartamento(idDept);
            Departamento dept = this.context.Departamentos.Find(idDept)!;
            this.context.Departamentos.Remove(dept);
            this.context.SaveChanges();
        }

        private int GetMaximo()
        {
            var maximo = (from datos in this.context.Departamentos select datos).Max(x => x.IdDeptartamento);
            return maximo + 1;
        }

        public void CreateDepartamento(string nombre, string localidad)
        {
            Departamento dept = new()
            {
                IdDeptartamento = this.GetMaximo(),
                Localidad = localidad,
                Nombre = nombre
            };

            this.context.Departamentos.Add(dept);
            this.context.SaveChanges();
        }

        public void UpdateDepartamento(Departamento newDept)
        {
            Departamento dept = this.context.Departamentos.Find(newDept.IdDeptartamento)!;
            dept.Nombre = newDept.Nombre;
            dept.Localidad = newDept.Localidad;
            this.context.SaveChanges();
        }
    }
}
