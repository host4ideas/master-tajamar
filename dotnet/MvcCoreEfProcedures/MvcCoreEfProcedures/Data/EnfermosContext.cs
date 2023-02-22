using Microsoft.EntityFrameworkCore;
using MvcCoreEfProcedures.Models;

namespace MvcCoreEfProcedures.Data
{
    public class EnfermosContext : DbContext
    {
        public EnfermosContext(DbContextOptions<EnfermosContext> options) : base(options) { }
        public DbSet<Enfermo> Enfermos { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<VistaEmpleado> VistaEmpleados { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
    }
}
