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
        public int AddAccommodation(string country, string city, string type, string address, string from, string to, float price, string description, byte[] image)
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
                Image = image
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
      /* public Service GetServiceById(int id)
        {
            return _bddcontext.Services.FirstOrDefault(s => s.Id == id);
        }

        //modifier un service
        public void EditService(int id, string Country, string City, DateAndTime Date, string Type, string Description, float Price)
        {
            Service service = _bddcontext.Services.Find(id);
            if (service != null)
            {
                Country = Country;
                City = City;
                Date = Date;
                service.Type = Type;
                service.Description = Description;
                service.Prix= Price;
                _bddcontext.SaveChanges();
            }
        }

        public void EditService(Service service)
        {
            _bddcontext.Services.Update(service);
            _bddcontext.SaveChanges();
        }

        //Supprimer un service
        public void DeleteService(int id)
        {
            Service service = _bddcontext.Services.Find(id);
            if (service != null)
            {
                service.Type = null;
                service.Description = null;
                _bddcontext.SaveChanges();

            }
        }
        public void DeleteService(Service service)
        {
            _bddcontext.Services.Remove(service);
            _bddcontext.SaveChanges();
        }
    */
        public void Dispose()
        {
            _bddcontext.Dispose();
        }
      

    }
}
