using System;

namespace ShareCare.Model.Models
{
    public class DetailSchedulerModel : BaseModel
    {
        public Guid DoctorId { get; set; }

        public DateTime DateStart { get; set; }

        public string DoctorName { get; set; }

        public string Specialty { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DayOfWeek => DateStart.DayOfWeek.ToString();

        public string MeetAddressLink { get; set; }

        public string SimpleName => DoctorName.Split(" ")[0];
    }
}
