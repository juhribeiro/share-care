using System;

namespace ShareCare.Model.DbModels
{
    public class Diary : BaseDbModel
    {
        public string Value { get; set; }

        public DateTime DataAnnotation { get; set; }

        public Guid PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
