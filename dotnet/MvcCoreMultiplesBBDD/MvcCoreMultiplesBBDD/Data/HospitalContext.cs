﻿using Microsoft.EntityFrameworkCore;
using MvcCoreMultiplesBBDD.Models;

namespace MvcCoreMultiplesBBDD.Data
{
    public class HospitalContext : DbContext
    {

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
