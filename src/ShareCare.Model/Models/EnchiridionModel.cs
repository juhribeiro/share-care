using ShareCare.Model.Enums;
using System;

namespace ShareCare.Model.Models
{
    public class EnchiridionModel : BaseModel
    {
        public string Value { get; set; }

        public EnchiridionType Type { get; set; }

        public DateTime Date { get; set; }

        public string Specialty { get; set; }
    }
}
