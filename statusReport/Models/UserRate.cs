using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserRate
    {
        public int Id { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int UserId { get; set; }
        public double RegularRate { get; set; }
        public double? OvertimeRate { get; set; }
    }
}
