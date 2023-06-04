using _001JIMCV.Models.Classes.Enum;
using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Dals;
using _001JIMCV.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _001JIMCV.Controllers
{
    public class ReservationController : Controller
    {
        ReservationDal reservationDal;
        LoginDal loginDal ;

        public ReservationController()
        {
            reservationDal = new ReservationDal();
            loginDal = new LoginDal();  
        }
        public IActionResult Index()
        {
            return View("FormReservation");
        }
        private decimal CalculateTotalAmount(int numberOfPassengers)
        {
            // Effectuez les calculs appropriés pour déterminer le montant en fonction du nombre de passagers
            decimal amount = numberOfPassengers ; 
            return amount;
        }
     
        public IActionResult GetReservationsList()
        {

            var reservations = reservationDal.GetAllReservations();
            ViewData["Reservations"] = reservations ?? new List<_001JIMCV.Models.Classes.Reservation>();
            return View("List");

        }
        public ActionResult GetReservations()

        {

            LoginViewModel viewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentified)
            {
                viewModel.User = loginDal.GetUser(HttpContext.User.Identity.Name);
                UserEnum role = viewModel.User.Role;
                switch (role)
                {
                    case UserEnum.Admin:
                        return RedirectToAction("GetReservationsList");
                    case UserEnum.Customer:
                       
                        var reservations = reservationDal.GetAllReservations()
                            .Where(p => p.ClientId == viewModel.User.Id).ToList();
                        ViewData["Reservations"] = reservations ?? new List<_001JIMCV.Models.Classes.Reservation>();
  
                        return View("ConfirmationPayement");
                    default:

                        return View("Error");
                }
            }

            return View();

        }
        public ActionResult GetClientReservation()
        {
            LoginViewModel viewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentified)
            {
                viewModel.User = loginDal.GetUser(HttpContext.User.Identity.Name);
                UserEnum role = viewModel.User.Role;

                if (role == UserEnum.Customer)
                {
                    var reservations = reservationDal.GetAllReservations()
                        .Where(p => p.ClientId == viewModel.User.Id)
                        .ToList();

                    ViewData["Reservations"] = reservations ?? new List<_001JIMCV.Models.Classes.Reservation>();
                }
            }

            return View("List");
        }


        [HttpPost]
        public IActionResult AddReservation (Reservation reservation)
        {
            LoginViewModel viewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
            viewModel.User = loginDal.GetUser(HttpContext.User.Identity.Name);
            UserEnum role = viewModel.User.Role;

            reservationDal.AddReservation(viewModel.User.Id, reservation.TravelStartDate, reservation.TravelEndDate, reservation.ContactName, reservation.ContactEmail, reservation.ContactPhone,
                reservation.NumberOfPassengers, reservation.TotalAmount);

            return RedirectToAction("GetReservations");
        }
    }
}
