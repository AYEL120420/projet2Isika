using _001JIMCV.Models.Classes.Users;
using _001JIMCV.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace _001JIMCV.Models
{
    public class BDDContext : DbContext
    {
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Service> ServiceProvider { get; set; }
        public DbSet<PackServices> PackService { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Provider> UserProvider { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CulinaryTheme> CulinaryThemes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=001JIMCV");
        }

    }
}
