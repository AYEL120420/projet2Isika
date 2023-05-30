using Microsoft.AspNetCore.Mvc;

namespace _001JIMCV.Controllers
{
    public class JourneyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateJourney()
        {
            return View("CreateJourney");
        }

    }
}
