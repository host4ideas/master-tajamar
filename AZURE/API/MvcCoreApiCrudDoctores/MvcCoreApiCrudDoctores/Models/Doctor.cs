﻿namespace MvcCoreApiCrudDoctores.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public int IdHospital { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public int Salario { get; set; }
    }
}
