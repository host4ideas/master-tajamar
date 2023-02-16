using Microsoft.EntityFrameworkCore;
using MvcCodeCrudDepartamentosEF.Models;

namespace MvcCodeCrudDepartamentosEF.Data
{
    public class DepartamentosContext : DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options) : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
