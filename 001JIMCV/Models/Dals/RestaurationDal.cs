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
        public int AddRestauration(int providerId,string country, string city, string type, string description, string location, string menu, decimal price, string Email)
        {
            Restauration restauration = new Restauration()
            {
                ProviderId=providerId,
                Pays = country,
                Ville = city,
                Type = type,
                Description = description,
                Localisation = location,
                Menu = menu,
                Tarif = price,
                Email = Email,
                Status ="En cours de traitement"
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
        public void EditRestauration(int id, string country, string city, string type, string description, string location, string menu, decimal price, string Email, string status)
        {
            Restauration restauration = _bddcontext.Restaurations.Find(id);
            if (restauration != null)
            {
                restauration.Id = id;
                restauration.Pays = country;
                restauration.Ville = city;
                restauration.Type = type;
                restauration.Description = description;
                restauration.Localisation = location;
                restauration.Menu = menu;
                restauration.Tarif = price;
                restauration.Email = Email;
                restauration.Status = status;
                _bddcontext.SaveChanges();
            }
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
