using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using Microsoft.AspNetCore.Mvc;

namespace _001JIMCV.Controllers
{
    public class PropositionController : Controller
    {
        private PropositionDal propositionDal;
        private object propositionDAL;

        public PropositionController()
        {
            propositionDal = new PropositionDal();
        }
        public IActionResult Index()
        {
            return View("ProviderDashboard");
        }
        public IActionResult Form()
        {
            return View("FormProposition");
        }

    
        public IActionResult AccomodationForm()
        {
            return View("AccomodationForm"); // Renvoie la vue du formulaire d'hébergement
        }

        public IActionResult ActivityForm()
        {
            return View("ActivityForm"); // Renvoie la vue du formulaire d'activité
        }

        public IActionResult RestaurationForm()
        {
            return View("RestaurationForm"); // Renvoie la vue du formulaire de restauration
        }

        public IActionResult TourForm()
        {
            return View("TourForm"); // Renvoie la vue du formulaire de circuit
        }

        public IActionResult DefaultForm()
        {
            return View("DefaultForm"); // Renvoie la vue par défaut pour les autres formulaires
        }




    }
}
