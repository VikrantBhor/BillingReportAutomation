using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class LeaveRate
    {
        public int RateId { get; set; }
        public int LeaveType { get; set; }
        public double Rate { get; set; }
    }
}
