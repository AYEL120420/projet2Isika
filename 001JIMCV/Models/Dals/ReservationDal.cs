using _001JIMCV.Models.Classes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public int AddReservation(int ClientId, DateTime travelStartDate, DateTime travelEndDate, string contactName, string contactEmail, string contactPhone, int numberOfPassengers,float totalAmount)
        { 
            Reservation reservation = new Reservation();
            {  
                reservation.ClientId = ClientId;
                reservation.TravelStartDate = travelStartDate;
                reservation.TravelEndDate = travelEndDate;
                reservation.ContactName = contactName;
                reservation.ContactEmail = contactEmail;
                reservation.ContactPhone = contactPhone;
                reservation.NumberOfPassengers = numberOfPassengers;
                reservation.TotalAmount = totalAmount;
                reservation.Status = "En cours de traitement";
            }
            _bddcontext.Reservations.Add(reservation);
            _bddcontext.SaveChanges();

            return reservation.Id;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
