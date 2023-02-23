using MvcFrameworkReto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcFrameworkReto.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext() : base("Data Source=LOCALHOST\\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023") { }

        public DbSet<Empleado> Empleados { get; set; }
    }
}