using ShareCare.Model.Enums;

namespace ShareCare.Model.Models
{
    public class ContactModel : BaseModel
    {
        public ContactType Type { get; set; }

        public string Value { get; set; }
    }
}
