using System.ComponentModel.DataAnnotations;
using System.Data;

namespace _001JIMCV.Models.Classes
{
    public class OtherProposition
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderEmail { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Disponibility { get; set; }

        public string Program { get; set; }

        public string Accommodation { get; set; }

        public string Activities { get; set; }
       
        public string Restauration { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }
        public byte[] Image { get; set; }
    }
}
