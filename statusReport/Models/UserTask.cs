using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserTask
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public DateTime Date { get; set; }
    }
}
