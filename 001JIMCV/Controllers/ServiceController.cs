using _001JIMCV.Models.Classes;
using _001JIMCV.Models;
using Microsoft.AspNetCore.Mvc;
using _001JIMCV.Models.Dals;

namespace _001JIMCV.Controllers
{
    public class ServiceController : Controller
    {
        private ServiceDal ServiceDal;
        public ServiceController()
        {
            ServiceDal = new ServiceDal();
        }
        public IActionResult Index()
        {
            return View("ServiceView");
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View("ServiceView");
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View("ServiceView", service);
            }
            ServiceDal.AddService(service);
            return RedirectToAction("AddService");
        }
    }
}
