using _001JIMCV.Models.Classes.Users;
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
        public void InitializeDB()
        {
            _bddcontext.Database.EnsureDeleted();
            _bddcontext.Database.EnsureCreated();
            Client client = new Client() { Name = "Anthony Dumas", Birthday = "11/05/1994", Email = "anthony.dumas@gmail.com" };
            Client client1 = new Client() { Name = "Rudiger Hasselberg", Birthday = "26/07/2000", Email = "miaourudiger@gmail.com" };
            Client client2 = new Client() { Name = "Thomas Salmon", Birthday = "14/09/1999", Email = "thomas.salmon@gmail.com" };
            _bddcontext.Clients.AddRange(client1, client, client2);

            _bddcontext.SaveChanges();
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

        public List<Client> GetAllClient()
        {
            return _bddcontext.Clients.ToList();
        }

        public int CreateClient(int id, string name, string birthday, string email)
        {
            Client client = new Client() { };
            _bddcontext.Clients.Add(client);
            _bddcontext.SaveChanges();

            return client.Id;
        }

        public void EditClient(int id, string name, string birthday, string email)
        {
            Client client = _bddcontext.Clients.Find(id);
            if (client != null)
            {
                client.Name = name;
                client.Birthday = birthday;
                client.Email = email;
                _bddcontext.SaveChanges();
            }
        }

        public void EditClient(Client client)
        {
            _bddcontext.Clients.Update(client);
            _bddcontext.SaveChanges();
        }


        // méthode pour libérer les ressources utilisées par l'objet _bddcontext
        public void Dispose()
        {
            _bddcontext.Dispose();
        }


    }
}
