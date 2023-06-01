using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class DashboardProviderController : Controller
{
    private DashboardDal dashboardDal;

    public DashboardProviderController()
    {
        dashboardDal = new DashboardDal();
    }

    public ActionResult Index()
    {
        string provider = User.Identity.GetUserId(); // Obtenir l'ID du partenaire connecté
        int providerId = int.Parse(provider); // Convertir la chaîne en int

        List<Accommodation> propositionHebergement = dashboardDal.PropositionAccommodation(providerId)
            .Where(p => p.Id == providerId)
            .ToList();

        return View(propositionHebergement);
    }
}
