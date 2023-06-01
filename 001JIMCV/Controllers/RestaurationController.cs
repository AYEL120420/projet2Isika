using _001JIMCV.Models.Classes;
using _001JIMCV.Models;
using Microsoft.AspNetCore.Mvc;
using _001JIMCV.Models.Dals;
using System.Collections.Generic;
using _001JIMCV.ViewModels;

namespace _001JIMCV.Controllers
{
    public class RestaurationController : Controller
    {
        private RestaurationDal restaurationDal;

        public RestaurationController()
        {
            restaurationDal = new RestaurationDal();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RestaurationForm()
        {
            return View("RestaurationForm"); // Renvoie la vue du formulaire de restauration
        }

        // Afficher la liste des restaurations
        public IActionResult GetList()
        {
            var restaurations = restaurationDal.GetAllRestaurations();

            foreach (var restauration in restaurations)
            {
                restauration.Status = "En cours de traitement";
            }

            ViewData["Restaurations"] = restaurations ?? new List<Restauration>();

            return View("List");
        }

        [HttpPost]
        public IActionResult CreateRestauration(Restauration restauration)
        {
            restaurationDal.AddRestauration(restauration);

            return RedirectToAction("GetList");
        }

        [HttpGet]
        public IActionResult EditRestauration(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Restauration restauration = restaurationDal.GetRestaurationById(id);

            if (restauration == null)
            {
                return View("Error");
            }

            return View("EditFormRestau", restauration);
        }

        [HttpPost]
        public IActionResult EditRestauration(Restauration restauration)
        {
            if (!ModelState.IsValid)
                return View(restauration);

            if (restauration.Id != 0)
            {
                restaurationDal.EditRestauration(restauration);
                return RedirectToAction("GetList", new { @id = restauration.Id });
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult DeleteRestauration(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Restauration restauration = restaurationDal.GetRestaurationById(id);

            if (restauration == null)
            {
                return View("Error");
            }

            return View(restauration);
        }

        [HttpPost]
        public IActionResult DeleteRestauration(Restauration restauration)
        {
            if (!ModelState.IsValid)
            {
                return View(restauration);
            }

            if (restauration.Id != 0)
            {
                restaurationDal.DeleteRestauration(restauration);
                return RedirectToAction("GetList", new { id = restauration.Id });
            }
            else
            {
                return View("Error");
            }
        }
    }
}
