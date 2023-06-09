using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _001JIMCV.Models.Classes
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string TravelStartDate { get; set; }
        public string TravelEndDate { get; set; }
    
        public string ContactName { get; set; }
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Veuillez saisir une adresse e-mail valide.")]
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public float Price { get; set; }
        public string Status { get;set; }   
        public string NameCard { get; set; }
        public int NumCard { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public int JourneyId { get; set; }
        public int PackServiceId { get;set; }
        public int UserId { get; set; }
        
        // public virtual Journey Journey { get; set; }
        // public virtual User User { get; set; }
    }
}
