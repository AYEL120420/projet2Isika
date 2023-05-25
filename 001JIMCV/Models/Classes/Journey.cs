namespace _001JIMCV.Models.Classes
{
    public class Journey
    {
        public int Id { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public string CountryDestination { get; set; }
        public int Persons { get; set; }
        public PackServices PackService { get; set; }

    }
}
