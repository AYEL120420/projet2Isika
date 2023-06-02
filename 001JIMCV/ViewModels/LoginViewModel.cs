using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;
using Microsoft.AspNet.Identity;

namespace _001JIMCV.ViewModels
{
    public class LoginViewModel
    {
        public User User { get; set; }
        public bool Authentified { get; set; }
        public UserEnum Role { get; set; }
       
    }
}
