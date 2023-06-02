using Microsoft.AspNetCore.Mvc;

namespace _001JIMCV.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Admin()
        {
            return View("AdminDashboard");
        }

        public IActionResult Provider()
        {
            return View("ProviderDashboard");
        }

        public IActionResult Client()
        {
            return View("ClientDashboard");
        }
    }
}
