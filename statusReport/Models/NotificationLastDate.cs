using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class NotificationLastDate
    {
        public int UserId { get; set; }
        public DateTime LastDate { get; set; }
        public int Type { get; set; }
    }
}
