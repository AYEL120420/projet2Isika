using _001JIMCV.Models.Classes.Enum;
using System.ComponentModel.DataAnnotations;

namespace _001JIMCV.Models.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "L'e-mail est requis.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Veuillez saisir une adresse e-mail valide.")]
        public string Email { get; set; }
        public string Password { get; set; }
        public UserEnum Role { get; set; }
    }
}
