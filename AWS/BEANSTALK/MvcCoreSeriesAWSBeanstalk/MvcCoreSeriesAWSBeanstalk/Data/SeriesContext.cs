using Microsoft.EntityFrameworkCore;
using MvcCoreSeriesAWSBeanstalk.Models;

namespace MvcCoreSeriesAWSBeanstalk.Data
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
    }
}
