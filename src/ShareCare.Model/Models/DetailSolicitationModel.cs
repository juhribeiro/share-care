using System;

namespace ShareCare.Model.Models
{
    public class DetailSolicitationModel : BaseModel
    {
        public DateTime DateStart { get; set; }

        public Guid PatientId { get; set; }

        public string PatientName { get; set; }

        public string Specialty { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DayOfWeek => DateStart.DayOfWeek.ToString();

        public string MeetAddressLink { get; set; }

        public string TypeSolicitation => "Iremos enviar essa solicitação ao cliente";

        public string SimpleName => PatientName.Split(" ")[0];
    }
}
