using _001JIMCV.Models.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace _001JIMCV.Models.Dals
{
    public class DashboardDal : IDisposable
    {
        private BDDContext _bddcontext;

        //Constructeur initialise un nouvel objet BDDContext qui est le contexte de la base de données.
        public DashboardDal()
        {
            _bddcontext = new BDDContext();
        }
        //Methode pour recuperer un utilisateur à partir de la BDD en recherchant le premier utilisateur dont l'ID correspond à l'ID recherché
        public User GetUser(int id)

        {
            return _bddcontext.Users.FirstOrDefault(s => s.Id == id);
        }

        //Methode pour modifier le profil d'un utilisateur 
        public void EditProfil(int id, string name, string email, string phone, string gender, string country, string city)
        {
            User user = _bddcontext.Users.Find(id);
            if (user != null)
            {
                user.Id = id;
                user.Name = name;
                user.Email = email;
                user.Phone = phone;
                user.Gender = gender;
                user.Country = country;
                user.City = city;

                _bddcontext.Users.Update(user); // Mettre à jour user dans le contexte
                _bddcontext.SaveChanges(); // Enregistrer les modifications dans la BDD
            }
        }

        public void EditProfil(User user)
        {
            _bddcontext.Users.Update(user);
            _bddcontext.SaveChanges();
        }
            public void Dispose()
        {
            _bddcontext.Dispose();
        }
    }
}
