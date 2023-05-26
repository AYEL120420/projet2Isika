using _001JIMCV.Models.Classes;
using System.Collections.Generic;
using System.Linq;
using System;

namespace _001JIMCV.Models
{
    public class Dal : IDisposable
    {
        // Attribut
        private BDDContext _bddcontext;

        //Constructeur
        public Dal()
        {
            _bddcontext = new BDDContext();
        }

        //méthode pour supprimer puis creer la base de donnée
        public void DeleteCreateDB()
        {
            _bddcontext.Database.EnsureDeleted();
            _bddcontext.Database.EnsureCreated();
        }
        //méthode pour obtenir la liste des hébergements
        public List<Accommodation> GetAllAccommodations()
        {
            return _bddcontext.Accommodations.ToList();
        }

        //méthode pour ajouter un henergement 
        public int CreateAccommodation(int Id, string type, string location, string arrivalDate, string deprtureDate, string description, string departureDate)
        {
            Accommodation accommodation = new Accommodation()
            {
                Id = Id,
                type = type,
                location = location,
                arrivalDate = arrivalDate,
                departureDate = deprtureDate,
                description = description
            };
            _bddcontext.Accommodations.Add(accommodation);
            _bddcontext.SaveChanges();
            return accommodation.Id;
        }
        public int CreateActivity()
        {
            Activity activity = new Activity();
            _bddcontext.Activities.Add(activity);
            _bddcontext.SaveChanges();
            return activity.Id;
        }

        public List<User> GetAllUsers()
        {
            return _bddcontext.Users.ToList();
        }

        public int CreateUser(int id, string name, string birthday, string email)
        {
            User client = new User() { };
            _bddcontext.Users.Add(client);
            _bddcontext.SaveChanges();

            return client.Id;
        }

        public void EditUser(int id, string name, string birthday, string email)
        {
            User client = _bddcontext.Users.Find(id);
            if (client != null)
            {
                client.Name = name;
                client.Email = email;
                _bddcontext.SaveChanges();
            }
        }

        public void EditClient(User client)
        {
            _bddcontext.Users.Update(client);
            _bddcontext.SaveChanges();
        }


        // méthode pour libérer les ressources utilisées par l'objet _bddcontext
        public void Dispose()
        {
            _bddcontext.Dispose();
        }


    }
}
