using Microsoft.EntityFrameworkCore;
using PracticaAWSCubosFMB.Models;

namespace PracticaAWSCubosFMB.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) : base(options) { }
        public DbSet<Cubo> Cubos { get; set; }
    }
}
