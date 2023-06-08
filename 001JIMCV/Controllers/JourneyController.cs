using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using _001JIMCV.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Activity = _001JIMCV.Models.Classes.Activity;

namespace _001JIMCV.Controllers
{
    public class JourneyController : Controller
    {
        private static string DEPARTURECOUNTRYOFALLJOURNEYS = "France";
        private JourneyDal JourneyDal;
        private LoginDal LoginDal;
        private IWebHostEnvironment _webEnv;
        public JourneyController(IWebHostEnvironment environment)
        {
            JourneyDal = new JourneyDal();
            LoginDal = new LoginDal();
            _webEnv = environment;
        }

  
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllJourneys()
        {
            var journey = JourneyDal.GetAllJourneys();
            ViewData["Journeys"] = journey ?? new List<Journey>();
            return View("ListJourney");
        }

        public JourneyViewModel GetJourneyViewModelFull(int JourneyId, Boolean allInclusive)
        {
            JourneyViewModel jvm = new JourneyViewModel();
            jvm.journeyId = JourneyId;

            //On récupère le voyage associé à l'Id
            Journey journey = JourneyDal.GetAllJourneys().Where(r => r.Id == JourneyId).FirstOrDefault();

            if (journey != null)
            {
                jvm.Journey = journey;

                // On récupère le Pack de Service associé à l'id du voyage et qui est clé en main
                jvm.PackService = JourneyDal.GetAllPacks().Where(r => r.JourneyId == JourneyId & r.AllInclusive == allInclusive).FirstOrDefault();


                //On récupère les vols associé au pack de Service
                FlightPackServices flightPackServices = JourneyDal.GetFLightPackServices(jvm.PackService.Id);
                jvm.DepartureFlight = JourneyDal.GetFlight(flightPackServices.DepartureFlightId);
                jvm.ReturnFlight = JourneyDal.GetFlight(flightPackServices.ReturnFlightId);

                // On récupère les Hébergements associés au Pack
                List<AccommodationPackServices> accommodationsPackServices = JourneyDal.GetAllAccommodationsPackServices().Where(r => r.PackServicesId == jvm.PackService.Id).ToList();
                List<Accommodation> accommodations = new List<Accommodation>();
                foreach (AccommodationPackServices aps in accommodationsPackServices)
                {
                    Accommodation accommodation = new Accommodation();
                    accommodation = JourneyDal.GetAccommodation(aps.AccommodationId);
                    accommodations.Add(accommodation);
                }
                jvm.Accommodations = accommodations;

                // On récupère les Activités associés au Pack
                List<ActivityPackServices> activityPackServices = JourneyDal.GetAllActivityPackServices().Where(r => r.PackServicesId == jvm.PackService.Id).ToList();
                List<Activity> activities = new List<Activity>();
                foreach (ActivityPackServices aps in activityPackServices)
                {
                    Activity activity = new Activity();
                    activity = JourneyDal.GetActivity(aps.ActivityId);
                    activities.Add(activity);
                }
                jvm.Activities = activities;

                // On récupère les restaurants associés au Pack
                List<RestaurationPackServices> restaurationPackServices = JourneyDal.GetAllRestaurationPackServices().Where(r => r.PackServicesId == jvm.PackService.Id).ToList();
                List<Restauration> restaurations = new List<Restauration>();
                foreach (RestaurationPackServices aps in restaurationPackServices)
                {
                    Restauration restauration = new Restauration();
                    restauration = JourneyDal.GetRestauration(aps.RestaurationId);
                    restaurations.Add(restauration);
                }
                jvm.Restaurations = restaurations;
            }
            return jvm;
        }

        public IActionResult DisplayJourney(int Id)
        {
            if (Id != 0)
            {
                JourneyViewModel jvm = GetJourneyViewModelFull(Id, true);

                return View("Produits", jvm);

            }
            return View("Error");
        }


        public IActionResult ReservationAllInclusive(int Id)
        {
            LoginViewModel loginViewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                JourneyViewModel jvm = GetJourneyViewModelFull(Id, true);

                string userId = User.FindFirst(ClaimTypes.Name).Value;
                loginViewModel.User = LoginDal.GetUser(userId);

                if (ModelState.IsValid)
                {
                    int idPackServices = JourneyDal.AddPackServices(jvm.journeyId, loginViewModel.User.Id);

                    JourneyDal.AddFlightPackServices(jvm.DepartureFlight.Id, jvm.ReturnFlight.Id, idPackServices);

                    foreach (Accommodation accommodation in jvm.Accommodations)
                    {
                        if (accommodation != null)
                        {
                            JourneyDal.AddAccommodationPackServices(accommodation.Id, idPackServices);
                        }
                    }
                    foreach (Activity activity in jvm.Activities)
                    {
                        if (activity != null)
                        {
                            JourneyDal.AddActivityPackServices(activity.Id, idPackServices);

                        }
                    }
                    foreach (Restauration restauration in jvm.Restaurations)
                    {
                        if (restauration != null)
                        {
                            JourneyDal.AddActivityPackServices(restauration.Id, idPackServices);

                        }
                    }

                    return RedirectToAction("Index", "Reservation", new { id = idPackServices });
                }
            }

            return View("Error");
        }
        public IActionResult DisplayJourneyPerso(int Id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                JourneyViewModel jvm = GetJourneyViewModelFull(Id, true);

                if (jvm.Journey != null)
                {
                    ViewBag.listFlightsDep = JourneyDal.GetAllFLights().Where(f => f.DestinationCountry == jvm.Journey.CountryDestination );
                    ViewBag.listFlightsReturn = JourneyDal.GetAllFLights().Where(f => f.DepartureCountry == jvm.Journey.CountryDestination );
                    ViewBag.listAccommodations = JourneyDal.GetAllAccommodations().Where(a => a.Country == jvm.Journey.CountryDestination);
                    ViewBag.listActivities = JourneyDal.GetAllActivities().Where(a => a.Country == jvm.Journey.CountryDestination);
                    ViewBag.listRestaurants = JourneyDal.GetAllRestaurations().Where(r => r.Country == jvm.Journey.CountryDestination);

                    return View("ModifProduits", jvm);
                }

            }

            return View("Error");
        }
        [HttpPost]
        public IActionResult DisplayJourneyPerso(JourneyViewModel jvm)
        {
            if (ModelState.IsValid)
            {
                float TotalAmount = 0;
                LoginViewModel loginViewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
                string userId = User.FindFirst(ClaimTypes.Name).Value;
                loginViewModel.User = LoginDal.GetUser(userId);

                int idPackServices = JourneyDal.AddPackServices(jvm.journeyId, loginViewModel.User.Id);

                JourneyDal.AddFlightPackServices(jvm.DepartureFlightCocheId, jvm.ReturnFlightCocheId, idPackServices);
                float departureflightPrice = JourneyDal.GetFlightPrice(jvm.DepartureFlightCocheId);
                float returnflightPrice = JourneyDal.GetFlightPrice(jvm.ReturnFlightCocheId);
                TotalAmount=departureflightPrice+returnflightPrice;

                foreach (string accomodationId in jvm.AccommodationsCocheIds)
                {
                    if (accomodationId != null)
                    {
                        int idAccomodation;
                        if (int.TryParse(accomodationId, out idAccomodation))
                        {
                            float accommodationPrice = JourneyDal.GetAccommodationPrice(idAccomodation);
                            TotalAmount += accommodationPrice;
                            JourneyDal.AddAccommodationPackServices(idAccomodation, idPackServices);
                        }
                    }

                }
                foreach (string activityId in jvm.ActivitiesCocheIds)
                {
                    if (activityId != null)
                    {
                        int idActivity;
                        if (int.TryParse(activityId, out idActivity))
                        {
                            float activityPrice = JourneyDal.GetActivityPrice(idActivity);
                            TotalAmount += activityPrice;
                            JourneyDal.AddActivityPackServices(idActivity, idPackServices);
                        }
                    }
                }
                foreach (string restaurationId in jvm.RestaurationsCocheIds)
                {
                    if (restaurationId != null)
                    {
                        int idRestauration;
                        if (int.TryParse(restaurationId, out idRestauration))
                        {
                            float restaurationPrice = JourneyDal.GetRestaurationPrice(idRestauration);
                            TotalAmount += restaurationPrice;
                            JourneyDal.AddAccommodationPackServices(idRestauration, idPackServices);
                      
                        }
                    }
                }
                JourneyDal.UpdatePricePackService(idPackServices, TotalAmount);
                return RedirectToAction("Index", "Reservation", new { id = idPackServices });
            }
            return View(jvm);
        }
      
            public IActionResult CreateJourney()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateJourney(Journey journey)
        {
            if (ModelState.IsValid)
            {
                if (journey.Image != null)
                {
                    if (journey.Image.Length != 0)
                    {
                        string uploads = Path.Combine(_webEnv.WebRootPath, "Images");
                        string filePath = Path.Combine(uploads, journey.Image.FileName);
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            journey.Image.CopyTo(fileStream);
                        }
                        int id = JourneyDal.AddJourney(journey.DepartureDate, journey.ReturnDate, journey.CountryDestination,journey.CityDestination,journey.DepartureCity,journey.Price , journey.Description,"/Images/" + journey.Image.FileName);

                        return RedirectToAction("JourneyAddServices", new { @id = id });
                    }
                }else 
                {
                    int id = JourneyDal.AddJourney(journey.DepartureDate, journey.ReturnDate, journey.CountryDestination, journey.CityDestination, journey.DepartureCity, journey.Price, journey.Description,journey.ImagePath);

                    return RedirectToAction("JourneyAddServices", new { @id = id });
                }
            }
                    return View("Error");
                
            
        }
        public IActionResult JourneyAddServices(int id)
        {
            if (id != 0)
            {

                Journey journey = JourneyDal.GetAllJourneys().Where(r => r.Id == id).FirstOrDefault();

                if (journey != null)
                {

                    JourneyViewModel jvm = new JourneyViewModel
                    {
                        journeyId = id,
                        Journey = journey
                    };

                    ViewBag.listFlightsDep = JourneyDal.GetAllFLights().Where(f => f.DestinationCountry == journey.CountryDestination & f.DepartureDate == journey.DepartureDate);
                    ViewBag.listFlightsReturn = JourneyDal.GetAllFLights().Where(f => f.DepartureCountry == journey.CountryDestination & f.DepartureDate == journey.ReturnDate);
                    ViewBag.listAccommodations = JourneyDal.GetAllAccommodations().Where(a => a.Country == journey.CountryDestination);
                    ViewBag.listActivities = JourneyDal.GetAllActivities().Where(a => a.Country == journey.CountryDestination);
                    ViewBag.listRestaurants = JourneyDal.GetAllRestaurations().Where(r => r.Country == jvm.Journey.CountryDestination);

                    return View(jvm);
                }

            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult JourneyAddServices(JourneyViewModel jvm)
        {
            if (ModelState.IsValid)
            {
                float TotalAmount = 0;
                LoginViewModel loginViewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
                if (!loginViewModel.Authentified)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    string userId = User.FindFirst(ClaimTypes.Name).Value;
                    loginViewModel.User = LoginDal.GetUser(userId);

                    int idPackServices = JourneyDal.AddPackServicesAllInclusive(jvm.journeyId, loginViewModel.User.Id);

                    JourneyDal.AddFlightPackServices(jvm.DepartureFlightCocheId, jvm.ReturnFlightCocheId, idPackServices);
                    float departureflightPrice = JourneyDal.GetFlightPrice(jvm.DepartureFlightCocheId);
                   /* float returnflightPrice = JourneyDal.GetFlightPrice(jvm.ReturnFlightCocheId);
                    TotalAmount = departureflightPrice + returnflightPrice;*/

                    foreach (string accomodationId in jvm.AccommodationsCocheIds)
                    {
                        if (accomodationId != null)
                        {
                            int idAccomodation;
                            if (int.TryParse(accomodationId, out idAccomodation))
                            {
                                /*float accommodationPrice = JourneyDal.GetAccommodationPrice(idAccomodation);
                                TotalAmount += accommodationPrice;*/
                                JourneyDal.AddAccommodationPackServices(idAccomodation, idPackServices);
                            }
                        }
                    }
                    foreach (string activityId in jvm.ActivitiesCocheIds)
                    {
                        if (activityId != null)
                        {
                            int idActivity;
                            if (int.TryParse(activityId, out idActivity))
                            {
                               /* float activityPrice = JourneyDal.GetActivityPrice(idActivity);
                                TotalAmount += activityPrice;*/
                                JourneyDal.AddActivityPackServices(idActivity, idPackServices);
                            }
                        }
                    }
                    foreach (string restaurationId in jvm.RestaurationsCocheIds)
                    {
                        if (restaurationId != null)
                        {
                            int idRestauration;
                            if (int.TryParse(restaurationId, out idRestauration))
                            {
                               /* float restaurationPrice = JourneyDal.GetRestaurationPrice(idRestauration);
                                TotalAmount += restaurationPrice;*/
                                JourneyDal.AddRestaurationPackServices(idRestauration, idPackServices);
                            }
                        }
                    }
                    //JourneyDal.UpdatePricePackService(idPackServices, TotalAmount);
                    return RedirectToAction("GetAllJourneys");
                }
            }
            return View(jvm);
        }
        [HttpGet]
        public IActionResult DeleteJourney(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Journey journey = JourneyDal.GetJourney(id);

            if (journey == null)
            {
                return View("Error");
            }

            return View(journey);
        }

        [HttpPost]
        public IActionResult DeleteJourney(Journey journey)
        {
            if (!ModelState.IsValid)
            {
                return View(journey);
            }

            if (journey.Id != 0)
            {
                JourneyDal.DeleteJourney(journey);
                return RedirectToAction("GetAllJourneys", new { id = journey.Id });
            }
            else
            {
                return View("Error");
            }
        }

    }
}