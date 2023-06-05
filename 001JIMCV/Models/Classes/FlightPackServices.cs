namespace _001JIMCV.Models.Classes
{
    public class FlightPackServices
    {
        public int Id { get; set; }
        public int DepartureFlightId { get; set; }
        public Flight DepartureFlight { get; set; }
        public int ReturnFlightId { get; set; }
        public Flight ReturnFlight { get; set; }


        public int PackServicesId { get; set; }
        public PackServices PackServices { get; set; }
    }
}
