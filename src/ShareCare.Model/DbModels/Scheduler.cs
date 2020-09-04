using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShareCare.Model.DbModels
{
    public class Scheduler : BaseDbModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public Guid SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        public Guid DoctorPatientId { get; set; }

        public DoctorPatient DoctorPatient { get; set; }

        public ICollection<Enchiridion> Enchiridions { get; set; }
    }
}
