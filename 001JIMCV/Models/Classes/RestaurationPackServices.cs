namespace _001JIMCV.Models.Classes
{
    public class RestaurationPackServices
    {
        public int Id { get; set; }
        public int RestaurationId { get; set; }
        public Restauration Restauration { get; set; }

        public int PackServicesId { get; set; }
        public PackServices PackServices { get; set; }
    }
}
