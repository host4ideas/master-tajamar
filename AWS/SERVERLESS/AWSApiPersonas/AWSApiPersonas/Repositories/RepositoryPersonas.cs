using AWSApiPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApiPersonas.Repositories
{
    public class RepositoryPersonas
    {
        readonly List<Persona> personas;

        public RepositoryPersonas()
        {
            this.personas = new List<Persona>()
            {
                new Persona() {Id = 1, Edad = 20, Email = "pepe@pepe.com", Nombre = "Pepe"},
                new Persona() {Id = 2, Nombre = "Laura", Email = "laura@laura.com", Edad = 20},
                new Persona() {Id = 3, Nombre = "Marta", Email = "marta@marta.com", Edad = 20},
                new Persona() {Id = 4, Nombre = "Thor", Email = "thor@thor.com", Edad = 20}
            };
        }

        public List<Persona> GetPersonas()
        {
            return this.personas;
        }

        public Persona? FindPersona(int id)
        {
            return this.personas.FirstOrDefault(x => x.Id == id);
        }
    }
}
