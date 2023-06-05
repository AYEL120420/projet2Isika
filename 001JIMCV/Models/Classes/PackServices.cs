using _001JIMCV.Models.Classes.Enum;
using System;
using System.Collections.Generic;

namespace _001JIMCV.Models.Classes
{
    public class PackServices
    {
        public int Id { get; set; }
        public float Total_price { get; set; }
        public Boolean AllInclusive { get; set; }
        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
