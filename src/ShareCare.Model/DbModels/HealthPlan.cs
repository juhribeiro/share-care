using System;

namespace ShareCare.Model.DbModels
{
    public class HealthPlan : BaseDbModel
    {
        public string Code { get; set; }

        public DateTime ShelfLife { get; set; }

        public Guid PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
