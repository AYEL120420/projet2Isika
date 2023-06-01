using _001JIMCV.Models.Classes.Enum;
using System;
using System.Collections.Generic;

namespace _001JIMCV.Models.Classes
{
    public class PackServices
    {
        public int Id { get; set; }
        public float Total_price { get; set; }
        public Boolean All_Inclusive { get; set; }
        public StatusEnum Status { get; set; }
        public int DepartureFlightId { get; set; }
        public Flight DepartureFlight { get; set; }
        public int ReturnFlightId { get; set; }
        public Flight ReturnFlight { get; set; }


    }
}
