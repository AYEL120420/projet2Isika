namespace _001JIMCV.Models.Classes
{
    public class ActivityPackServices
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int PackServicesId { get; set; }
        public PackServices PackServices { get; set; }
    }
}
