using ConsolaCacheRedis;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ConsolaCacheRedis.Services
{
    public class ServiceCacheRedis
    {
        private readonly IDatabase database;

        public ServiceCacheRedis()
        {
            this.database = HelperCacheMultiplexer.Connection.GetDatabase();
        }

        public async Task AddProductoFavorito(Producto producto)
        {
            string? jsonProductos = await this.database.StringGetAsync("favoritos");
            List<Producto> productos = new();

            if (jsonProductos != null)
            {
                productos = JsonConvert.DeserializeObject<List<Producto>>(jsonProductos)!;
            }

            productos.Add(producto);
            jsonProductos = JsonConvert.SerializeObject(productos);
            await this.database.StringSetAsync("favoritos", jsonProductos);
        }

        public async Task<List<Producto>?> GetProductosFavoritos()
        {
            string? jsonProductos = await this.database.StringGetAsync("favoritos");

            if (jsonProductos == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<List<Producto>>(jsonProductos);
        }

        public async Task DeleteProductoFavorito(int idProducto)
        {
            List<Producto>? favoritos = await this.GetProductosFavoritos();

            if (favoritos != null)
            {
                Producto? prod = favoritos.FirstOrDefault(x => x.IdProducto == idProducto);
                if (prod != null)
                {
                    favoritos.Remove(prod);

                    if (favoritos.Count == 0)
                    {
                        await this.database.KeyDeleteAsync("favoritos");
                    }
                    else
                    {
                        string jsonProductos = JsonConvert.SerializeObject(favoritos);
                        /*
                            Si no ponemos el tiempo en el momento de almacenar
                            elementos, por defecto son 24 hrs. También podemos
                            personalizarlo desde Azure.
                         */
                        await this.database.StringSetAsync("favoritos", jsonProductos, TimeSpan.FromMinutes(30));
                    }
                }
            }
        }
    }
}
