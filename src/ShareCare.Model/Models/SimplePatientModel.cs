using System.Collections.Generic;
using System.Linq;

namespace ShareCare.Model.Models
{
    public class SimplePatientModel : SimplePersonModel
    {
        public List<string> Specialties { get; set; }

        public string Specialty => string.Join(", ", Specialties.Distinct());
    }
}
