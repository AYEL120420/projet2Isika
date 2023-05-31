using _001JIMCV.Models.Classes;
using _001JIMCV.Models;
using Microsoft.AspNetCore.Mvc;
using _001JIMCV.Models.Dals;
using System.Collections.Generic;
using _001JIMCV.ViewModels;

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

        //Afficher la liste des serices
       
        public IActionResult List()
        {
           
                var services = serviceDal.GetAllServices();
                ViewData["Services"] = services ?? new List<_001JIMCV.Models.Classes.Service>();
                return View();
          
        }

        //Ajouter un service à la liste
      /*  [HttpGet]
        public IActionResult AddService()
        {
            return RedirectToAction("List");
        }*/

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View("List", service);
            }
            serviceDal.AddService(service);

            return RedirectToAction("List");
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

