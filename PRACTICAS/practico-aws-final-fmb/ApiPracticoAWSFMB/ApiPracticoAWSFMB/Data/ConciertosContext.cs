using ApiPracticoAWSFMB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPracticoAWSFMB.Data
{
    public class ConciertosContext : DbContext
    {
        public ConciertosContext(DbContextOptions<ConciertosContext> options) : base(options) { }
        public DbSet<CategoriaEvento> CategoriasEvento { get; set; }
        public DbSet<Evento> Eventos { get; set; }
    }
}
