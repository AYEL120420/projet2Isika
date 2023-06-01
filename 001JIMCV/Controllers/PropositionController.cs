using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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


            public IActionResult OtherPropForm()
            {
                return View("OtherPropForm"); // Renvoie la vue du formulaire de proposition
            }

            // Afficher la liste des autres propositions
            public IActionResult GetList()
            {
                var otherPropositions = propositionDal.GetAllPropositions();

                foreach (var proposition in otherPropositions)
                {
                    proposition.Status = "En cours de traitement";
                }

                ViewData["OtherPropositions"] = otherPropositions ?? new List<OtherProposition>();
                return View("List");
            }

            [HttpPost]
            public IActionResult CreateOtherProposition(OtherProposition proposition)
            {
                propositionDal.AddProposition(proposition);

                return RedirectToAction("GetList");
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
                    propositionDal.EditProposition(proposition);
                    return RedirectToAction("GetList", new { @id = proposition.Id });
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
                    return RedirectToAction("GetList", new { id = proposition.Id });
                }
                else
                {
                    return View("Error");
                }
            }
        }
    }




