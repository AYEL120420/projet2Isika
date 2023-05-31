using _001JIMCV.Models.Classes;
using _001JIMCV.Models;
using Microsoft.AspNetCore.Mvc;
using _001JIMCV.Models.Dals;
using System.Collections.Generic;
using _001JIMCV.ViewModels;

namespace _001JIMCV.Controllers
{
    public class AccommodationController : Controller
    {
        private AccommodationDal accommodationDal;
        public AccommodationController()
        {
            accommodationDal = new AccommodationDal();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccommodationForm()
        {
            return View("AccommodationForm"); // Renvoie la vue du formulaire d'hébergement
        }

        //Afficher la liste des accommodations

        public IActionResult GetList()
        {
           
                var accommodations = accommodationDal.GetAllAccommodations();
                ViewData["Accommodations"] = accommodations ?? new List<_001JIMCV.Models.Classes.Accommodation>();
                return View();
          
        }

        [HttpPost]
        public IActionResult CreateAccommodation(Accommodation accommodation)
        {
            if (!ModelState.IsValid)
            {
                return View("List", accommodation);
            }
            accommodationDal.AddAccommodation(accommodation);

            return RedirectToAction("GetList");
        }


        /*[HttpGet]
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
        }*/
    }
}

