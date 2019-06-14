using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserPtoStats
    {
        public int UserId { get; set; }
        public double ApprovedPto { get; set; }
        public double NotApprovedPto { get; set; }
    }
}
