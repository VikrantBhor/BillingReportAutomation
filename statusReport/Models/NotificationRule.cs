using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class NotificationRule
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public short IsActive { get; set; }
        public DateTime LastChangeTimestamp { get; set; }
    }
}
