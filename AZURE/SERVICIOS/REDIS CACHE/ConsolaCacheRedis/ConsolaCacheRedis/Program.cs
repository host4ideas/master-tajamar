using ConsolaCacheRedis.Services;

namespace ConsolaCacheRedis
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Cliente Movil de Azure Cache Redis");

            ServiceCacheRedis service = new();
            List<Producto>? productos = await service.GetProductosFavoritos();
            if (productos == null)
            {
                Console.WriteLine("No existen favoritos");
            }
            else
            {
                foreach (var producto in productos)
                {
                    Console.WriteLine(producto.Nombre);
                }
            }
        }
    }
}
