using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet.Models;

namespace AdoNet.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Oficio { get; set; }
        public int Salario { get; set; }
    }
}
