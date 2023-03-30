using ServicioWCFLogicaClientes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServicioWCFLogicaClientes.Repositories
{
    public class RepositoryClientes
    {
        private XDocument document;

        public RepositoryClientes()
        {
            string resourceName = "ServicioWCFLogicaClientes.clientes.xml";
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(resourceName);
            this.document = XDocument.Load(stream);
        }

        public List<Cliente> GetClientes()
        {
            var consulta = from datos in this.document.Descendants("CLIENTE")
                           select new Cliente()
                           {
                               IdCliente = int.Parse(datos.Element("IDCLIENTE").Value),
                               Direccion = datos.Element("DIRECCION").Value,
                               Email = datos.Element("EMAIL").Value,
                               ImagenCliente = datos.Element("IMAGENCLIENTE").Value,
                               Nombre = datos.Element("NOMBRE").Value
                           };

            return consulta.ToList();
        }

        public Cliente FindCliente(int idCliente)
        {
            return this.GetClientes().FirstOrDefault(x => x.IdCliente == idCliente);
        }
    }
}
