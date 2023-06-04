using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using _001JIMCV.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace _001JIMCV.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;
       private JourneyDal JourneyDal { get; set; }

        public HomeController()
        {
           // _logger = logger;
           JourneyDal = new JourneyDal();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult IndeFullPackage01()
        {
            List<Journey> IndeJourneys = JourneyDal.GetAllJourneys().Where(j => j.CountryDestination == "Inde").ToList();
            ViewData["IndeJourneys"] = IndeJourneys;
            return View("Inde/IndeFullPackage01");
        }

        public IActionResult ItalieFullPackage01()
        {
            return View("Italie/ItalieFullPackage01");
        }

        public IActionResult JaponFullPackage01()
        {
            return View("Japon/JaponFullPackage01");
        }

        public IActionResult MexiqueFullPackage01()
        {
            return View("Mexique/MexiqueFullPackage01");
        }

        public IActionResult VietnamFullPackage01()
        {
            return View("Vietnam/VietnamFullPackage01");
        }
        public IActionResult MonProfil()
        {
            return View("MonProfil");
        }
    }
}



