using Microsoft.EntityFrameworkCore;
using MvcCoreCrudHospitalesEF.Models;
using System.Data.Common;

namespace MvcCoreCrudHospitalesEF.Data
{
    public class HospitalesContext : DbContext
    {
        public HospitalesContext(DbContextOptions<HospitalesContext> options) : base(options) { }
        public DbSet<Hospital> Hospitales { get; set; }
    }
}
