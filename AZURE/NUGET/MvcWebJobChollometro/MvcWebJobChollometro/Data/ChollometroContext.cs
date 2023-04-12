using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcWebJobChollometro.Models;

namespace MvcWebJobChollometro.Data
{
    public class ChollometroContext : DbContext
    {
        public ChollometroContext(DbContextOptions<ChollometroContext> options) : base(options) { }
        public DbSet<Chollo> Chollos { get; set; }
    }
}
