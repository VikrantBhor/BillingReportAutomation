using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class TtMetadata
    {
        public int UserId { get; set; }
        public DateTime TtDate { get; set; }
        public DateTime LastChangeTimestamp { get; set; }
    }
}
