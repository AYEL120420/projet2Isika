using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _001JIMCV.Models.Classes
{
    public class Accommodation
    {
        public int Id { get; set; }
        public int ProviderId { get; set; } 
        public string ProviderName { get; set; }
        public string ProviderEmail { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public string Adress { get; set; }
        public string StartDate { get; set; }
        public string EndDate{ get; set; }
        // public int Places { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public byte[] Image { get; set; }



    }
}
