using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserSchedule
    {
        public int UserId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Schedule { get; set; }
        public int WeekTotal { get; set; }
        public byte IsDefault { get; set; }
    }
}
