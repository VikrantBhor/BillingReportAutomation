using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserNotifRuleSend
    {
        public int Id { get; set; }
        public int RuleId { get; set; }
        public int UserId { get; set; }
        public DateTime NotificationDate { get; set; }
        public DateTime? RangeStart { get; set; }
        public DateTime? RangeEnd { get; set; }
    }
}
