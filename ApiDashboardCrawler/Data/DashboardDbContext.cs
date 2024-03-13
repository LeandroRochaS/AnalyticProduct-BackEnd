using ApiDashboardCrawler.models;
using Microsoft.EntityFrameworkCore;

namespace ApiDashboardCrawler.Data
{
    public class DashboardDbContext : DbContext
    {

        public DashboardDbContext(DbContextOptions<DashboardDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Logbenchdashboard> Logbenchdashboards { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        }
    }
}
