using System.ComponentModel.DataAnnotations;

namespace ShareCare.Model.Enums
{
    public enum PersonType
    {
        [Display(Name = "Médico")]
        Doctor,

        [Display(Name = "Beneficiário")]
        Patient
    }
}
