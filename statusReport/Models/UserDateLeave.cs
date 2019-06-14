using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserDateLeave
    {
        public int UserId { get; set; }
        public DateTime LeaveDate { get; set; }
        public int LeaveTypeId { get; set; }
        public int LeaveDuration { get; set; }
    }
}
