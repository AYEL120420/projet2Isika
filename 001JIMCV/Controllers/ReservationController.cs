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
        LoginDal loginDal;

        public ReservationController()
        {
            reservationDal = new ReservationDal();
            loginDal = new LoginDal();
        }
        public IActionResult Index()
        {
            return View("FormReservation");
        }
        public IActionResult ReservationForm()
        {
            JourneyViewModel jvm = new JourneyViewModel();

            ///Récupérez les informations du voyage la bdd
          //Journey journey = GetJourneyRecap();

          //jvm.Journey = journey;

            return View(jvm);

        }
        private decimal CalculateTotalAmount(int numberOfPassengers)
        {
            // Effectuez les calculs appropriés pour déterminer le montant en fonction du nombre de passagers
            decimal amount = numberOfPassengers;
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
        public IActionResult AddReservation(Reservation reservation)
        {
            LoginViewModel viewModel = new LoginViewModel { Authentified = HttpContext.User.Identity.IsAuthenticated };
            viewModel.User = loginDal.GetUser(HttpContext.User.Identity.Name);
            UserEnum role = viewModel.User.Role;

            reservationDal.AddReservation(viewModel.User.Id, reservation.TravelStartDate, reservation.TravelEndDate, reservation.ContactName, reservation.ContactEmail, reservation.ContactPhone,
                reservation.NumberOfPassengers, reservation.TotalAmount);

            return RedirectToAction("GetReservations");
        }

        [HttpGet]
        public IActionResult EditReservation(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Reservation reservation = reservationDal.GetReservationById(id);

            if (reservation == null)
            {
                return View("Error");
            }

            return View("EditReservationForm", reservation);
        }


        [HttpPost]
        public IActionResult EditReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
                return View(reservation);

            if (reservation.Id != 0)
            {
                reservationDal.EditReservation(reservation.Id, reservation.TravelStartDate, reservation.TravelEndDate, reservation.ContactName, reservation.ContactEmail, reservation.ContactPhone,
                    reservation.NumberOfPassengers, reservation.TotalAmount, reservation.Status);

                return RedirectToAction("GetReservations", new { id = reservation.Id });
            }
            else
            {
                return View("Error");
            }
        }
    }
}