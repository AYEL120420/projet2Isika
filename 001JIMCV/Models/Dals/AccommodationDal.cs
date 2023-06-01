using _001JIMCV.Models.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DateAndTime = Microsoft.VisualBasic.DateAndTime;

namespace _001JIMCV.Models.Dals
{
    public class AccommodationDal : IDisposable
    {
        private BDDContext _bddcontext;
        //Constructeur
        public AccommodationDal()
        {
            _bddcontext = new BDDContext();
        }

        //Obtenir la liste des services
        public List<Accommodation> GetAllAccommodations()
        {
            return _bddcontext.Accommodations.ToList();
        }

        //Ajouter un service
        public int AddAccommodation(string country, string city, string type, string address, string from, string to, float price, string description)
        {
            Accommodation accommodation = new Accommodation()
            {
                Pays = country,
                Ville = city,
                Type = type,
                Adresse = address,
                De = from,
                A = to,
                Prix = price,
                Description = description,
             
            };

            _bddcontext.Accommodations.Add(accommodation);
            _bddcontext.SaveChanges();

            return accommodation.Id;
        }

        //Ajouter service 
        public void AddAccommodation(Accommodation accommodation)
        {
            _bddcontext.Accommodations.Add(accommodation);
            _bddcontext.SaveChanges();
        }

        //Obtenir service par Id
        public Accommodation GetAccommodationById(int id)
          {
              return _bddcontext.Accommodations.FirstOrDefault(s => s.Id == id);
          }

        //modifier un service
        public void EditAccommodation(int id, string country, string city, string type, string address, string from, string to, float price, string description, string status)
        {
            Accommodation accommodation = _bddcontext.Accommodations.Find(id);
            if (accommodation != null)
            {
                accommodation.Pays = country;
                accommodation.Ville = city;
                accommodation.Type = type;
                accommodation.Adresse = address;
                accommodation.De = from;
                accommodation.A = to;
                accommodation.Prix = price;
                accommodation.Description = description;
                accommodation.Status = status;
                _bddcontext.SaveChanges();
            }
           
        }


        public void EditAccommodation(Accommodation accommodation)
          {
              _bddcontext.Accommodations.Update(accommodation);
              _bddcontext.SaveChanges();
          }

          //Supprimer un service
          public void DeleteAccommodation(int id)
          {
              Accommodation accommodation = _bddcontext.Accommodations.Find(id);
             
          }
          public void DeleteAccommodation(Accommodation accommodation)
          {
              _bddcontext.Accommodations.Remove(accommodation);
              _bddcontext.SaveChanges();
          }
      
        public void Dispose()
        {
            _bddcontext.Dispose();
        }
      

    }
}
