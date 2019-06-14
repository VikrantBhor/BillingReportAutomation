using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserDateLeaveRevision
    {
        public int UserId { get; set; }
        public DateTime LeaveDate { get; set; }
        public long Revision { get; set; }
    }
}
