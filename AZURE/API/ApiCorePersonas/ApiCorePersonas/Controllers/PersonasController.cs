using ApiCorePersonas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCorePersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        readonly List<Persona> Personas;

        public PersonasController()
        {
            this.Personas = new()
            {
                new()
                {
                    Edad = 5,
                    Nombre = "Sergio",
                    Email = "tinder@fumao.com",
                    IdPersona = 1
                },
                new()
                {
                    Nombre = "Guti",
                    Email = "new@folleti.com",
                    IdPersona = 2,
                    Edad = 10
                },
                new()
                {
                    IdPersona = 3,
                    Nombre = "JC",
                    Email = "chollo@metersacar.com",
                    Edad= 13
                },
                new()
                {
                    Nombre = "Felix",
                    IdPersona= 4,
                    Edad=15,
                    Email = "prima@tetas.com"
                }
            };
        }

        [HttpGet]
        public ActionResult<List<Persona>> Get()
        {
            return this.Personas;
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> FindPersona(int id)
        {
            return this.Personas.FirstOrDefault(x => x.IdPersona == id);
        }
    }
}
 