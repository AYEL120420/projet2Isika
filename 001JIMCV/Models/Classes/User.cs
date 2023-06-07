using _001JIMCV.Models.Classes.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _001JIMCV.Models.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "L'e-mail est requis.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Veuillez saisir une adresse e-mail valide.")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        public string Password { get; set; }
        public UserEnum Role { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}