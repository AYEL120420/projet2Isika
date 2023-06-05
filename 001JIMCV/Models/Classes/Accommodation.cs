using Microsoft.VisualBasic;
using System.Reflection;

namespace _001JIMCV.Models.Classes
{
    public class Accommodation
    {
        public int Id { get; set; }
        public int ProviderId { get; set; } 
        public string ProviderName { get; set; }
        public string ProviderEmail { get; set; }
        public string Pays { get; set; }
        public string Ville { get; set; }
        public string Type { get; set; }
        public string Nom { get; set; }

        public string Adresse { get; set; }
        public string De { get; set; }
        public string A { get; set; }
       // public int Places { get; set; }
        public float Prix { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public byte[] Image { get; set; }



    }
}
