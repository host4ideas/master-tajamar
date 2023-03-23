using Microsoft.AspNetCore.Mvc;
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

        public Pelicula FindPelicula(int idpelicula)
        {
            string path = this.helperPath.MapPath("peliculas.xml", Folders.Documents);
            XDocument document = XDocument.Load(path);
            var consulta = from datos in document.Descendants("pelicula")
                           where datos.Attribute("idpelicula").Value == idpelicula.ToString()
                           select datos;
            XElement tag = consulta.FirstOrDefault();
            Pelicula peli = new Pelicula();
            peli.IdPelicula = int.Parse(tag.Attribute("idpelicula").Value);
            peli.Titulo = tag.Element("titulo").Value;
            peli.TituloOriginal = tag.Element("titulooriginal").Value;
            peli.Descripcion = tag.Element("descripcion").Value;
            peli.Poster = tag.Element("poster").Value;
            return peli;
        }

        public Escena GetEscenaPelicula(int peliculaId, int posicion, ref int numeroEscenas)
        {
            List<Escena> escenas = this.GetEscenasPelicula(peliculaId);
            numeroEscenas = escenas.Count;
            Escena escena = escenas.Skip(posicion).Take(1).FirstOrDefault();
            return escena;
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
