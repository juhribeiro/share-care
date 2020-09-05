using System.Collections.Generic;

namespace ShareCare.Model.Models
{
    public class SimpleDoctorModel : SimplePersonModel
    {
        public string CRM { get; set; }

        public string Description { get; set; }

        public ICollection<string> Specialties { get; set; }

    }
}
