using _001JIMCV.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public int AddProposition(int ProviderId, string pays, string ville, string titre, string disponibilite, string description, string programme, string hebergement, string activites, string restauration, float prix)
        {
            OtherProposition proposition = new OtherProposition()
            {
                ProviderId=ProviderId,
                Pays = pays,
                Ville = ville,
                Titre = titre,
                Description = description,
                Disponibilite = disponibilite,
                Programme = programme,
                Hebergement = hebergement,
                Activites = activites,
                Restauration = restauration,
                Prix = prix,
                Status = "En Cours de traitement"
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
        public void EditProposition(int id, string pays, string ville, string titre, string disponibilite, string description, string programme, string hebergement, string activites, string restauration, float prix,  string status)
        {
            OtherProposition proposition = _bddcontext.OtherPropositions.Find(id);
            if (proposition != null)
            {
                proposition.Id = id;
                proposition.Pays = pays;
                proposition.Ville = ville;
                proposition.Titre = titre;
                proposition.Description = description;
                proposition.Disponibilite = disponibilite;
                proposition.Programme = programme;
                proposition.Hebergement = hebergement;
                proposition.Activites = activites;
                proposition.Restauration = restauration;
                proposition.Prix = prix;
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

