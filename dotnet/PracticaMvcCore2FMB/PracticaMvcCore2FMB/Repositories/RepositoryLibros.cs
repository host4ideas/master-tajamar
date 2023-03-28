using Microsoft.EntityFrameworkCore;
using PracticaMvcCore2FMB.Data;
using PracticaMvcCore2FMB.Models;

namespace PracticaMvcCore2FMB.Repositories
{
    public class RepositoryLibros
    {
        private LibrosContext librosContext;

        public RepositoryLibros(LibrosContext librosContext)
        {
            this.librosContext = librosContext;
        }

        public async Task<List<Libro>> AllLibros(int posicion)
        {
            List<Libro> libros = await this.librosContext.Libros.ToListAsync();
            return libros.Skip(posicion).Take(5).ToList();
        }

        public Task<int> LibrosCount()
        {
            return this.librosContext.Libros.CountAsync();
        }

        public Task<Libro?> FindLibro(int idLibro)
        {
            return this.librosContext.Libros.FirstOrDefaultAsync(x => x.IdLibro == idLibro);
        }

        public Task<List<Genero>> AllGeneros()
        {
            return this.librosContext.Generos.ToListAsync();
        }

        public Task<List<Libro>> LibrosGenero(int idGenero)
        {
            return this.librosContext.Libros.Where(x => x.IdGenero == idGenero).ToListAsync();
        }

        public Task<AppUser?> Login(string email, string password)
        {
            return this.librosContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Pass == password);
        }

        private async Task<int> GetMaxPedido()
        {
            return await this.librosContext.Pedidos.MaxAsync(x => x.IdPedido) + 1;
        }

        private async Task<int> GetMaxFactura()
        {
            return await this.librosContext.Pedidos.MaxAsync(x => x.IdFactura) + 1;
        }

        public async Task FinalizarCompra(int idUsuario, List<Libro> libros)
        {
            int firstNewId = await this.GetMaxPedido();
            int firstNewFactura = await this.GetMaxFactura();

            foreach (Libro libro in libros)
            {
                await this.librosContext.Pedidos.AddAsync(new Pedido()
                {
                    IdPedido = firstNewId,
                    Cantidad = 1,
                    Fecha = DateTime.Now,
                    IdFactura = firstNewFactura,
                    IdLibro = libro.IdLibro,
                    IdUsuario = idUsuario
                });
                firstNewId += 1;
                firstNewFactura += 1;
            }

            await this.librosContext.SaveChangesAsync();
        }

        public Task<AppUser?> FindUser(int userId)
        {
            return this.librosContext.Users.FirstOrDefaultAsync(x => x.IdUsuario == userId);
        }

        public async Task<List<VistaPedidos>> PedidosUsuario(int userId)
        {
            var pedidos = await this.librosContext.VistaPedidos.Where(x => x.IdUsuario == userId).ToListAsync();
            return pedidos;
        }
    }
}
