using _001JIMCV.Models.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _001JIMCV.Models.Dals
{
    public class ServiceDal : IDisposable
    {
        private BDDContext _bddcontext;
        //Constructeur
        public ServiceDal()
        {
            _bddcontext = new BDDContext();
        }
        public List<Service> GetAllServices()
        {
            return _bddcontext.Services.ToList();
        }

        public int AddService(string Type, string Description, float Price)
        {
            Service service = new Service()
            {
                Type = Type,
                Description = Description,
                Price = Price,

            };
            _bddcontext.Services.Add(service);
            _bddcontext.SaveChanges();
            return service.Id;
        }
        public void AddService(Service service)
        {
            _bddcontext.Services.Add(service);
            _bddcontext.SaveChanges();
        }

        public Service GetServiceById(int id)
        {
            return _bddcontext.Services.FirstOrDefault(s => s.Id == id);
        }

        public void EditService(int id, string type, string description, float price)
        {
            Service service = _bddcontext.Services.Find(id);
            if (service != null)
            {
                service.Type = type;
                service.Description = description;
                service.Price = price;
                _bddcontext.SaveChanges();
            }
        }
        public void EditService(Service service)
        {
            _bddcontext.Services.Update(service);
            _bddcontext.SaveChanges();
        }
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

        public void Dispose()
        {
            _bddcontext.Dispose();
        }


    }
}
