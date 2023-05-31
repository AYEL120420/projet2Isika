using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using XAct.Users;

namespace _001JIMCV.Controllers
{
    public class JourneyController : Controller
    {
        private JourneyDal dal;
        public JourneyController()
        {
            dal = new JourneyDal();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateJourney()
        {
            return View("CreateJourney");
        }
        [HttpPost]
        public IActionResult CreateJourney(Journey journey)
        {
            if (ModelState.IsValid)
            {
                int id = dal.AddJourney(journey.DepartureDate, journey.ReturnDate, journey.CountryDestination);

                return Redirect("JourneyAddServices?"+id);
            }
            return View("CreateJourney");
        }
        public IActionResult JourneyAddServices(int idJourney)
        {
            return View("JourneyAddServices");
        }

    }
}
