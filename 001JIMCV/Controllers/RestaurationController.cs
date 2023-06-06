using _001JIMCV.Models.Classes;
using _001JIMCV.Models;
using Microsoft.AspNetCore.Mvc;
using _001JIMCV.Models.Dals;
using System.Collections.Generic;
using _001JIMCV.ViewModels;
using _001JIMCV.Models.Classes.Enum;
using System.Linq;

namespace _001JIMCV.Controllers
{
    public class RestaurationController : Controller
    {
        private RestaurationDal restaurationDal;
        private LoginDal loginDal;
        private DashboardDal dashboard;

        public RestaurationController()
        {
            restaurationDal = new RestaurationDal();
            loginDal = new LoginDal();
            dashboard = new DashboardDal();
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

        public ActionResult GetRestauration()

        {
            LoginViewModel viewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentified)
            {
                viewModel.User = loginDal.GetUser(HttpContext.User.Identity.Name);
                UserEnum role = viewModel.User.Role;
                switch (role)
                {
                    case UserEnum.Admin:
                        return RedirectToAction("GetList");
                    case UserEnum.Provider:
                        //  partenaire
                        var restaurations = restaurationDal.GetAllRestaurations()
                            .Where(p => p.ProviderId == viewModel.User.Id).ToList();
                        ViewData["Restaurations"] = restaurations ?? new List<_001JIMCV.Models.Classes.Restauration>();

                        return View("List");
                    default:

                        return View("Error");
                }
            }

            return View();
        }
        [HttpPost]
        public IActionResult CreateRestauration(Restauration restauration)
        {
            LoginViewModel viewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };

            viewModel.User = loginDal.GetUser(HttpContext.User.Identity.Name);
            UserEnum role = viewModel.User.Role;

            restaurationDal.AddRestauration(viewModel.User.Id, restauration.ProviderName, restauration.ProviderEmail, restauration.Country, restauration.City, restauration.Type, restauration.Description,
                    restauration.Adress, restauration.Menu, restauration.Price, restauration.Images);

            return RedirectToAction("GetRestauration");
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
                restaurationDal.EditRestauration(restauration.Id, restauration.ProviderName, restauration.ProviderEmail, restauration.Country, restauration.City, restauration.Type, restauration.Description, 
                    restauration.Adress, restauration.Menu, restauration.Price, restauration.Status,restauration.Images);
                return RedirectToAction("GetRestauration", new { @id = restauration.Id });
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
                return RedirectToAction("GetRestauration", new { id = restauration.Id });
            }
            else
            {
                return View("Error");
            }
        }
    }
}
