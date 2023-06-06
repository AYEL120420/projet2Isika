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
        public int AddAccommodation(int ProviderId, string providerName, string providerEmail, string country, string city, string type, string name, string address, string from, string to, float price, 
            string description, byte[]image)
        {
            Accommodation accommodation = new Accommodation()
            {   
                ProviderId = ProviderId,
                ProviderName = providerName,
                ProviderEmail = providerEmail,
                Country = country,
                City = city,
                Type = type,
                Name= name,
                Adress = address,
                StartDate = from,
                EndDate = to,
                Price = price,
                Description = description,
                Image=image,
                Status = "En Cours de traitement"
            };

            _bddcontext.Accommodations.Add(accommodation);
            _bddcontext.SaveChanges();

            return accommodation.Id;
        }

        //Obtenir service par Id
        public Accommodation GetAccommodationById(int id)
          {
              return _bddcontext.Accommodations.FirstOrDefault(s => s.Id == id);
          }

        //modifier un service
        public void EditAccommodation(int id,string country, string city, string type,string name, string address, string from, string to, float price, string description, string status, byte[] image)
        {
            Accommodation accommodation = _bddcontext.Accommodations.Find(id);
            if (accommodation != null)
            {
                accommodation.Id = id;
                accommodation.Country = country;
                accommodation.City = city;
                accommodation.Type = type;
                accommodation.Name = name;
                accommodation.Adress = address;
                accommodation.StartDate = from;
                accommodation.EndDate = to;
                accommodation.Price = price;
                accommodation.Description = description;
                accommodation.Status = status;
                accommodation.Image = image;
                _bddcontext.SaveChanges();
            }
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
