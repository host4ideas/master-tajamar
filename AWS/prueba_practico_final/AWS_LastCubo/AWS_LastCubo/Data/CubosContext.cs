using AWS_LastCubo.Models;
using Microsoft.EntityFrameworkCore;

namespace AWS_LastCubo.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) : base(options) { }
        public DbSet<Cubo> Cubos { get; set; }
    }
}
