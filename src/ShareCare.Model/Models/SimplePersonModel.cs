using ShareCare.Model.Enums;
using System.Collections.Generic;

namespace ShareCare.Model.Models
{
    public class SimplePersonModel : BaseModel
    {
        public PersonType Type { get; set; }

        public string Name { get; set; }

        public List<ContactModel> Contacts { get; set; }
    }
}
