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
            foreach (var accommodation in accommodations)
            {
                accommodation.Status = "En cours de traitement";
            }
            ViewData["Accommodations"] = accommodations ?? new List<_001JIMCV.Models.Classes.Accommodation>();
                return View("List");
          
        }

        [HttpPost]
        public IActionResult CreateAccommodation(Accommodation accommodation)
        {
      
            accommodationDal.AddAccommodation(accommodation);

            return RedirectToAction("GetList");
        }


        [HttpGet]
        public IActionResult EditAccommodation(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Accommodation accommodation = accommodationDal.GetAccommodationById(id);

            if (accommodation == null)
            {
                return View("Error");
            }

            return View("EditFormAccom", accommodation);
        }

        [HttpPost]
        public IActionResult EditAccommodation(Accommodation accommodation)
        {

            if (!ModelState.IsValid)
                return View(accommodation);

            if (accommodation.Id != 0)
            {
                {
                    accommodationDal.EditAccommodation(accommodation);
                    return RedirectToAction("GetList", new { @id = accommodation.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }


        [HttpGet]
        public IActionResult DeleteAccommodation(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Accommodation accommodation = accommodationDal.GetAccommodationById(id);

            if (accommodation == null)
            {
                return View("Error");
            }

            return View(accommodation);
        }

        [HttpPost]
        public IActionResult DeleteAccommodation(Accommodation accommodation)
        {
            if (!ModelState.IsValid)
            {
                return View(accommodation);
            }

            if (accommodation.Id != 0)
            {
                accommodationDal.DeleteAccommodation(accommodation);
                return RedirectToAction("GetList", new { id = accommodation.Id });
            }
            else
            {
                return View("Error");
            }
        }


    }
}

