using Microsoft.EntityFrameworkCore;
using MvcCoreSeguridadEmpleados.Models;

namespace MvcCoreSeguridadEmpleados.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
