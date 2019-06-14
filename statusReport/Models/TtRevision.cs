using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class TtRevision
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public DateTime RecordDate { get; set; }
        public long Revision { get; set; }
    }
}
