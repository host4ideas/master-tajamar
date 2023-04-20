using MvcCoreSasStorage.Models;
using System.Xml.Linq;

namespace MvcCoreSasStorage.Repositories
{
    public class RepositoryXML
    {
        private XDocument documentAlumnos;
        private string pathAlumnos;

        public RepositoryXML()
        {
            this.pathAlumnos = "alumnos_tables.xml";
            this.documentAlumnos = XDocument.Load(this.pathAlumnos);
        }

        public List<Alumno> GetAlumnos()
        {
            XDocument document = XDocument.Load(this.pathAlumnos);
            List<Alumno> alumnos = new();

            var consulta = from datos in document.Descendants("alumno")
                           select datos;
            foreach (XElement tag in consulta)
            {
                alumnos.Add(new Alumno()
                {
                    Nombre = tag.Element("nombre").Value,
                    Apellidos = tag.Element("apellidos").Value,
                    Curso = tag.Element("curso").Value,
                    IdAlumno = int.Parse(tag.Element("idalumno").Value.ToString()),
                    Nota = int.Parse(tag.Element("nota").Value.ToString()),
                });
            }
            return alumnos;
        }

        public Alumno? FindAlumno(int idAlumno)
        {
            var consulta = from datos in this.documentAlumnos.Descendants("alumno")
                           where datos.Element("idalumno").Value == idAlumno.ToString()
                           select datos;

            if (consulta.Any())
            {
                XElement tag = consulta.FirstOrDefault();

                Alumno alumno = new()
                {
                    Nombre = tag.Element("nombre").Value,
                    Apellidos = tag.Element("apellidos").Value,
                    Curso = tag.Element("curso").Value,
                    IdAlumno = int.Parse(tag.Element("idalumno").Value.ToString()),
                    Nota = int.Parse(tag.Element("nota").Value.ToString()),
                };

                return alumno;
            }

            return null;
        }
    }
}
