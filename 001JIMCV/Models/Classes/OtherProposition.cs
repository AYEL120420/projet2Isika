using System.ComponentModel.DataAnnotations;
using System.Data;

namespace _001JIMCV.Models.Classes
{
    public class OtherProposition
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string Pays { get; set; }
        public string Ville { get; set; }
        public string Titre { get; set; }

        public string Description { get; set; }

        public string Disponibilite { get; set; }

        public string Programme { get; set; }

        public string Hebergement { get; set; }

        public string Activites { get; set; }
       
        public string Restauration { get; set; }

        public decimal Prix { get; set; }
        public string Status { get; set; }
    }
}
