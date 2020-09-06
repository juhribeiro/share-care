using System;

namespace ShareCare.Model.Models
{
    public class DoctorPatientModel: BaseModel
    {
        public Guid DoctorId { get; set; }

        public Guid PatientId { get; set; }
    }
}
