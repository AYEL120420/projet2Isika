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






       /* public string GetUserId()
        {
            // Récupérer l'ID de l'utilisateur connecté
            string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return userId;
        }*/

        public List<Accommodation> GetPropositionAccommodation(int providerId)
        {
            List<Accommodation> propositionsProvider = _bddcontext.Accommodations
                .Where(p => p.Id == providerId)
                .ToList();
            return propositionsProvider;
        }

        public void Dispose()
        {
            _bddcontext.Dispose();
        }
    }
}
