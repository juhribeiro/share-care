using ShareCare.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShareCare.Model.Models
{
    public class LoginModel
    {
        public PersonType Type { get; set; }

        public string Name { get; set; }

        [Required]
        [EmailAddress]
        // todo remover quando tiver o google
        public string Email { get; set; }

        public string Token { get; set; }

        public string Password { get; set; }
    }
}
