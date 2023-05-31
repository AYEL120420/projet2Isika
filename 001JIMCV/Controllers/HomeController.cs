using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

