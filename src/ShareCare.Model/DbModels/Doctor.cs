using System.Collections.Generic;

namespace ShareCare.Model.DbModels
{
    public class Doctor : Person
    {
        public string CRM { get; set; }

        public ICollection<DoctorPatient> DoctorPatients { get; set; }

        public ICollection<Specialty> Specialties { get; set; }
    }
}
