using Microsoft.EntityFrameworkCore;
using MvcAWSPostgres.Models;

namespace MvcAWSPostgres.Data
{
    public class DepartamentosContext : DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
