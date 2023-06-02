namespace _001JIMCV.Models.Classes
{
    public class Flight
    {

        public int Id {  get; set; }
        public string FlightId { get; set; }
        public string Airline { get; set; }
        public float FlightNumber { get; set; }
        public string DepartureCountry { get; set; }
        public string DepartureCity { get; set; }
        public string DestinationCountry{ get; set; }
        public string DestinationCity { get; set; }
        public string DepartureDate { get; set; }
        public int ServiceId { get; set; }
    }
}
