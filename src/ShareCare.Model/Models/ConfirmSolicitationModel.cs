using System;

namespace ShareCare.Model.Models
{
    public class ConfirmSolicitationModel : BaseModel
    {
        public DateTime DateStart { get; set; }

        public string PatientName { get; set; }

        public string Specialty { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DayOfWeek => DateStart.DayOfWeek.ToString();

        public string TypeSolicitation => "Iremos enviar essa solicitação ao cliente";
    }
}
