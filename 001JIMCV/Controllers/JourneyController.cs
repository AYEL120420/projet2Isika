using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using _001JIMCV.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                    ViewBag.listAccommodations = JourneyDal.GetAllAccommodations().Where(a => a.Pays == journey.CountryDestination);
                    ViewBag.listActivities = JourneyDal.GetAllActivities().Where(a => a.Pays == journey.CountryDestination);

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
