namespace _001JIMCV.Models.Classes.Users
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public Admin admin { get; set; }
        public Client client { get; set; }
        public Provider Providers { get; set; }
    }
}
