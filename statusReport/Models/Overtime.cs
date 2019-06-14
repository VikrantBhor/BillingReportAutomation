using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class Overtime
    {
        public int UserId { get; set; }
        public DateTime OvertimeDate { get; set; }
        public int Overtime1 { get; set; }
    }
}
