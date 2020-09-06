using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShareCare.Model.Models
{
    public class SimpleDoctorModel : SimplePersonModel, IValidatableObject
    {
        [Required]
        public string CRM { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Specialties { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (!Specialties.Any() || string.IsNullOrEmpty(Specialties.First()))
            {
                var members = new string[] { nameof(Specialties) }.ToList();
                var valid = new ValidationResult("Selecione ao menos uma especialidade", members);
                results.Add(valid);
            }

            return results;
        }
    }
}
