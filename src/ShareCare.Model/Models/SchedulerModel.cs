using System;

namespace ShareCare.Model.Models
{
    public class SchedulerModel : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public string Specialty { get; set; }
    }
}
