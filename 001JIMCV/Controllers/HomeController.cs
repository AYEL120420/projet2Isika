using Microsoft.AspNetCore.Mvc;

namespace _001JIMCV.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
