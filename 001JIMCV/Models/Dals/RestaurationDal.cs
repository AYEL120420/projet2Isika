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
    public class RestaurationDal : IDisposable
    {
        private BDDContext _bddcontext;

        // Constructeur
        public RestaurationDal()
        {
            _bddcontext = new BDDContext();
        }

        // Obtenir la liste des restaurations
        public List<Restauration> GetAllRestaurations()
        {
            return _bddcontext.Restaurations.ToList();
        }

        // Ajouter une restauration
        public int AddRestauration(int providerId, string providerName, string Email, string country, string city, string type, string description, string adress, string menu, float price, byte[] image)
        {
            Restauration restauration = new Restauration()
            {
                ProviderId = providerId,
                ProviderName = providerName,
                ProviderEmail = Email,
                Country = country,
                City = city,
                Type = type,
                Description = description,
                Adress = adress,
                Menu = menu,
                Price = price,
                Images=image,
                Status = "En cours de traitement"
            };

            _bddcontext.Restaurations.Add(restauration);
            _bddcontext.SaveChanges();

            return restauration.Id;
        }

        // Obtenir une restauration par son ID
        public Restauration GetRestaurationById(int id)
        {
            return _bddcontext.Restaurations.FirstOrDefault(r => r.Id == id);
        }

        // Modifier une restauration
        public void EditRestauration(int id, string providerName, string Email, string country, string city, string type, string description, string adress, string menu, float price, string status, byte[] image)
        {
            Restauration restauration = _bddcontext.Restaurations.Find(id);
            if (restauration != null)
            {
                restauration.Id = id;
                restauration.ProviderName = providerName;
                restauration.ProviderEmail = Email;
                restauration.Country = country;
                restauration.City = city;
                restauration.Type = type;
                restauration.Description = description;
                restauration.Adress = adress;
                restauration.Menu = menu;
                restauration.Price = price;
                restauration.Status = status;
                restauration.Images = image;
            };
            _bddcontext.Restaurations.Remove(restauration);
            _bddcontext.SaveChanges();
        }

        // Supprimer une restauration
        public void DeleteRestauration(int id)
        {
            Restauration restauration = _bddcontext.Restaurations.Find(id);
            if (restauration != null)
            {
                _bddcontext.Restaurations.Remove(restauration);
                _bddcontext.SaveChanges();
            }
        }

        // Supprimer une restauration
        public void DeleteRestauration(Restauration restauration)
        {
            _bddcontext.Restaurations.Remove(restauration);
            _bddcontext.SaveChanges();
        }

        public void Dispose()
        {
            _bddcontext.Dispose();
        }
    }
}
