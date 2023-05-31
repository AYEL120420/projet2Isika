using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;

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

        public int AddJourney(string depDate, string returnDate, string country)
        {
            
            Journey journey = new Journey() { DepartureDate = depDate, ReturnDate = returnDate, CountryDestination = country };
            this._bddContext.Journeys.Add(journey);
            this._bddContext.SaveChanges();
            return journey.Id;
        }
    }
}
