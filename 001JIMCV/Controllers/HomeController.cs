using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _001JIMCV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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



