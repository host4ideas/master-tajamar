﻿using ApiSegundaPractica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSegundaPractica.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) : base(options) { }

        public DbSet<Cubo> Cubos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CompraCubo> CompraCubos { get; set; }
    }
}
