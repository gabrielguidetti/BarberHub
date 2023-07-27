using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.ProjectSettings
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BarberShop> BarberShops { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<MarkedService> MarkedServices { get; set; }
        public DbSet<BarberService> BarberServices { get; set; }
    }
}
