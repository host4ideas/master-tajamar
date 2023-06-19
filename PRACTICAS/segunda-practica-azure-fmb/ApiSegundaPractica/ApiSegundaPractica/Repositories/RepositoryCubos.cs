using ApiSegundaPractica.Data;
using ApiSegundaPractica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSegundaPractica.Repositories
{
    public class RepositoryCubos
    {
        private readonly CubosContext _context;

        public RepositoryCubos(CubosContext context)
        {
            _context = context;
        }

        public Task<List<Cubo>> GetCubosAsync()
        {
            return this._context.Cubos.ToListAsync();
        }

        public async Task<List<Cubo>> GetCubosMarca(string marca)
        {
            return await this._context.Cubos.Where(x => x.Marca == marca).ToListAsync();
        }

        private async Task<int> GetMaxCuboAsync()
        {
            return await this._context.Cubos.MaxAsync(x => x.IdCubo) + 1;
        }

        public async Task InsertCuboAsync(string nombre, string marca, string imagen, int precio)
        {
            await this._context.Cubos.AddAsync(new()
            {
                IdCubo = await this.GetMaxCuboAsync(),
                Marca = marca,
                Nombre = nombre,
                Precio = precio,
                Imagen = imagen
            });

            await this._context.SaveChangesAsync();
        }

        private async Task<int> GetMaxUserAsync()
        {
            return await this._context.Usuarios.MaxAsync(x => x.IdUsuario) + 1;
        }

        public async Task InsertUserAsync(string nombre, string email, string pass, string imagen)
        {
            await this._context.Usuarios.AddAsync(new()
            {
                IdUsuario = await this.GetMaxUserAsync(),
                Email = email,
                Imagen = imagen,
                Nombre = nombre,
                Password = pass
            });

            await this._context.SaveChangesAsync();
        }

        public async Task<Usuario?> FindUserAsync(int idUsuario)
        {
            return await this._context.Usuarios.FindAsync(idUsuario);
        }

        public async Task<List<CompraCubo>> GetComprasUsuarioAsync(int idUsuario)
        {
            return await this._context.CompraCubos.Where(x => x.IdUsuario == idUsuario).ToListAsync();
        }

        private async Task<int> GetMaxPedidoAsync()
        {
            return await this._context.CompraCubos.MaxAsync(x => x.IdPedido) + 1;
        }

        public async Task RealizarPedidoAsync(int idCubo, int idUsuario)
        {
            await this._context.CompraCubos.AddAsync(new()
            {
                IdPedido = await this.GetMaxPedidoAsync(),
                FechaPedido = DateTime.Now,
                IdCubo = idCubo,
                IdUsuario = idUsuario
            });

            await this._context.SaveChangesAsync();
        }

        public async Task<Usuario?> ExisteUsuarioAsync(string email, string password)
        {
            return await this._context.Usuarios.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
