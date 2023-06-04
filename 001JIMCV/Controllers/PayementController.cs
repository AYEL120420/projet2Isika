using Microsoft.AspNetCore.Mvc;

namespace _001JIMCV.Controllers
{
    public class PayementController : Controller
    {
        public IActionResult Index()
        {
            return View("Payement");
        }
    }
}
