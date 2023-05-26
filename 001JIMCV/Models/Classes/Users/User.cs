namespace _001JIMCV.Models.Classes.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Admin admin { get; set; }
        public Client client { get; set; }
        public Provider Providers { get; set; }
    }
}
