using Microsoft.VisualBasic;
using System.Reflection;

namespace _001JIMCV.Models.Classes
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string Pays { get; set; }
        public string Ville { get; set; }
        public string Type { get; set; }

        public string Adresse { get; set; }
        // public DateAndTime ArrivalDate { get; set; }
        //public DateAndTime DepartureDate { get; set; }
        public string De { get; set; } //disponible de 
        public string A { get; set; }//disponible à
        public float Prix { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public byte[] Image { get; set; }



    }
}
