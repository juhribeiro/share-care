using ShareCare.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShareCare.Model.Models
{
    public class SchedulerModel : BaseModel, IValidatableObject
    {
        [Required]
        public DoctorPatientModel DoctorPatient { get; set; }

        [Required]
        public string Title { get; set; }

        public SchedulerType Type { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }

        [Required]
        public string Specialty { get; set; }

        public List<string> Specialties { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (DateStart < DateTime.Now)
            {
                var members = new string[] { nameof(DateStart) }.ToList();
                var valid = new ValidationResult("A data de inicio precisa ser maior que a data atual", members);
                results.Add(valid);
            }

            if (DateStart > DateEnd)
            {
                var members = new string[] { nameof(DateEnd) }.ToList();
                var valid = new ValidationResult("A data de final precisa ser maior que a data inicial", members);
                results.Add(valid);
            }

            return results;
        }
    }
}
