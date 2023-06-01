using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _001JIMCV.Controllers
{
    public class ActivityController : Controller
    {
        private ActivityDal activityDal;

        public ActivityController()
        {
            activityDal = new ActivityDal();
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

            foreach (var activity in activities)
            {
                activity.Status = "En cours de traitement";
            }

            ViewData["Activities"] = activities ?? new List<Activity>();
            return View("List");
        }

        [HttpPost]
        public IActionResult CreateActivity(Activity activity)
        {
            activityDal.AddActivity(activity);

            return RedirectToAction("GetList");
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
                activityDal.EditActivity(activity);
                return RedirectToAction("GetList", new { id = activity.Id });
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
                return RedirectToAction("GetList", new { id = activity.Id });
            }
            else
            {
                return View("Error");
            }
        }
    }
}

