using _001JIMCV.Models.Classes;
using System;

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
        public void Dispose()
        {
            _bddcontext.Dispose();
        }
    }
}
