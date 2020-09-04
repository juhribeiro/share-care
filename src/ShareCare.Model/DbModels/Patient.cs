using System.Collections.Generic;

namespace ShareCare.Model.DbModels
{
    public class Patient : Person
    {
        public HealthPlan HealthPlan { get; set; }

        public ICollection<DoctorPatient> DoctorPatients { get; set; }

        public ICollection<Diary> Diaries { get; set; }
    }
}
