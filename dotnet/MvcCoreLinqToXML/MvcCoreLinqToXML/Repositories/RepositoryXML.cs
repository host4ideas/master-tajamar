using MvcCoreLinqToXML.Helpers;
using MvcCoreLinqToXML.Models;
using System.Xml.Linq;

namespace MvcCoreLinqToXML.Repositories
{
    public class RepositoryXML
    {
        private readonly HelperPathProvider helperPath;
        private XDocument documentClientes;
        private string pathClientes;

        public RepositoryXML(HelperPathProvider helperPath)
        {
            this.helperPath = helperPath;

            this.pathClientes = this.helperPath.MapPath("ClientesID.xml", Folders.Documents);
            this.documentClientes = XDocument.Load(this.pathClientes);
        }

        public List<Joyeria> GetJoyerias()
        {
            string path = helperPath.MapPath("joyerias.xml", Folders.Documents);
            XDocument document = XDocument.Load(path);
            List<Joyeria> joyerias = new();

            var consulta = from datos in document.Descendants("joyeria")
                           select datos;
            foreach (XElement tag in consulta)
            {
                joyerias.Add(new Joyeria()
                {
                    CIF = tag.Attribute("cif").Value,
                    Direccion = tag.Element("direccion").Value,
                    Nombre = tag.Element("nombrejoyeria").Value,
                    Telefono = tag.Element("telf").Value
                });
            }
            return joyerias;
        }

        public XElement FindXMLCliente(string clienteId)
        {
            var consulta = from datos in this.documentClientes.Descendants("CLIENTE")
                           where datos.Element("IDCLIENTE").Value == clienteId
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void DeleteCliente(int clienteId)
        {
            XElement clienteXML = this.FindXMLCliente(clienteId.ToString());
            clienteXML.Remove();
            this.documentClientes.Save(this.pathClientes);
        }

        public void UpdateCliente(int clienteId, string nombre, string email, string direccion, string imagen)
        {
            XElement clienteXML = this.FindXMLCliente(clienteId.ToString());
            clienteXML.Element("DIRECCION").Value = direccion;
            clienteXML.Element("EMAIL").Value = email;
            clienteXML.Element("IMAGENCLIENTE").Value = imagen;
            clienteXML.Element("NOMBRE").Value = nombre;

            this.documentClientes.Save(this.pathClientes);
        }

        public void CreateCliente(int clienteId, string nombre, string email, string direccion, string imagen)
        {
            XElement rootCliente = new("CLIENTE");
            rootCliente.Add(
                new XElement("IDCLIENTE", clienteId),
                new XElement("DIRECCION", direccion),
                new XElement("EMAIL", email),
                new XElement("IMAGENCLIENTE", imagen),
                new XElement("NOMBRE", nombre)
            );
            this.documentClientes.Element("CLIENTES").Add(rootCliente);
            this.documentClientes.Save(this.pathClientes);
        }

        public Cliente? FindCliente(int clienteId)
        {
            var consulta = from datos in this.documentClientes.Descendants("CLIENTE")
                           where datos.Element("IDCLIENTE").Value == clienteId.ToString()
                           select datos;

            if (consulta.Any())
            {
                XElement tag = consulta.FirstOrDefault();

                Cliente cliente = new()
                {
                    IdCliente = int.Parse(tag.Element("IDCLIENTE").Value),
                    Direccion = tag.Element("DIRECCION").Value,
                    Email = tag.Element("EMAIL").Value,
                    Imagen = tag.Element("IMAGENCLIENTE").Value,
                    Nombre = tag.Element("NOMBRE").Value
                };

                return cliente;
            }

            return null;
        }

        public List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new();

            var consulta = from datos in this.documentClientes.Descendants("CLIENTE")
                           select datos;
            foreach (XElement tag in consulta)
            {
                clientes.Add(new Cliente()
                {
                    IdCliente = int.Parse(tag.Element("IDCLIENTE").Value),
                    Direccion = tag.Element("DIRECCION").Value,
                    Email = tag.Element("EMAIL").Value,
                    Imagen = tag.Element("IMAGENCLIENTE").Value,
                    Nombre = tag.Element("NOMBRE").Value
                });
            }
            return clientes;
        }
    }
}
