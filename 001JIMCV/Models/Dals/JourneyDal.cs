using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Runtime.InteropServices;

namespace _001JIMCV.Models.Dals
{
    public class JourneyDal
    {
        private BDDContext _bddContext;
        //Constructeur
        public JourneyDal()
        {
            _bddContext = new BDDContext();
        }
        public List<Journey> GetAllJourneys()
        {
            return _bddContext.Journeys.ToList();
        }
        public List<Flight> GetAllFLights()
        {
            return _bddContext.Flights.ToList();
        }
        public List<Accommodation> GetAllAccommodations()
        {
            return _bddContext.Accommodations.ToList();
        }
        public List<Activity> GetAllActivities()
        {
            return _bddContext.Activities.ToList();
        }
        public List<Restauration> GetAllRestaurations()
        {
            return _bddContext.Restaurations.ToList();
        }
        public List<PackServices> GetAllPacks()
        {
            return _bddContext.PackService.ToList();
        }
        public FlightPackServices GetFLightPackServices(int id)
        {
            return _bddContext.FlightPackServices.FirstOrDefault(r => r.PackServicesId == id);
        }
        public List<AccommodationPackServices> GetAllAccommodationsPackServices()
        {
            return _bddContext.AccommodationPackServices.ToList();
        }
        public List<ActivityPackServices> GetAllActivityPackServices()
        {
            return _bddContext.ActivityPackServices.ToList();
        }
        public List<RestaurationPackServices> GetAllRestaurationPackServices()
        {
            return _bddContext.RestaurationPackServices.ToList();
        }
        public Journey GetJourney(int id)
        {
            return _bddContext.Journeys.FirstOrDefault(r => r.Id == id);
        }
        public PackServices GetPackServices(int id)
        {
            return _bddContext.PackService.FirstOrDefault(r => r.Id == id);
        }
        public Flight GetFlight(int id)
        {
            return _bddContext.Flights.FirstOrDefault(r => r.Id == id);
        }
        public Accommodation GetAccommodation(int id)
        {
            return _bddContext.Accommodations.FirstOrDefault(r => r.Id == id);
        }
        public Activity GetActivity(int id)
        {
            return _bddContext.Activities.FirstOrDefault(r => r.Id == id);
        }
        public Restauration GetRestauration(int id)
        {
            return _bddContext.Restaurations.FirstOrDefault(r => r.Id == id);
        }
        public int AddJourney(string depDate, string returnDate, string country, string city, string departCity, float price, string description, string imagePath)
        {

            Journey journey = new Journey() { DepartureDate = depDate, ReturnDate = returnDate, CountryDestination = country, CityDestination = city, DepartureCity = departCity, Price = price, Description = description, ImagePath = imagePath };
            this._bddContext.Journeys.Add(journey);
            this._bddContext.SaveChanges();
            return journey.Id;
        }


        public int AddPackServices(int journeyId, int userId)
        {
            PackServices pack = new PackServices() { JourneyId = journeyId, UserId = userId };
            this._bddContext.PackService.Add(pack);
            this._bddContext.SaveChanges();
            return pack.Id;
        }
        public int AddPackServicesAllInclusive(int journeyId, int userId)
        {
            PackServices pack = new PackServices() { JourneyId = journeyId, UserId = userId, AllInclusive = true };
            this._bddContext.PackService.Add(pack);
            this._bddContext.SaveChanges();
            return pack.Id;
        }

        public void AddFlightPackServices(int depFlightId, int returnFlightId, int packServiceId)
        {
            FlightPackServices pack = new FlightPackServices() { DepartureFlightId = depFlightId, ReturnFlightId = returnFlightId, PackServicesId = packServiceId };
            this._bddContext.FlightPackServices.Add(pack);
            this._bddContext.SaveChanges();
        }

        public void AddAccommodationPackServices(int accommodationId, int packServiceId)
        {
            AccommodationPackServices AccommodationPackServices = new AccommodationPackServices() { AccommodationId = accommodationId, PackServicesId = packServiceId };
            this._bddContext.AccommodationPackServices.Add(AccommodationPackServices);
            this._bddContext.SaveChanges();
        }

        public void AddActivityPackServices(int activityId, int packServiceId)
        {
            ActivityPackServices ActivityPackServices = new ActivityPackServices() { ActivityId = activityId, PackServicesId = packServiceId };
            this._bddContext.ActivityPackServices.Add(ActivityPackServices);
            this._bddContext.SaveChanges();
        }
        public void AddRestaurationPackServices(int activityId, int packServiceId)
        {
            RestaurationPackServices RestaurationPackServices = new RestaurationPackServices() { RestaurationId = activityId, PackServicesId = packServiceId };
            this._bddContext.RestaurationPackServices.Add(RestaurationPackServices);
            this._bddContext.SaveChanges();
        }

        public float GetAccommodationPrice(int accommodationId)
        {

            Accommodation accommodation = _bddContext.Accommodations.Find(accommodationId);
            if (accommodation != null)
            {
                return accommodation.Price; 
            }

            return 0;
        }

       public float GetActivityPrice(int idActivity)
        {
            Activity activity = _bddContext.Activities.Find(idActivity);
            if (activity != null)
            {
                return activity.Price;
            }

            return 0;
        }
        public float GetRestaurationPrice(int idRestauration)
        {
            Restauration restauration = _bddContext.Restaurations.Find(idRestauration);
            if (restauration != null)
            {
                return restauration.Price;
            }

            return 0;
        }
        public float GetFlightPrice(int idFlight)
        {
            Flight flight = _bddContext.Flights.Find(idFlight);
            if (flight != null)
            {
                return flight.Price;
            }

            return 0;
        }
        public void UpdatePricePackService(int IdPackService, float  pricePack)
        {
            PackServices packServices =_bddContext.PackService.Find(IdPackService);
            if 
                (packServices != null)
                {
                packServices.Total_price = pricePack;
                this._bddContext.SaveChanges(); 
                }
            
        }
        public void DeleteJourney(int id)
        {
            Journey journey = _bddContext.Journeys.Find(id);

        }
        public void DeleteJourney(Journey journey)
        {
            _bddContext.Journeys.Remove(journey);
            _bddContext.SaveChanges();
        }
    }
}
