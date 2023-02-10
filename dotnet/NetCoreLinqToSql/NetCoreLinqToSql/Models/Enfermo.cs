﻿using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace NetCoreLinqToSql.Models
{
    public class Enfermo
    {
        public string Inscripcion { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Nss { get; set; }
    }
}
