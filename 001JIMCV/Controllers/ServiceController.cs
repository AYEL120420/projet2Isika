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
            return View("AddService");
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View("AddService", service);
            }
            serviceDal.AddService(service);
            return RedirectToAction("AddService");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            Service service = serviceDal.GetServiceById(id);
            {
                if (service == null)
                {
                    return View("Error");
                }
                return View(service);
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {

            if (!ModelState.IsValid)
                return View(service);
            ModelState.Clear();

            if (service.Id != 0)
            {
                {
                    serviceDal.EditService(service);
                    return RedirectToAction("List", new { @id = service.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }


        [HttpGet]
        public IActionResult DeleteService(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            Service service = serviceDal.GetServiceById(id);
            {
                if (service == null)
                {
                    return View("Error");
                }
                return View(service);
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult DeleteService(Service service)
        {

            if (!ModelState.IsValid)
                return View(service);

            if (service.Id != 0)
            {
                {
                    serviceDal.DeleteService(service);
                    return RedirectToAction("List", new { @id = service.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }
    }
}

