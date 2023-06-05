namespace _001JIMCV.Models.Classes
{
    public class ServicePackServices
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int PackServicesId { get; set; }
        public PackServices PackServices { get; set; }  

    }
}
