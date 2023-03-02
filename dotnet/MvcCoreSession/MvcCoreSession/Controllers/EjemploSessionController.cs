using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Extensions;
using MvcCoreSession.Helpers;
using MvcCoreSession.Models;
using System.Text;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        int numero = 1;

        public IActionResult Index()
        {
            ViewData["NUMERO"] = "Valor del número: " + this.numero;
            return View();
        }

        public IActionResult SessionSimple(string? accion)
        {
            this.numero++;

            if (accion == null)
            {
                return View();
            }

            if (accion.ToLower() == "almacenar")
            {
                //HttpContext.Session.Set("my session", BitConverter.GetBytes(this.numero));
                HttpContext.Session.SetString("usuario", "Programeitor");
                HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                ViewData["MENSAJE"] = "Datos almacenados en Session";
            }
            else if (accion.ToLower() == "mostrar")
            {
                ViewData["USUARIO"] = HttpContext.Session.GetString("usuario");
                ViewData["HORA"] = HttpContext.Session.GetString("hora");
            }
            return View();
        }

        public IActionResult SessionPersona(string? accion)
        {
            if (accion == null)
            {
                return View();
            }

            if (accion.ToLower() == "almacenar")
            {
                Persona persona = new()
                {
                    Edad = 25,
                    Email = "example@example.com",
                    Nombre = "Pepito"
                };

                byte[] data = HelperBinarySession.ObjectToByte(persona)!;
                HttpContext.Session.Set("persona", data);
                ViewData["MENSAJE"] = "Datos almacenados";
            }
            else if (accion.ToLower() == "mostrar")
            {
                Persona persona = (Persona)HelperBinarySession.ByteToObject(HttpContext.Session.Get("persona")!);
                ViewData["PERSONA"] = persona;
            }
            return View();
        }

        public IActionResult SessionPersonaJson(string? accion)
        {
            if (accion == null)
            {
                return View();
            }

            if (accion.ToLower() == "almacenar")
            {
                Persona persona = new()
                {
                    Edad = 25,
                    Email = "example@example.com",
                    Nombre = "Pepito"
                };

                string data = HelperJsonSession.SerializeObject(persona)!;
                HttpContext.Session.SetString("persona", data);
                ViewData["MENSAJE"] = "Datos almacenados";
            }
            else if (accion.ToLower() == "mostrar")
            {
                Persona persona = HelperJsonSession.DeserializeObject<Persona>(HttpContext.Session.GetString("persona")!);
                ViewData["PERSONA"] = persona;
            }
            return View();
        }

        public IActionResult SessionPersonaObject(string? accion)
        {
            if (accion == null)
            {
                return View();
            }

            if (accion.ToLower() == "almacenar")
            {
                Persona persona = new()
                {
                    Edad = 25,
                    Email = "example@example.com",
                    Nombre = "Pepito"
                };

                HttpContext.Session.SetObject("personaobject", persona);

                ViewData["MENSAJE"] = "Datos almacenados";
            }
            else if (accion.ToLower() == "mostrar")
            {
                Persona persona = HttpContext.Session.GetObject<Persona>("personaobject")!;
                ViewData["PERSONA"] = persona;
            }
            return View();
        }

        public IActionResult ColeccionSessionObject(string? accion)
        {
            if (accion == null)
            {
                return View();
            }

            if (accion.ToLower() == "almacenar")
            {
                List<Persona> personas = new()
                {
                    new Persona()
                    {
                        Edad = 25,
                        Nombre = "Marta",
                        Email = "marta@gmail.com"
                    },
                    new Persona()
                    {
                        Edad = 35,
                        Nombre = "Andrés",
                        Email = "andres@gmail.com"
                    },
                    new Persona()
                    {
                        Edad = 45,
                        Nombre = "Paco",
                        Email = "paco@gmail.com"
                    },
                };

                HttpContext.Session.SetObject("listapersonasobject", personas);
                ViewData["MENSAJE"] = "Datos almacenados";
            }
            else if (accion.ToLower() == "mostrar")
            {
                List<Persona> personas = HttpContext.Session.GetObject<List<Persona>>("listapersonasobject")!;
                return View(personas);
            }

            return View();
        }
        
        public IActionResult ColeccionSessionPersona(string? accion)
        {
            if (accion == null)
            {
                return View();
            }

            if (accion.ToLower() == "almacenar")
            {
                List<Persona> personas = new()
                {
                    new Persona()
                    {
                        Edad = 25,
                        Nombre = "Marta",
                        Email = "marta@gmail.com"
                    },
                    new Persona()
                    {
                        Edad = 35,
                        Nombre = "Andrés",
                        Email = "andres@gmail.com"
                    },
                    new Persona()
                    {
                        Edad = 45,
                        Nombre = "Paco",
                        Email = "paco@gmail.com"
                    },
                };

                byte[] data = HelperBinarySession.ObjectToByte(personas)!;
                HttpContext.Session.Set("personas", data);
                ViewData["MENSAJE"] = "Datos almacenados";
            }
            else if (accion.ToLower() == "mostrar")
            {
                List<Persona> personas = (List<Persona>)HelperBinarySession.ByteToObject(HttpContext.Session.Get("personas")!);
                return View(personas);
            }

            return View();
        }
    }
}
