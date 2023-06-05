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
       

        public DashboardDal()
        {
            _bddcontext = new BDDContext();
        }

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
            }
            _bddcontext.Users.Update(user);
            _bddcontext.SaveChanges();
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
