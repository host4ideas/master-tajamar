using ApiCoreCrudDepartamentos.Data;
using ApiCoreCrudDepartamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDepartamentos.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext departamentosContext;

        public RepositoryDepartamentos(DepartamentosContext departamentosContext)
        {
            this.departamentosContext = departamentosContext;
        }

        public Task<List<Departamento>> GetDepartamentosAsync()
        {
            return this.departamentosContext.Departamentos.ToListAsync();
        }

        public async Task<Departamento?> FindDepartamentoAsync(int id)
        {
            return await this.departamentosContext.Departamentos.FindAsync(id);
        }

        public async Task InsertarDepartamentoAsync(int id, string localidad, string nombre)
        {
            await this.departamentosContext.Departamentos.AddAsync(new()
            {
                IdDepartamento = id,
                Localidad = localidad,
                Nombre = nombre
            });
            await this.departamentosContext.SaveChangesAsync();
        }

        public async Task UpdateDepartamento(int id, string localidad, string nombre)
        {
            Departamento? dept = await this.FindDepartamentoAsync(id);
            if (dept != null)
            {
                dept.Nombre = nombre;
                dept.Localidad = localidad;
                await this.departamentosContext.SaveChangesAsync();
            }
        }
        public async Task DeleteDepartamentoAsync(int id)
        {
            Departamento? dept = await this.FindDepartamentoAsync(id);
            if (dept != null)
            {
                this.departamentosContext.Departamentos.Remove(dept);
                await this.departamentosContext.SaveChangesAsync();
            }
        }
    }
}
