using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;
using Microsoft.EntityFrameworkCore;
using _001JIMCV.Models.Dals;


namespace _001JIMCV.Models
{
    public class BDDContext : DbContext
    {

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<OtherProposition> OtherPropositions { get; set; }
        public DbSet<CulinaryTheme> CulinaryThemes { get; set; }
        public DbSet<Restauration> Restaurations { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<PackServices> PackService { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FlightPackServices> FlightPackServices { get; set; }
        public DbSet<AccommodationPackServices> AccommodationPackServices { get; set; }
        public DbSet<ActivityPackServices> ActivityPackServices { get; set; }
        public DbSet<RestaurationPackServices> RestaurationPackServices { get; set; }
        public DbSet<Reservation>Reservations { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=001JIMCV");
        }

       
        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            User admin = new User() { Name = "Anthony Dumas", Email = "anthony.dumas@gmail.com",Gender="Masculin", Country="France", City="Paris", Password = LoginDal.EncodeMD5("Isika24admin"), Role = UserEnum.Admin };
            User admin1 = new User() { Name = "Rudiger Hasselberg", Email = "miaourudiger@gmail.com", Gender = "Masculin", Country = "France", City = "Paris", Password = LoginDal.EncodeMD5("Isika24admin"), Role = UserEnum.Admin };
            User admin2 = new User() { Name = "Thomas Salmon", Email = "thomas.salmon@gmail.com", Gender = "Masculin", Country = "France", City = "Rennes",Password = LoginDal.EncodeMD5("Isika24admin"), Role = UserEnum.Admin };
            User admin3 = new User() { Name = "Raounak Elaissaoui", Email = "raounak.elaissaoui@gmail.com", Gender = "Feminin", Country = "France", City = "Lille",Password = LoginDal.EncodeMD5("Isika24admin"), Role = UserEnum.Admin };
            this.Users.AddRange(admin, admin1, admin2, admin3);

            User customer = new User() { Name = "Frederic", Email = "frederic@gmail.com", Password = LoginDal.EncodeMD5("Isika24client"), Role = UserEnum.Customer , Phone="0665609580"};
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

            Journey inde = new Journey() { DepartureCity = "Paris CDG", CountryDestination = "Inde", ImagePath = "/Images/Inde/VoyageInde03.jpg", DepartureDate = "10/02/2024", ReturnDate = "24/02/2024", CityDestination="Chennai", Price = 2100, Description = "Aryan, un hôte chaleureux et énergique, vous accueille dans le cadre d'un voyage culinaire à Chennai en Inde. Sa personnalité joviale et sa passion pour la cuisine font de lui le compagnon idéal pour explorer la diversité gastronomique de la ville. Avec lui, vous découvrirez les saveurs épicées et savoureuses de la cuisine locale, en dégustant des plats authentiques tels que le curry Madras renommé. Aryan vous guidera avec enthousiasme à travers les marchés locaux animés, où vous pourrez vous immerger dans la culture culinaire et choisir les meilleurs fruits de mer frais pour vos dégustations. Préparez-vous à vivre une expérience culinaire inoubliable sous la direction bienveillante d'Aryan." };
            Journey inde2 = new Journey() { DepartureCity = "Nantes", CountryDestination = "Inde", ImagePath = "/Images/Inde/IndeVoyage02.jpg", DepartureDate = "20/03/2024", ReturnDate = "30/03/2024", CityDestination = "Varasani", Price = 2500, Description = "Priya, une hôtesse douce et charmante, vous accueille pour un voyage culinaire à Varanasi en Inde. Sa personnalité attentionnée et sa connaissance approfondie de la cuisine locale feront de votre expérience un véritable délice. Priya vous fera découvrir la cuisine authentique de Varanasi, des spécialités locales aux délices sucrés. Vous pourrez déguster de délicieux lassis rafraîchissants et vous laisser emporter par les saveurs exquises de la cuisine traditionnelle. Priya vous guidera également dans une immersion dans la culture spirituelle et culinaire de la ville sainte, en vous faisant découvrir les rituels et les traditions culinaires uniques de Varanasi. Avec Priya comme votre guide attentionné, préparez-vous à vivre une expérience culinaire fascinante et mémorable." };
            Journey italie1 = new Journey() { DepartureCity = "Paris CDG", CountryDestination = "Italie", ImagePath = "/Images/Italie/VoyageItalie01.jpg", DepartureDate = "20/03/2024", ReturnDate = "30/03/2024", CityDestination = "Bologne", Price = 2500, Description = "Luca, un hôte affable et passionné, vous accueille pour un voyage culinaire à Bologne. Avec son amour pour la cuisine italienne et sa connaissance approfondie de la spécialité de la ville, les \"tagliatelles à la bolognaise\", Luca vous promet une expérience gastronomique inoubliable. Il vous guidera vers les trattorias traditionnelles où vous pourrez déguster des pâtes fraîches faites maison, accompagnées d'une sauce à la viande riche et savoureuse. Luca vous fera également découvrir les délices des charcuteries artisanales de Bologne, telles que le jambon de Parme et le mortadelle, ainsi que le fameux fromage parmesan. Préparez-vous à savourer l'authenticité de la cuisine italienne et à vous régaler avec les délices de cette région gastronomique, accompagné de l'accueil chaleureux de Luca." };
            Journey italie2 = new Journey() { DepartureCity = "Nantes", CountryDestination = "Italie", ImagePath = "/Images/Italie/VoyageItalie02.jpg", DepartureDate = "20/03/2024", ReturnDate = "30/03/2024", CityDestination = "Naples", Price = 2500, Description = "Giulia, une hôtesse passionnée et enjouée, vous accueille pour un voyage culinaire à Naples. Avec sa personnalité chaleureuse et son amour pour la cuisine napolitaine, Giulia vous promet une expérience gustative inoubliable. Elle vous guidera vers les meilleures pizzerias traditionnelles de Naples, où vous pourrez déguster des pizzas fraîchement cuites au four à bois, avec leur pâte fine et moelleuse, leur sauce tomate savoureuse et leurs garnitures alléchantes. Giulia vous fera également découvrir les délices des fruits de mer frais, des pâtes délicieuses et des desserts gourmands tels que la sfogliatella et le babà. Laissez-vous immerger dans la culture culinaire napolitaine en explorant les marchés animés de la ville, guidé par la passion contagieuse de Giulia. Préparez-vous à une expérience culinaire authentique et pleine de saveurs avec Giulia à Naples." };
            Journey japon1 = new Journey() { DepartureCity = "Nice", CountryDestination = "Japon", ImagePath = "/Images/Japon/VoyageJapon02.jpg", DepartureDate = "20/03/2024", ReturnDate = "30/03/2024", CityDestination = "Sapporo", Price = 2500, Description = "Sakura, une hôtesse passionnée et pétillante, vous accueille pour un voyage culinaire à Sapporo au Japon. Son amour pour la cuisine et son esprit enjoué vous promettent une expérience délicieuse. Avec Sakura comme guide, vous vous régalerez avec les fruits de mer frais, vous plongerez dans les saveurs irrésistibles des ramens savoureux et vous découvrirez les délices de la cuisine de rue locale. Elle vous fera également découvrir les bières locales qui complètent parfaitement les mets délicats de Sapporo. Laissez-vous emporter par l'ambiance animée des marchés alimentaires, guidé par Sakura qui connaît les meilleures adresses pour déguster les spécialités locales. Préparez-vous à vivre un voyage culinaire mémorable en compagnie de Sakura." };
            Journey japon2 = new Journey() { DepartureCity = "Toulouse", CountryDestination = "Japon", ImagePath = "/Images/Japon/VoyageJapon01.jpg", DepartureDate = "20/03/2024", ReturnDate = "30/03/2024", CityDestination = "Fukuoka", Price = 2500, Description = "Takashi, un hôte passionné et expert en ramen, vous accueille pour un voyage culinaire à Fukuoka au Japon. Sa connaissance approfondie des \"Hakata Ramen\" et sa personnalité enthousiaste feront de votre expérience une véritable festin pour les papilles. Avec Takashi comme guide, vous explorerez les nombreux restaurants spécialisés de Fukuoka, savourant les délicieuses variations de ramen, des nouilles fines plongées dans un bouillon de porc riche et savoureux. Il vous fera découvrir les meilleures garnitures, des tranches de porc fondantes aux œufs marbrés à la perfection. Préparez-vous à vous régaler avec les saveurs délectables du ramen, guidé par Takashi, votre expert culinaire dédié." };
            Journey mexique1 = new Journey() { DepartureCity = "Nice", CountryDestination = "Mexique", ImagePath = "/Images/Mexique/VoyageMexique02.jpg", DepartureDate = "20/03/2024", ReturnDate = "30/03/2024", CityDestination = "Ciudad", Price = 2500, Description = "Isabella, une hôtesse dynamique et passionnée, vous accueille pour un voyage culinaire à Ciudad Juárez. Avec son amour pour la cuisine mexicaine et son enthousiasme contagieux, elle vous fera découvrir les délices des burritos authentiques de la ville. Isabella vous guidera vers les meilleurs endroits où déguster ces délicieux burritos, généreusement garnis de viande grillée, de riz, de haricots, de légumes frais et de salsa savoureuse, le tout enveloppé dans une tortilla moelleuse. Elle partagera avec vous les secrets des saveurs et des techniques de préparation traditionnelles. Préparez-vous à vivre une expérience culinaire authentique et mémorable en compagnie d'Isabella à Ciudad Juárez." };
            Journey mexique2 = new Journey() { DepartureCity = "Toulouse", CountryDestination = "Mexique", ImagePath = "/Images/Mexique/VoyageMexique01.jpg", DepartureDate = "20/03/2024", ReturnDate = "30/03/2024", CityDestination = "San Cristobal De La Casa", Price = 2500, Description = "Carlos, un hôte convivial et passionné, vous accueille pour un voyage culinaire à San Cristobal de las Casas. Avec sa connaissance approfondie de la délicieuse version du chili con carne de la ville, Carlos vous promet une expérience gastronomique inoubliable. Il vous guidera vers les meilleurs endroits pour déguster un chili con carne riche en saveurs, préparé avec des épices locales, de la viande savoureuse et des haricots. Carlos partagera avec vous les secrets de cette recette emblématique, en soulignant les ingrédients et les techniques qui font de ce plat une spécialité irrésistible. Préparez-vous à vous régaler avec un chili con carne authentique et délicieux, accompagné de l'expertise et de la chaleur de Carlos." };
            Journey vietnam1 = new Journey() { CountryDestination = "Vietnam", ImagePath = "/Images/Vietnam/VoyageVietnam01.jpg", DepartureDate = "20/03/2024", ReturnDate = "30/03/2024", CityDestination = "Hanoi", Price = 2500, Description = "Minh, un hôte souriant et plein de vitalité, vous accueille pour un voyage culinaire à Hanoï. Sa passion pour la cuisine vietnamienne et sa connaissance approfondie des spécialités de la ville en font votre guide idéal. Minh vous emmènera à la découverte des saveurs délicates et fraîches de Hanoï, en commençant par le célèbre \"phở\", une soupe de nouilles de riz parfumée au bœuf ou au poulet. Vous pourrez également déguster les délicieux \"bánh mì\", des sandwichs vietnamiens remplis de viandes grillées et de légumes croquants. Laissez Minh vous conduire à travers les marchés animés de la ville, où vous pourrez goûter aux spécialités locales comme le \"cha ca\" (poisson grillé) et les \"nem ran\" (rouleaux de printemps frits). Préparez-vous à vivre une expérience culinaire authentique et enrichissante avec Minh à Hanoï." };
            Journey vietnam2 = new Journey() { CountryDestination = "Vietnam", ImagePath = "/Images/Vietnam/VoyageVietnam03.jpg", DepartureDate = "20/03/2024", ReturnDate = "30/03/2024", CityDestination = "Nha Trang", Price = 2500, Description = "Anh, un hôte accueillant et passionné, vous souhaite la bienvenue pour un voyage culinaire à Nha Trang. Sa connaissance approfondie de la cuisine côtière et des fruits de mer abondants de la région fait de lui le guide idéal pour découvrir les délices de Nha Trang. Anh vous fera découvrir des plats délicieux tels que le \"bun cha ca\" (soupe de nouilles de poisson), les crevettes grillées, les crabes au poivre et bien d'autres trésors marins. Vous pourrez également déguster des plats vietnamiens classiques tels que les \"banh xeo\" (crêpes de riz croustillantes) et les \"goi cuon\" (rouleaux de printemps frais). Anh vous guidera à travers les marchés locaux animés, où vous découvrirez les produits frais et pourrez vous imprégner de l'atmosphère animée des restaurants de fruits de mer de la ville. Préparez-vous à vivre une expérience culinaire riche en saveurs et en convivialité avec Anh à Nha Trang." };
           
            this.Journeys.AddRange(inde, inde2, mexique1, mexique2, japon1, japon2,italie1, italie2, vietnam1, vietnam2);


            Flight FlightInde = new Flight() { Id = 1, Airline = "Air India", DepartureCountry ="France", DepartureCity = "Paris CDG", DepartureDate = "2024-02-10", DestinationCountry="Inde", DestinationCity = "Chennai", FlightNumber = 547896 , Price=200};
            Flight FlightIndeRetour = new Flight() { Id = 9, Airline = "Air India", DepartureCountry = "Inde", DepartureCity = "Chennai", DepartureDate = "2024-02-24", DestinationCountry = "France", DestinationCity = "Paris CDG", FlightNumber = 987654, Price = 250 };
            Flight FlightInde2 = new Flight() { Id = 13, Airline = "Air India", DepartureCountry = "France", DepartureCity = "Nantes", DepartureDate = "2024-02-10", DestinationCountry = "Inde", DestinationCity = "Chennai", FlightNumber = 547896 , Price = 200 };
            Flight FlightIndeRetour2 = new Flight() { Id = 10, Airline = "Air India", DepartureCountry = "Inde", DepartureCity = "Chennai", DepartureDate = "2024-02-24", DestinationCountry = "France", DestinationCity = "Nantes", FlightNumber = 987654, Price = 300 };
            Flight FlightThailande = new Flight() { Id = 2, Airline = "Air thai", DepartureCountry = "France", DepartureCity = "Paris Orly", DepartureDate = "2024-07-18", DestinationCountry = "Thailande", DestinationCity = "Pukhet", FlightNumber = 165866 };
            Flight FlightMexique = new Flight() {Id = 3, Airline = "Mexico airline", DepartureCountry = "France", DepartureCity = "Nice", DepartureDate = "2024-02-10", DestinationCountry = "Mexique", DestinationCity = "Mexico", FlightNumber = 465732 };
            Flight FlightMexiqueRetour = new Flight() { Id = 12, Airline = "Mexico airline", DepartureCountry = "Mexique", DepartureCity = "Mexico", DepartureDate = "2024-02-10", DestinationCountry = "France", DestinationCity = "Nice", FlightNumber = 465732 };
            Flight FlightEthiopie = new Flight() { Id =4, Airline = "Ethiop'fly", DepartureCountry = "France", DepartureCity = "Lyon", DepartureDate = "2024-02-10", DestinationCountry = "Ethiopie", DestinationCity = "Mekele", FlightNumber = 688486 };
            Flight FlightFrance = new Flight() { Id = 5, Airline = "Air france", DepartureCountry = "France", DepartureCity = "Marseille", DepartureDate = "2024-02-10", DestinationCountry = "France", DestinationCity = "Paris", FlightNumber = 864566 };
            Flight FlightJapon = new Flight() { Id = 6, Airline = "Fly Japan", DepartureCountry = "France", DepartureCity = "Toulouse", DepartureDate = "2024-02-10", DestinationCountry = "Japon", DestinationCity = "Osaka", FlightNumber = 386618 };
            Flight FlightMaroc = new Flight() { Id = 7, Airline = "Boeing Maroc", DepartureCountry = "France", DepartureCity = "Bordeaux", DepartureDate = "2024-02-10", DestinationCountry = "Maroc", DestinationCity = "Marrakech", FlightNumber = 548675 };
            Flight FlightItalie = new Flight() { Id = 8, Airline = "Itaflyairway", DepartureCountry = "France", DepartureCity = "Nantes", DepartureDate = "2024-02-10", DestinationCountry = "Italie", DestinationCity = "Naples", FlightNumber = 397668 };
            Flight FlightThailandeRetour = new Flight() { Id = 11, Airline = "Air thai", DepartureCountry = "Thailande", DepartureCity = "Phuket", DepartureDate = "2024-07-18", DestinationCountry = "Thailande", DestinationCity = "Paris Orly", FlightNumber = 165866 };
            this.Flights.AddRange(FlightInde, FlightInde2, FlightThailande, FlightMexique, FlightEthiopie, FlightFrance, FlightJapon, FlightMaroc, FlightJapon, FlightItalie, FlightIndeRetour, FlightIndeRetour2, FlightThailandeRetour);  
            

            Accommodation accommodation1 = new Accommodation() {Id=1, Name = "Geetham", Type ="Chez l'habitant", Country ="Inde", City = "Chennai", Adress= "SRI NILAYAM, 2/95B, Rajiv Gandhi Salai, Thoraipakkam", Description ="Bon lit, bonne nourriture et bonne ambiance", Price = 20 };
            Accommodation accommodation2 = new Accommodation() {Id=2,Name="Rallye 2", Type = "Hôtel", Country = "Inde", City = "Chennai", Adress = "Place des Saveurs, Nungambakkam", Description = "Chambre d'hôtel spacieuse", Price=100 };
            Accommodation accommodation3 = new Accommodation() {Id=3, Name="Sunset Villa", Type= "Chambre d'hôte", Country ="Inde", City = "Chennai", Adress="Oia", Description="Vue imprenable du coucher de soleil sur l'océan indien dans des chambres luxueuses", Price = 200 };
            Accommodation accommodation4 = new Accommodation() { Id = 4, Name = "Villa de plage privée", Type = "Villa", Country = "Inde", City = "Chennai", Adress = "ECR Road", Description = "Évasion paisible sur une plage privée", Price = 120 };
            Accommodation accommodation5 = new Accommodation() { Id = 5, Name = "Hôtel de luxe Marina", Type = "Hôtel", Country = "Inde", City = "Chennai", Adress = "Marina Beach Road", Description = "Élégance et confort au bord de la mer", Price = 300 };
            Accommodation accommodation6 = new Accommodation() { Id = 6, Name = "Maison traditionnelle indienne", Type = "Maison d'hôtes", Country = "Inde", City = "Chennai", Adress = "Village de Mamallapuram", Description = "Découvrez l'hospitalité indienne dans une maison traditionnelle", Price = 150 };
             Accommodation accommodation7 = new Accommodation() { Id = 7, Name = "Appartement en centre-ville", Type = "Appartement", Country = "Inde", City = "Chennai", Adress = "Anna Salai", Description = "Confort et commodités au cœur de la ville", Price = 200 };

            this.Accommodations.AddRange(accommodation1, accommodation2, accommodation3, accommodation4, accommodation5, accommodation6, accommodation7);

            Activity activity1 = new Activity() { Id = 1, Name = "Visite du temple de Kapaleeshwarar",Country = "Inde", City = "Chennai", Adress = "Mylapore", Description = "Explorez l'architecture et la spiritualité du temple", Price = 50 };
            Activity activity2 = new Activity() { Id = 2, Name = "Promenade en bateau dans le golfe du Bengale",Country = "Inde", City = "Chennai", Adress = "Marina Beach", Description = "Profitez d'une balade relaxante en bateau", Price = 80 };
            Activity activity3 = new Activity() { Id = 3, Name = "Cours de danse classique indienne",Country = "Inde", City = "Chennai", Adress = "Kalakshetra Foundation", Description = "Découvrez la beauté de la danse classique indienne", Price = 100 };
            Activity activity4 = new Activity() { Id = 4, Name = "Excursion dans la réserve naturelle de Guindy", Country = "Inde", City = "Chennai", Adress = "Parc national de Guindy", Description = "Observez la faune et la flore locales", Price = 200 };
            Activity activity5 = new Activity() { Id = 5, Name = "Cours de cuisine indienne traditionnelle", Country = "Inde", City = "Chennai", Adress = "Institut culinaire de Chennai", Description = "Apprenez à préparer des plats indiens authentiques", Price = 20 };
            Activity activity6 = new Activity() { Id = 6, Country = "Inde", City = "Chennai", Name = "Cricket School Shooting",Price=50, Adress = "Rue Tandoori, Kilpauk", Description = "Le sport n°1 en Inde, venez essayer" };
            this.Activities.AddRange(activity1, activity2, activity3, activity4, activity5, activity6);

            Restauration restauration1 = new Restauration() { Id = 1, Name = "Le Palais des Épices", Type = "Cuisine indienne", Country = "Inde", City = "Chennai", Adress = "Avenue des Épices, Mylapore", Description = "Délicieux plats épicés de différentes régions de l'Inde", Price = 80 };
            Restauration restauration2 = new Restauration() { Id = 2, Name = "Restaurant Végétarien Sattvic", Type = "Cuisine végétarienne", Country = "Inde", City = "Chennai", Adress = "Rue Sattvic, Adyar", Description = "Nourriture pure et saine préparée selon les principes ayurvédiques", Price = 120 };
            Restauration restauration3 = new Restauration() { Id = 3, Name = "Le Café des Saveurs", Type = "Café et pâtisserie", Country = "Inde", City = "Chennai", Adress = "Place des Saveurs, Nungambakkam", Description = "Café aromatique et pâtisseries délicieuses", Price = 60 };
            Restauration restauration4 = new Restauration() { Id = 4, Name = "Grillades Tandoori", Type = "Cuisine grillée", Country = "Inde", City = "Chennai", Adress = "Rue Tandoori, Kilpauk", Description = "Viandes et légumes grillés à la perfection dans un four tandoor", Price = 150 };
            Restauration restauration5 = new Restauration() { Id = 5, Name = "Le Coin des Délices", Type = "Cuisine fusion", Country = "Inde", City = "Chennai", Adress = "Boulevard des Délices, Velachery", Description = "Combinaison créative de saveurs indiennes et internationales", Price = 200 };
            Restauration restauration6 = new Restauration() { Id = 6,   Country = "Inde", City = "Chennai", Type = "Chez l'habitant", Price = 100, Description ="Apprenez à cuisiner et déguster dans la foulée"};
            Restauration restauration7 = new Restauration() { Id = 7, Country = "Inde", City = "Chennai", Type = "Restaurant typique", Price = 50, Description = "Cusine typique de Chennai" };
            this.Restaurations.AddRange(restauration1, restauration2, restauration3, restauration4, restauration5, restauration6, restauration7);

            PackServices PS1 = new PackServices() { Id=1, AllInclusive=true, JourneyId=inde.Id, Journey=inde, UserId=1 };
            this.PackService.Add(PS1);

            FlightPackServices fPS = new FlightPackServices() { DepartureFlightId = FlightInde.Id, ReturnFlightId = FlightIndeRetour.Id, PackServicesId = PS1.Id };
            this.FlightPackServices.AddRange(fPS);

            AccommodationPackServices AccPS1 = new AccommodationPackServices() { PackServicesId = PS1.Id, AccommodationId= accommodation1.Id };
            AccommodationPackServices AccPS2 = new AccommodationPackServices() { PackServicesId = PS1.Id, AccommodationId = accommodation2.Id };
            AccommodationPackServices AccPS3 = new AccommodationPackServices() { PackServicesId = PS1.Id, AccommodationId = accommodation3.Id };
            this.AccommodationPackServices.AddRange(AccPS1,AccPS2, AccPS3);
            ActivityPackServices ActPS1 = new ActivityPackServices() { PackServicesId = PS1.Id, ActivityId = activity1.Id };
            ActivityPackServices ActPS2 = new ActivityPackServices() { PackServicesId = PS1.Id, ActivityId = activity2.Id };
            ActivityPackServices ActPS3 = new ActivityPackServices() { PackServicesId = PS1.Id, ActivityId = activity2.Id };
            this.ActivityPackServices.AddRange(ActPS1, ActPS2, ActPS3);
            RestaurationPackServices ResPS1 = new RestaurationPackServices() { PackServicesId = PS1.Id, RestaurationId = restauration1.Id };
            RestaurationPackServices ResPS2 = new RestaurationPackServices() { PackServicesId = PS1.Id, RestaurationId = restauration2.Id };
            RestaurationPackServices ResPS3 = new RestaurationPackServices() { PackServicesId = PS1.Id, RestaurationId = restauration3.Id };
            this.RestaurationPackServices.AddRange(ResPS1, ResPS2, ResPS3);

            this.SaveChanges();
        }
        
    }
}
