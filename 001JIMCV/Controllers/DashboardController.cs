//<<<<<<< HEAD
//﻿using Microsoft.AspNetCore.Mvc;

//namespace _001JIMCV.Controllers
//{
//    public class DashboardController : Controller
//    {
//        public IActionResult Admin()
//        {
//            return View("AdminDashboard");
//        }

//        public IActionResult Provider()
//        {
//            return View("ProviderDashboard");
//        }

//        public IActionResult Client()
//        {
//            return View("ClientDashboard");
//        }
//    }
//}

﻿using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;
using _001JIMCV.Models.Dals;
using _001JIMCV.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using XAct.Users;

public class DashboardController : Controller
{
    private DashboardDal dashboardDal;
    private LoginDal loginDal;

    public DashboardController()
    {
        dashboardDal = new DashboardDal();
        loginDal = new LoginDal();
    }

    public ActionResult Index()
    {
        LoginViewModel viewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
        if (viewModel.Authentified)
        {
            viewModel.User = loginDal.GetUser(HttpContext.User.Identity.Name);
            UserEnum role = viewModel.User.Role; // Accéder au rôle de l'utilisateur

            switch (role)
            {
                case UserEnum.Admin:
                    // administrateur
                    return View("AdminDashboard", viewModel);
                case UserEnum.Customer:
                    //  client
                    return View("ClientDashboard", viewModel);
                case UserEnum.Provider:
                    //  partenaire
                   List<Accommodation> providerPropositions = dashboardDal.GetPropositionAccommodation(viewModel.User.Id);
                return View("ProviderDashboard", providerPropositions);
                default:
                    // Rôle non reconnu
                    return View("Error");
            }
        }

        return View(viewModel);
    }

}

