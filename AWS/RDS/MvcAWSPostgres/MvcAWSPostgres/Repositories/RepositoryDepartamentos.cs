using Microsoft.EntityFrameworkCore;
using MvcAWSPostgres.Data;
using MvcAWSPostgres.Models;

namespace MvcAWSPostgres.Repositories
{
    public class RepositoryDepartamentos
    {
        private readonly DepartamentosContext _context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            _context = context;
        }

        public Task<List<Departamento>> GetDepartamentosAsync()
        {
            return this._context.Departamentos.ToListAsync();
        }

        public async Task CreateDepartamento(int id, string nombre, string loc)
        {
            await this._context.Departamentos.AddAsync(new Departamento()
            {
                IdDepartamento = id,
                Localidad = loc,
                Nombre = nombre
            });

            await this._context.SaveChangesAsync();
        }

        public async Task<Departamento?> FindDepartamentoAsync(int id)
        {
            return await this._context.Departamentos.FindAsync(id);
        }
    }
}
