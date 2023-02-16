using Microsoft.EntityFrameworkCore;
using MvcCoreEnfermosEF.Models;

namespace MvcCoreEnfermosEF.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {

        }

        public DbSet<Enfermo> Enfermos { get; set; }
    }
}
