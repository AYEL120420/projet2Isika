using _001JIMCV.Models.Classes;
using _001JIMCV.Models.Classes.Enum;

namespace _001JIMCV.ViewModels
{
    public class LoginViewModel
    {
        public User User { get; set; }
        public bool Authentified { get; set; }

        public UserEnum UserEnum { get; set; }
    }
}
