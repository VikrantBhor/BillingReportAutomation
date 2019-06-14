using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class WeekApprovalCurrentStatus
    {
        public int UserId { get; set; }
        public DateTime WeekDate { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public DateTime StatusTimestamp { get; set; }
        public int? ApproverId { get; set; }
    }
}
