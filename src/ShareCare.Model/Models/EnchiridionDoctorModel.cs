using System;
using System.Collections.Generic;

namespace ShareCare.Model.Models
{
    public class EnchiridionDoctorModel : BaseModel
    {
        public string Name { get; set; }

        public string CRM { get; set; }

        public DateTime DataStart { get; set; }

        public string Specialty { get; set; }

        public List<EnchiridionModel> Enchiridion { get; set; }
    }
}
