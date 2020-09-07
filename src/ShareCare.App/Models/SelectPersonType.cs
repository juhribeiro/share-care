using ShareCare.Model.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShareCare.App.Models
{
    public class SelectPersonType : IValidatableObject
    {
        [Required]
        public PersonType Type { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (!string.IsNullOrEmpty(Email))
            {
                if (string.IsNullOrEmpty(Password))
                {
                    results.Add(new ValidationResult("A senha é obrigatória", new string[] { nameof(Password) }.ToList()));
                }

                if (string.IsNullOrEmpty(Name))
                {
                    results.Add(new ValidationResult("O Nome é obrigatório", new string[] { nameof(Name) }.ToList()));
                }
            }

            return results;
        }
    }
}
