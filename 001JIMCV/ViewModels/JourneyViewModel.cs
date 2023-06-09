using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _001JIMCV.ViewModels
{
    public class JourneyViewModel
    {
        public int journeyId { get; set; }  
        public Journey Journey { get; set; }
        public PackServices PackService { get; set; }

        public Flight DepartureFlight { get; set; }
        public Flight ReturnFlight { get; set; }
        public List<Accommodation>  Accommodations { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Restauration> Restaurations { get; set; }

        [Required]
        public int DepartureFlightCocheId { get; set; }
        [Required]
        public int ReturnFlightCocheId { get; set; }
        public List<string> AccommodationsCocheIds { get; set; }
        public List<string> ActivitiesCocheIds { get; set; }
        public List<string> RestaurationsCocheIds { get; set; }
        public Reservation Reservation { get; set; }
        public User User { get; set; }
    

    }


}

