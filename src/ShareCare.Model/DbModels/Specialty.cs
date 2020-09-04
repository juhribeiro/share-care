using System;

namespace ShareCare.Model.DbModels
{
    public class Specialty : BaseDbModel
    {
        public string Value { get; set; }

        public Guid DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public Scheduler Scheduler { get; set; }
    }
}
