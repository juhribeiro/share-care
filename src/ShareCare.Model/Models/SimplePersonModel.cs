using ShareCare.Model.Enums;
using System.Collections.Generic;

namespace ShareCare.Model.Models
{
    public class SimplePersonModel : BaseModel
    {

        public SimplePersonModel()
        {
            Contacts = new List<ContactModel>();
        }

        public PersonType Type { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string SimpleName => Name.Split(" ")[0];

        public List<ContactModel> Contacts { get; set; }
    }
}
