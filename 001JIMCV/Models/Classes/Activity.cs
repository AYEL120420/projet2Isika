namespace _001JIMCV.Models.Classes
{
    public class Activity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
