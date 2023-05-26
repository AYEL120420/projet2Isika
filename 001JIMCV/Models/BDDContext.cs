using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace _001JIMCV.Models
{
    public class BDDContext : DbContext
    {

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<CulinaryTheme> CulinaryThemes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<PackServices> PackService { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=001JIMCV");
        }
        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            
            User client = new User() { Name = "Anthony Dumas",  Email = "anthony.dumas@gmail.com" , Password="admin", Role=0};
            User client1 = new User() { Name = "Rudiger Hasselberg", Email = "miaourudiger@gmail.com", Password = "admin", Role = 0 };
            User client2 = new User() { Name = "Thomas Salmon", Email = "thomas.salmon@gmail.com", Password = "admin", Role = 0 };
            User client3 = new User() { Name = "Raounak Elassaoui", Email = "raounak.elassaoui@gmail.com", Password = "admin", Role = 0 };
            this.Users.AddRange(client1, client, client2, client3); 

            this. SaveChanges();
        }
    }
}
