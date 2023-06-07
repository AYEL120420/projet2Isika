using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;
using _001JIMCV.Models.Dals;
using _001JIMCV.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace _001JIMCV.Controllers
{
    public class PropositionController : Controller
    {
        private PropositionDal propositionDal;
        private LoginDal loginDal;
        private DashboardDal dashboardDal;

        public PropositionController()
        {
            propositionDal = new PropositionDal();
            loginDal = new LoginDal();
            dashboardDal = new DashboardDal();
        }

        public IActionResult Index()
        {
            return View("ProviderDashboard");
        }

        public IActionResult OtherPropForm()
        {
            return View("OtherPropForm"); // Renvoie la vue du formulaire de proposition
        }
        
        // Afficher la liste des autres propositions
        public IActionResult GetList()
        {
            var otherPropositions = propositionDal.GetAllPropositions();

            ViewData["OtherPropositions"] = otherPropositions ?? new List<OtherProposition>();
            return View("List");
        }

     
        public ActionResult GetOtherPropositions()
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
                        // partenaire
                        var otherPropositions = propositionDal.GetAllPropositions()
                            .Where(p => p.ProviderId == viewModel.User.Id).ToList();
                        ViewData["OtherPropositions"] = otherPropositions ?? new List<OtherProposition>();

                        return View("List");
                    default:
                        return View("Error");
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult CreateOtherProposition(OtherProposition proposition)
        {
            LoginViewModel viewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };

            viewModel.User = loginDal.GetUser(HttpContext.User.Identity.Name);
            UserEnum role = viewModel.User.Role;

            propositionDal.AddProposition(viewModel.User.Id,proposition.ProviderName,proposition.ProviderEmail, proposition.Country, proposition.City, proposition.Name,
                proposition.Description, proposition.Disponibility, proposition.Program, proposition.Accommodation, proposition.Activities, proposition.Restauration, proposition.Price, proposition.Image);

            return RedirectToAction("GetOtherPropositions");
        }

        [HttpGet]
        public IActionResult EditOtherProposition(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            OtherProposition proposition = propositionDal.GetPropositionById(id);

            if (proposition == null)
            {
                return View("Error");
            }

            return View("EditFormProposition", proposition);
        }

        [HttpPost]
        public IActionResult EditOtherProposition(OtherProposition proposition)
        {
            if (!ModelState.IsValid)
                return View(proposition);

            if (proposition.Id != 0)
            {
                propositionDal.EditProposition(proposition.Id, proposition.ProviderName, proposition.ProviderEmail, proposition.Country, proposition.City, proposition.Name,
                proposition.Description, proposition.Disponibility, proposition.Program, proposition.Accommodation, proposition.Activities, proposition.Restauration, proposition.Price,proposition.Image, proposition.Status);
                return RedirectToAction("GetOtherPropositions", new { id = proposition.Id });
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult DeleteOtherProposition(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            OtherProposition proposition = propositionDal.GetPropositionById(id);

            if (proposition == null)
            {
                return View("Error");
            }

            return View(proposition);
        }

        [HttpPost]
        public IActionResult DeleteOtherProposition(OtherProposition proposition)
        {
            if (!ModelState.IsValid)
            {
                return View(proposition);
            }

            if (proposition.Id != 0)
            {
                propositionDal.DeleteProposition(proposition);
                return RedirectToAction("GetOtherPropositions", new { id = proposition.Id });
            }
            else
            {
                return View("Error");
            }
        }
    }
}

