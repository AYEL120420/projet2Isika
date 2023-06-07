using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;
using _001JIMCV.Models.Dals;
using _001JIMCV.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _001JIMCV.Controllers
{
    public class ActivityController : Controller
    {
        private ActivityDal activityDal;
        private LoginDal loginDal;
        private DashboardDal dashboardDal;
        public ActivityController()
        {
            activityDal = new ActivityDal();
            loginDal = new LoginDal();
            dashboardDal = new DashboardDal();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ActivityForm()
        {
            return View("ActivityForm"); // Renvoie la vue du formulaire d'activité
        }

        // Afficher la liste des activités
        public IActionResult GetList()
        {
            var activities = activityDal.GetAllActivities();

            ViewData["Activities"] = activities ?? new List<Activity>();
            return View("List");
        }
        public ActionResult GetActivity()

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
                        var activities = activityDal.GetAllActivities()
                            .Where(p => p.ProviderId == viewModel.User.Id).ToList();
                        ViewData["Activities"] = activities ?? new List<Activity>();

                        return View("List");
                    default:

                        return View("Error");
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult CreateActivity(Activity activity)
        {
            LoginViewModel viewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };


            viewModel.User = loginDal.GetUser(HttpContext.User.Identity.Name);
            UserEnum role = viewModel.User.Role;

            activityDal.AddActivity(viewModel.User.Id, activity.ProviderName, activity.ProviderEmail, activity.Country, activity.City, activity.Name, activity.Date, activity.Description, activity.Adress, activity.Price, activity.Image);

            return RedirectToAction("GetActivity");
        }

        [HttpGet]
        public IActionResult EditActivity(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Activity activity = activityDal.GetActivityById(id);

            if (activity == null)
            {
                return View("Error");
            }

            return View("EditFormAct", activity);
        }

        [HttpPost]
        public IActionResult EditActivity(Activity activity)
        {
            if (!ModelState.IsValid)
                return View(activity);

            if (activity.Id != 0)
            {
                activityDal.EditActivity(activity.Id,activity.ProviderName, activity.ProviderEmail, activity.Country, activity.City, activity.Name, 
                    activity.Date, activity.Adress, activity.Description, activity.Price, activity.Status, activity.Image);
                return RedirectToAction("GetActivity", new { id = activity.Id });
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult DeleteActivity(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Activity activity = activityDal.GetActivityById(id);

            if (activity == null)
            {
                return View("Error");
            }

            return View(activity);
        }

        [HttpPost]
        public IActionResult DeleteActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return View(activity);
            }

            if (activity.Id != 0)
            {
                activityDal.DeleteActivity(activity);
                return RedirectToAction("GetActivity", new { id = activity.Id });
            }
            else
            {
                return View("Error");
            }
        }
    }
}

