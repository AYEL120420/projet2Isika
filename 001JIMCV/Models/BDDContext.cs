using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;
using _001JIMCV.Models.Dals;
using System.Security.Cryptography;
using System.Text;
using System;

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
        public DbSet<ServicePackServices> ServicePackServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicePackServices>().HasKey(sps => new { sps.ServiceId, sps.PackServicesId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=001JIMCV");
        }
       
            public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            User admin = new User() { Name = "Anthony Dumas", Email = "anthony.dumas@gmail.com", Password = LoginDal.EncodeMD5("Isika24admin"), Role = UserEnum.Admin };
            User admin1 = new User() { Name = "Rudiger Hasselberg", Email = "miaourudiger@gmail.com", Password = LoginDal.EncodeMD5("Isika24admin"), Role = UserEnum.Admin };
            User admin2 = new User() { Name = "Thomas Salmon", Email = "thomas.salmon@gmail.com", Password = LoginDal.EncodeMD5("Isika24admin"), Role = UserEnum.Admin };
            User admin3 = new User() { Name = "Raounak Elassaoui", Email = "raounak.elassaoui@gmail.com", Password = LoginDal.EncodeMD5("Isika24admin"), Role = UserEnum.Admin };
            this.Users.AddRange(admin, admin1, admin2, admin3);

            User customer = new User() { Name = "Frederic", Email = "frederic@gmail.com", Password = LoginDal.EncodeMD5("Isika24client"), Role = UserEnum.Customer };
            User customer1 = new User() { Name = "Karen", Email = "karen@gmail.com", Password = LoginDal.EncodeMD5("Isika24client"), Role = UserEnum.Customer };
            User customer2 = new User() { Name = "Serdar", Email = "serdar@gmail.com", Password = LoginDal.EncodeMD5("Isika24client"), Role = UserEnum.Customer };
            User customer3 = new User() { Name = "Florian", Email = "florian@gmail.com", Password = LoginDal.EncodeMD5("Isika24client"), Role = UserEnum.Customer };
            this.Users.AddRange(customer, customer1, customer2, customer3);

            User provider = new User() { Name = "Magdaline", Email = "magdaline@gmail.com", Password = LoginDal.EncodeMD5("Isika24provider"), Role = UserEnum.Provider };
            User provider1 = new User() { Name = "Fanta", Email = "fanta@gmail.com", Password = LoginDal.EncodeMD5("Isika24provider"), Role = UserEnum.Provider };
            User provider2 = new User() { Name = "Nway", Email = "nway@gmail.com", Password = LoginDal.EncodeMD5("Isika24provider"), Role = UserEnum.Provider };
            User provider3 = new User() { Name = "Andre", Email = "andre@gmail.com", Password = LoginDal.EncodeMD5("Isika24provider"), Role = UserEnum.Provider };
            User provider4 = new User() { Name = "David", Email = "david@gmail.com", Password = LoginDal.EncodeMD5("Isika24provider"), Role = UserEnum.Provider };
            User provider5 = new User() { Name = "Mounia", Email = "mounia@gmail.com", Password = LoginDal.EncodeMD5("Isika24provider"), Role = UserEnum.Provider };
            User provider6 = new User() { Name = "Marie", Email = "marie@gmail.com", Password = LoginDal.EncodeMD5("Isika24provider"), Role = UserEnum.Provider };
            User provider7 = new User() { Name = "Brendan", Email = "brendan@gmail.com", Password = LoginDal.EncodeMD5("Isika24provider"), Role = UserEnum.Provider };
            this.Users.AddRange(provider, provider1, provider2, provider3, provider4, provider5, provider6, provider7);

            Journey inde = new Journey() { CountryDestination = "Inde", DepartureDate = "10/02/2024", ReturnDate = "24/02/2024", Persons = 2 };
            Journey thailande = new Journey() { CountryDestination = "Thailande", DepartureDate = "18/07/2024", ReturnDate = "30/07/2024", Persons = 4 };
            Journey mexique = new Journey() { CountryDestination = "Mexique", DepartureDate = "15/06/2024", ReturnDate = "30/06/2024", Persons = 2 };
            Journey ethiopie = new Journey() { CountryDestination = "Ethiopie", DepartureDate = "2/12/2024", ReturnDate = "20/12/2024", Persons = 2 };
            Journey france = new Journey() { CountryDestination = "France", DepartureDate = "10/09/2023", ReturnDate = "24/09/2023", Persons = 4 };
            Journey japon = new Journey() { CountryDestination = "Japon", DepartureDate = "20/05/2024", ReturnDate = "03/06/2024", Persons = 6 };
            Journey maroc = new Journey() { CountryDestination = "Maroc", DepartureDate = "20/10/2023", ReturnDate = "02/11/2024", Persons = 2 };
            Journey italie = new Journey() { CountryDestination = "Italie", DepartureDate = "15/08/2024", ReturnDate = "26/08/2024", Persons = 2 };
            this.Journeys.AddRange(inde, thailande, mexique, ethiopie, france, japon, maroc, italie);

            Flight FlightInde = new Flight() { Airline = "Air India", DepartureCity = "CDG", DepartureDate = "10/02/2024", DestinationCity = "Dehli", FlightNumber = 547896 };
            Flight FlightThailande = new Flight() { Airline = "Air thai", DepartureCity = "Paris Orly", DepartureDate = "18/07/2024", DestinationCity = "Pukhet", FlightNumber = 165866 };
            Flight FlightMexique = new Flight() { Airline = "Mexico airline", DepartureCity = "Aéroport de Nice", DepartureDate = "10/02/2024", DestinationCity = "Mexico", FlightNumber = 465732 };
            Flight FlightEthiopie = new Flight() { Airline = "Ethiop'fly", DepartureCity = "Aéroport Lyon Saint Exupéry", DepartureDate = "10/02/2024", DestinationCity = "Mekele", FlightNumber = 688486 };
            Flight FlightFrance = new Flight() { Airline = "Air france", DepartureCity = "Marseille Provence", DepartureDate = "10/02/2024", DestinationCity = "Paris", FlightNumber = 864566 };
            Flight FlightJapon = new Flight() { Airline = "Fly Japan", DepartureCity = "Toulouse blagnac", DepartureDate = "10/02/2024", DestinationCity = "Osaka", FlightNumber = 386618 };
            Flight FlightMaroc = new Flight() { Airline = "Boeing Maroc", DepartureCity = "Bordeaux-Mérignac", DepartureDate = "10/02/2024", DestinationCity = "Marrakech", FlightNumber = 548675 };
            Flight FlightItalie = new Flight() { Airline = "Itaflyairway", DepartureCity = "Nantes Atlantique", DepartureDate = "10/02/2024", DestinationCity = "Naples", FlightNumber = 397668 };
            this.Flights.AddRange(FlightInde, FlightThailande, FlightMexique, FlightEthiopie, FlightFrance, FlightJapon, FlightMaroc, FlightJapon, FlightItalie);  
            
            Service serv1 = new Service() { Type = "Hebergement", Description = "Chez l habitant", Prix=40 };
            Service serv2 = new Service() { Type = "Vol", Description = "", Prix = 200 };
            Service serv3 = new Service() { Type = "Activité", Description = "Rando", Prix = 10 };

            this.Services.AddRange(serv1, serv2, serv3);

            this.SaveChanges();
        }
        
    }
}
