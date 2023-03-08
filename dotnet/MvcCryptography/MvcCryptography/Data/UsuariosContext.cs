using Microsoft.EntityFrameworkCore;
using MvcCryptography.Models;

namespace MvcCryptography.Data
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
