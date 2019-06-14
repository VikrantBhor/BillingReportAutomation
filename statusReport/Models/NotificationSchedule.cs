using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class NotificationSchedule
    {
        public int NotificationType { get; set; }
        public string Cron { get; set; }
    }
}
