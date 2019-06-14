using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class TaskLastTtDate
    {
        public int TaskId { get; set; }
        public DateTime? LastTtDate { get; set; }
    }
}
