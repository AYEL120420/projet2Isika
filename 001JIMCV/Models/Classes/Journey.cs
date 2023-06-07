using _001JIMCV.Models.Classes.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _001JIMCV.Models.Classes
{
    public class Journey
    {
        public int Id { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public string DepartureCity { get; set; }
        public string CountryDestination { get; set; }
        public string CityDestination { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Persons { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }


    }
}
