using System;
using System.Collections.Generic;

namespace ShareCare.Model.DbModels
{
    public class DoctorPatient : BaseDbModel
    {
        public Guid DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public Guid PatientId { get; set; }

        public Patient Patient { get; set; }

        public ICollection<Scheduler> Schedulers { get; set; }
    }
}
