using ShareCare.Model.Enums;
using System;
using System.Collections.Generic;

namespace ShareCare.Model.DbModels
{
    public class Scheduler : BaseDbModel
    {
        public string Title { get; set; }

        public SchedulerType Type { get; set; }

        public string Description { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public string Specialty { get; set; }

        public Guid DoctorPatientId { get; set; }

        public DoctorPatient DoctorPatient { get; set; }

        public ICollection<Enchiridion> Enchiridions { get; set; }

        public string MeetAddressLink { get; set; }
    }
}
