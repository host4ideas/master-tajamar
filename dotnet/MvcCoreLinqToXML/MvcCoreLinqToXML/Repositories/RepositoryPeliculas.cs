using MvcCoreLinqToXML.Helpers;
using MvcCoreLinqToXML.Models;
using System.Xml.Linq;

namespace MvcCoreLinqToXML.Repositories
{
    public class RepositoryPeliculas
    {
        private readonly HelperPathProvider helperPath;
        private XDocument documentPeliculas;
        private XDocument documentEscenas;
        private string pathPeliculas;
        private string pathEscenas;

        public RepositoryPeliculas(HelperPathProvider helperPath)
        {
            this.helperPath = helperPath;

            pathPeliculas = this.helperPath.MapPath("peliculas.xml", Folders.Documents);
            documentPeliculas = XDocument.Load(pathPeliculas);
            pathEscenas = this.helperPath.MapPath("escenaspeliculas.xml", Folders.Documents);
            documentEscenas = XDocument.Load(pathEscenas);
        }

        public List<Pelicula> GetPeliculas()
        {
            XDocument document = XDocument.Load(pathPeliculas);
            List<Pelicula> peliculas = new();

            var consulta = from datos in document.Descendants("pelicula")
                           select datos;
            foreach (XElement tag in consulta)
            {
                peliculas.Add(new Pelicula()
                {
                    IdPelicula = int.Parse(tag.Attribute("idpelicula").Value),
                    Titulo = tag.Element("titulo").Value,
                    TituloOriginal = tag.Element("titulooriginal").Value,
                    Descripcion = tag.Element("descripcion").Value,
                    Poster = tag.Element("poster").Value
                });
            }
            return peliculas;
        }

        public List<Escena> GetEscenasPelicula(int peliculaId)
        {
            XDocument document = XDocument.Load(pathEscenas);
            List<Escena> escenas = new();

            var consulta = from datos in document.Descendants("escena")
                           where datos.Attribute("idpelicula").Value == peliculaId.ToString()
                           select datos;
            foreach (XElement tag in consulta)
            {
                escenas.Add(new Escena()
                {
                    IdPelicula = int.Parse(tag.Attribute("idpelicula").Value),
                    Descripcion = tag.Element("descripcion").Value,
                    Imagen = tag.Element("imagen").Value,
                    TituloEscena = tag.Element("tituloescena").Value
                });
            }
            return escenas;
        }
    }
}
