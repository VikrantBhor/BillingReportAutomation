using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserLeaveTimeRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LeaveTypeId { get; set; }
        public int Status { get; set; }
        public string StatusMessage { get; set; }
        public DateTime StatusTimestamp { get; set; }
        public int? ApproverId { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public int FirstDateDuration { get; set; }
        public int LastDateDuration { get; set; }
        public int Duration { get; set; }
        public string Comment { get; set; }
    }
}
