using System;
using System.ComponentModel.DataAnnotations;

namespace ShareCare.Model.Models
{
    public class DiaryModel : BaseModel
    {
        public Guid PatientId { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public DateTime DataAnnotation { get; set; }
    }
}
