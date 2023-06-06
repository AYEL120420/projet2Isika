using _001JIMCV.Models.Classes;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _001JIMCV.Models.Dals
{
    public class PropositionDal : IDisposable
    {
        private BDDContext _bddcontext;

        // Constructeur
        public PropositionDal()
        {
            _bddcontext = new BDDContext();
        }

        // Obtenir la liste des autres propositions
        public List<OtherProposition> GetAllPropositions()
        {
            return _bddcontext.OtherPropositions.ToList();
        }

        // Ajouter une autre proposition
        public int AddProposition(int ProviderId,string providerName,string providerEmail,  string country, string city, string name, string disponibility,
            string description, string program, string accommodation, string activities, string restauration, float price, byte[] image)
        {
            OtherProposition proposition = new OtherProposition()
            {
                ProviderId=ProviderId,
                ProviderName=providerName,
                ProviderEmail=providerEmail,
                Country=country,
                City=city,
                Name=name,
                Disponibility=disponibility,
                Description=description,
                Program=program,
                Accommodation=accommodation,
                Activities=activities,
                Restauration=restauration,
                Price=price,
                Image = image,
                Status = "En Cours de traitement",
               
            };

            _bddcontext.OtherPropositions.Add(proposition);
            _bddcontext.SaveChanges();

            return proposition.Id;
        }


        // Obtenir une autre proposition par son ID
        public OtherProposition GetPropositionById(int id)
        {
            return _bddcontext.OtherPropositions.FirstOrDefault(p => p.Id == id);
        }

        // Modifier une autre proposition
        public void EditProposition(int id, string providerName, string providerEmail, string country, string city, string name, string disponibility, string description, 
            string program, string accommodation, string activities, string restauration, float price, byte[] image,string status)
        {
            OtherProposition proposition = _bddcontext.OtherPropositions.Find(id);
            if (proposition != null)
            {
                proposition.Id = id;
                proposition.ProviderName = providerName;
                proposition.ProviderEmail = providerEmail;
                proposition.Country = country;
                proposition.City = city;
                proposition.Name = name;
                proposition.Disponibility = disponibility;
                proposition.Description = description;
                proposition.Program = program;
                proposition.Accommodation = accommodation;
                proposition.Activities = activities;
                proposition.Restauration = restauration;
                proposition.Price = price;
                proposition.Image = image;
                proposition.Status = status;
               

                _bddcontext.OtherPropositions.Update(proposition);
                _bddcontext.SaveChanges();
            }
        }


        // Supprimer une autre proposition
        public void DeleteProposition(int id)
        {
            OtherProposition proposition = _bddcontext.OtherPropositions.Find(id);
            if (proposition != null)
            {
                _bddcontext.OtherPropositions.Remove(proposition);
                _bddcontext.SaveChanges();
            }
        }

        // Supprimer une autre proposition
        public void DeleteProposition(OtherProposition proposition)
        {
            _bddcontext.OtherPropositions.Remove(proposition);
            _bddcontext.SaveChanges();
        }

        public void Dispose()
        {
            _bddcontext.Dispose();
        }
    }
}

