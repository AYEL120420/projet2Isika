using Microsoft.VisualBasic;

namespace _001JIMCV.Models.Classes
{
    public class Activity
    {
        public int Id { get; set; }
        public string Pays { get; set; }
        public string Ville { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateAndTime Date { get; set; }
        public string Localisation { get; set; }
        public float Prix { get; set; }
        public string Status { get; set; }
        public byte[] Image { get; set; }  //doit être modifiée en liste
    }
}
