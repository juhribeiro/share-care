using ShareCare.Model.Enums;
using System.Collections.Generic;

namespace ShareCare.Model.DbModels
{
    public abstract class Person : BaseDbModel
    {
        public string Name { get; set; }

        public PersonType Type { get; set; }

        public string Password { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
