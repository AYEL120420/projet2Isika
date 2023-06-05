using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using _001JIMCV.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using XAct;
using XAct.Users;

namespace _001JIMCV.Controllers
{
    public class JourneyController : Controller
    {
        private static string DEPARTURECOUNTRYOFALLJOURNEYS = "France";
        private JourneyDal JourneyDal;
        public JourneyController()
        {
            JourneyDal = new JourneyDal();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateJourney()
        {
            return View();
        }

        public IActionResult DisplayJourney(int Id)
        {
            if (Id != 0)
            {
                //On récupère le voyage associé à l'Id
                Journey journey = JourneyDal.GetAllJourneys().Where(r => r.Id == Id).FirstOrDefault();

                if (journey != null)
                {
                    // on crée le viewmodel du voyage
                    JourneyViewModel jvm = new JourneyViewModel
                    {
                        Journey = journey,

                        // On récupère le Pack de Service associé à l'id du voyage et qui est clé en main
                        PackService = JourneyDal.GetAllPacks().Where(r => r.JourneyId == Id & r.AllInclusive == true).FirstOrDefault(),

                    };

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
                    ViewBag.listAccommodations = accommodations;

                    // On récupère les Activités associés au Pack
                    List<ActivityPackServices> activityPackServices = JourneyDal.GetAllActivityPackServices().Where(r => r.PackServicesId == jvm.PackService.Id).ToList();
                    List<Activity> activities = new List<Activity>();
                    foreach (ActivityPackServices aps in activityPackServices)
                    {
                        Activity activity = new Activity();
                        activity = JourneyDal.GetActivity(aps.ActivityId);
                        activities.Add(activity);
                    }
                    ViewBag.listActivities = activities;

                    // On récupère les restaurants associés au Pack
                    List<RestaurationPackServices> restaurationPackServices = JourneyDal.GetAllRestaurationPackServices().Where(r => r.PackServicesId == jvm.PackService.Id).ToList();
                    List<Restauration> restaurations = new List<Restauration>();
                    foreach (RestaurationPackServices aps in restaurationPackServices)
                    {
                        Restauration restauration = new Restauration();
                        restauration = JourneyDal.GetRestauration(aps.RestaurationId);
                        restaurations.Add(restauration);
                    }
                    ViewBag.listRestaurations = restaurations;


                    return View("Produits", jvm);
                }

            }

            return View("Error");
        }

        [HttpPost]
        public IActionResult CreateJourney(Journey journey)
        {
            if (ModelState.IsValid)
            {
                int id = JourneyDal.AddJourney(journey.DepartureDate, journey.ReturnDate, journey.CountryDestination);

                return RedirectToAction("JourneyAddServices", new { @id = id });
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
                        Journey = journey
                    };

                    ViewBag.listFlightsDep = JourneyDal.GetAllFLights().Where(f => f.DestinationCountry == journey.CountryDestination & f.DepartureDate == journey.DepartureDate);
                    ViewBag.listFlightsReturn = JourneyDal.GetAllFLights().Where(f => f.DestinationCountry == DEPARTURECOUNTRYOFALLJOURNEYS & f.DepartureDate == journey.ReturnDate);
                    ViewBag.listAccommodations = JourneyDal.GetAllAccommodations().Where(a => a.Country == journey.CountryDestination);
                    ViewBag.listActivities = JourneyDal.GetAllActivities().Where(a => a.Country == journey.CountryDestination);

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
                int idPackServices = JourneyDal.AddPackServices();

                JourneyDal.AddFlightPackServices(jvm.DepartureFlightId, jvm.ReturnFlightId, idPackServices);

                foreach (string accomodationId in jvm.AccommodationsCocheIds)
                {
                    if (accomodationId != null)
                    {
                        int idAccomodation;
                        if (int.TryParse(accomodationId, out idAccomodation))
                        {
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
                            JourneyDal.AddActivityPackServices(idActivity, idPackServices);
                        }
                    }
                }

                return RedirectToAction("DashboardJourney");
            }
            return View(jvm);
        }

    }
}