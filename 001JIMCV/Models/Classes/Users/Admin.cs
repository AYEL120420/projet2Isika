using System.ComponentModel.DataAnnotations;

namespace _001JIMCV.Models.Classes.Users
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "L'e-mail est requis.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Veuillez saisir une adresse e-mail valide.")]
        public string Email { get; set; }

    }
}
