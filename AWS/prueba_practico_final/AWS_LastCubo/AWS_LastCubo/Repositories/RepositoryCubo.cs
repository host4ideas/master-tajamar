using AWS_LastCubo.Data;
using AWS_LastCubo.Models;
using Microsoft.EntityFrameworkCore;

namespace AWS_LastCubo.Repositories {
    public class RepositoryCubo {

        private CubosContext context;

        public RepositoryCubo(CubosContext context) {
            this.context = context;
        }

        // EXTRAE TODOS LOS CUBOS DE LA BBDD
        public async Task<List<Cubo>> GetCubosAsync() {
            return await this.context.Cubos.ToListAsync();
        }

        // BUSCA LOS CUBOS POR MARCA
        public async Task<List<Cubo>> FindCuboMarcaAsync(string marca) {
            return await this.context.Cubos.Where(x => x.Marca == marca).ToListAsync();
        }

        // CREACIÓN DE UN CUBO
        public async Task<bool> CreateCuboAsync(string nombre, string marca, string imagen, int precio) {
            int newid = await this.context.Cubos.AnyAsync() ? await this.context.Cubos.MaxAsync(x => x.Id) + 1 : 1;
            Cubo cubo = new Cubo {
                Id = newid,
                Nombre = nombre,
                Marca = marca,
                Imagen = imagen,
                Precio = precio
            };

            await this.context.Cubos.AddAsync(cubo);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task UpdateCuboAsync(int id, string nombre, string marca, string imagen, int precio) {
            Cubo? cubo = await this.context.Cubos.FirstOrDefaultAsync(x => x.Id == id);
            if (cubo != null) {
                cubo.Nombre = nombre;
                cubo.Marca = marca;
                cubo.Imagen = imagen;
                cubo.Precio = precio;
            }
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteCuboAsync(int idCubo) {
            Cubo? cubo = await this.context.Cubos.FirstOrDefaultAsync(x => x.Id == idCubo);
            if (cubo != null) {
                this.context.Cubos.Remove(cubo);
                await this.context.SaveChangesAsync();
            }
        }

    }
}