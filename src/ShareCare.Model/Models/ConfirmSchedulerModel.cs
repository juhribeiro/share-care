using System;

namespace ShareCare.Model.Models
{
    public class ConfirmSchedulerModel : BaseModel
    {
        public DateTime DateStart { get; set; }

        public string DoctorName { get; set; }

        public string Specialty { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DayOfWeek => DateStart.DayOfWeek.ToString();

        public string MeetAddressLink { get; set; }
    }
}
