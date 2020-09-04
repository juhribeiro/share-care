using ShareCare.Model.Enums;
using System;

namespace ShareCare.Model.DbModels
{
    public class Contact : BaseDbModel
    {
        public ContactType Type { get; set; }

        public string Value { get; set; }

        public Guid PersonId { get; set; }

        public Person Person { get; set; }
    }
}
