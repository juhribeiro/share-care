using ShareCare.Model.Enums;
using System;

namespace ShareCare.Model.DbModels
{
    public class Enchiridion : BaseDbModel
    {
        public string Value { get; set; }

        public EnchiridionType Type { get; set; }

        public DateTime Date { get; set; }

        public Guid SchedulerId { get; set; }

        public Scheduler Scheduler { get; set; }
    }
}
