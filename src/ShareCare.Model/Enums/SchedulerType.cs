using System.ComponentModel.DataAnnotations;

namespace ShareCare.Model.Enums
{
    public enum SchedulerType
    {
        [Display(Name = "Solicitação de Agendamento")]
        Solicitation,

        [Display(Name = "Agendamento")]
        Scheduler
    }
}
