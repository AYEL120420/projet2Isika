using _001JIMCV.Models.Classes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _001JIMCV.Models.Dals
{
    public class ReservationDal : IDisposable
    {
        private BDDContext _bddcontext;

        //Constructeur
        public ReservationDal()
        {
            _bddcontext = new BDDContext();
        }

        //Obtenir la liste des reservations
        public List<Reservation> GetAllReservations()
        {
            return _bddcontext.Reservations.ToList();
        }
        public void AddReservation(int ClientId, string travelStartDate, string travelEndDate, string contactName, string contactEmail, string contactPhone, float totalAmount)
        {
            Reservation reservation = new Reservation()
            {
                ClientId = ClientId,
                TravelStartDate = travelStartDate,
                TravelEndDate = travelEndDate,
                ContactName = contactName,
                ContactEmail = contactEmail,
                ContactPhone = contactPhone,              
                Price = totalAmount,
                Status = "En cours de traitement",
            };
            _bddcontext.Reservations.Add(reservation);
            _bddcontext.SaveChanges();

          
        }

        public Reservation GetReservationById(int id)
        {
            return _bddcontext.Reservations.FirstOrDefault(r => r.Id == id);
        }
        public void EditReservation(int id, int clientId, string status)
        {
            Reservation reservation = _bddcontext.Reservations.Find(id);

            if (reservation != null)
            {
                reservation.ClientId = clientId;
             //   reservation.TravelStartDate = travelStartDate;
               // reservation.TravelEndDate = travelEndDate;
                //reservation.ContactName = contactName;
                //reservation.ContactEmail = contactEmail;
                //reservation.ContactPhone = contactPhone;
                //reservation.Price = totalAmount;
                reservation.Status = status;

                _bddcontext.Reservations.Update(reservation);
                _bddcontext.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
