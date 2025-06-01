using BlackoutMonitorAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BlackoutMonitorAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Alert> Alerts { get; set; }

    }
}
