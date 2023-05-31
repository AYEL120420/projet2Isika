using _001JIMCV.Models.Classes;
using System;

namespace _001JIMCV.Models.Dals
{
    public class PropositionDal : IDisposable
    {
        private BDDContext _bddcontext;
        //Constructeur
        public PropositionDal()
        {
            _bddcontext = new BDDContext();
        }

        public int AddService(string Country, string City, DateAndTime Date, string Type, float Price)
        {
            Service service = new Service()
            {
                Pays = Country,
                Ville = City,
                Date = Date,
                Type = Type,
                Prix = Price,

            };
            _bddcontext.Services.Add(service);
            _bddcontext.SaveChanges();
            return service.Id;
        }
        //Ajouter service 
        public void AddService(Service service)
        {
            _bddcontext.Services.Add(service);
            _bddcontext.SaveChanges();
        }

     
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
