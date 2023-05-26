using _001JIMCV.Models.Classes.Users;
using _001JIMCV.Models.Classes;
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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=001JIMCV");
        }
        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            Client client = new Client() { Name = "Anthony Dumas", Birthday = "11/05/1994", Email = "anthony.dumas@gmail.com" };
            Client client1 = new Client() { Name = "Rudiger Hasselberg", Birthday = "26/07/2000", Email = "miaourudiger@gmail.com" };
            Client client2 = new Client() { Name = "Thomas Salmon", Birthday = "14/09/1999", Email = "thomas.salmon@gmail.com" };
            this.Clients.AddRange(client1, client, client2);

            this. SaveChanges();
        }
    }
}
