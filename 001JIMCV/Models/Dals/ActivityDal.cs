using _001JIMCV.Models.Classes;
using System.Collections.Generic;
using System.Linq;
using System;

namespace _001JIMCV.Models.Dals
{
    public class ActivityDal : IDisposable
    {
        private BDDContext _bddcontext;

        // Constructeur
        public ActivityDal()
        {
            _bddcontext = new BDDContext();
        }

        // Obtenir la liste des activités
        public List<Activity> GetAllActivities()
        {
            return _bddcontext.Activities.ToList();
        }

        // Ajouter une activité
        public int AddActivity(int ProviderId, string country, string city, string name, string description, DateAndTime date, string location, float price, byte[]image)
        {
            Activity activity = new Activity()
            {
                ProviderId = ProviderId,
                Pays = country,
                Ville = city,
                Nom = name,
                Description = description,
                Date = date,
                Localisation = location,
                Prix = price,
                Status= "En cours de traitement",
                Image=image
              
            };

            _bddcontext.Activities.Add(activity);
            _bddcontext.SaveChanges();

            return activity.Id;
        }

        // Ajouter une activité
      /*  public void AddActivity(Activity activity)
        {
            _bddcontext.Activities.Add(activity);
            _bddcontext.SaveChanges();
        }*/

        // Obtenir une activité par son ID
        public Activity GetActivityById(int id)
        {
            return _bddcontext.Activities.FirstOrDefault(a => a.Id == id);
        }

        // Modifier une activité
        public void EditActivity (int id, string country, string city, string name, string description, DateAndTime date, string location, float price, byte[] image, string status)
        {
            Activity activity = _bddcontext.Activities.Find(id);
            if (activity != null)
            {
                activity.Pays = country;
                activity.Ville = city;
                activity.Nom = name;
                activity.Description = description;
                activity.Date = date;
                activity.Localisation = location;
                activity.Prix = price;
                activity.Status = status;
                activity.Image = image;              
                _bddcontext.SaveChanges();
            }
        }

        // Modifier une activité
        public void EditActivity(Activity activity)
        {
            _bddcontext.Activities.Update(activity);
            _bddcontext.SaveChanges();
        }

        // Supprimer une activité par son ID
        public void DeleteActivity(int id)
        {
            Activity activity = _bddcontext.Activities.Find(id);
            if (activity != null)
            {
                _bddcontext.Activities.Remove(activity);
                _bddcontext.SaveChanges();
            }
        }

        // Supprimer une activité
        public void DeleteActivity(Activity activity)
        {
            _bddcontext.Activities.Remove(activity);
            _bddcontext.SaveChanges();
        }

        public void Dispose()
        {
            _bddcontext.Dispose();
        }
    }
}
