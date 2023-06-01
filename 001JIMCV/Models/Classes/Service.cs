using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _001JIMCV.Models.Classes
{
    public class Service
    {
        public int Id { get; set; }
        public string Nom { get; set; }   
        public string Pays { get; set; }
        public string Ville { get; set; }
        public DateAndTime Date { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }
        public float Prix { get; set; }
        public string Etat { get; set; }

        public int IdUser { get; set; }
        public virtual User UserProvider { get; set; }
    }
}
