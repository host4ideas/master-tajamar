using MvcCoreCacheRedisProductos.Helpers;
using MvcCoreCacheRedisProductos.Models;
using System.Xml.Linq;

namespace MvcCoreCacheRedisProductos.Repositories
{
    public class RepositoryProductos
    {
        private XDocument document;

        public RepositoryProductos(HelperPathProvider helperPath)
        {
            string path = helperPath.MapPath("productos.xml", Folders.Documents);
            this.document = XDocument.Load(path);
        }

        public List<Producto> GetProductos()
        {
            var consulta = from datos in this.document.Descendants("producto")
                           select new Producto()
                           {
                               IdProducto = int.Parse(datos.Element("idproducto").Value.ToString()),
                               Descripcion = datos.Element("descripcion").Value,
                               Imagen = datos.Element("imagen").Value,
                               Nombre = datos.Element("nombre").Value,
                               Precio = int.Parse(datos.Element("precio").Value.ToString()),
                           };
            return consulta.ToList();
        }

        public Producto? FindProducto(int idProducto)
        {
            return this.GetProductos().FirstOrDefault(x => x.IdProducto == idProducto);
        }
    }
}
