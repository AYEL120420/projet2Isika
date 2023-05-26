using _001JIMCV.Models.Classes;
using _001JIMCV.Models;
using Microsoft.AspNetCore.Mvc;
using _001JIMCV.Models.Dals;
using System.Collections.Generic;

namespace _001JIMCV.Controllers
{
    public class ServiceController : Controller
    {
        private ServiceDal serviceDal;
        public ServiceController()
        {
            serviceDal = new ServiceDal();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {

            var services = serviceDal.GetAllServices();
            ViewData["Services"] = services;
            return View();
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
            serviceDal.AddService(service);
            return RedirectToAction("AddService");
        }
        
    }
}
