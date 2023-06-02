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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardDal()
        {
            _bddcontext = new BDDContext();
        }

        public DashboardDal(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Accommodation> GetPropositionAccommodation(int providerId)
        {
            List<Accommodation> providerAccommodations = _bddcontext.Accommodations
                .Where(p => p.ProviderId == providerId)  // Comparaison de l'ID 
                .ToList();
            return providerAccommodations;
        }


        public void Dispose()
        {
            _bddcontext.Dispose();
        }
    }
}
