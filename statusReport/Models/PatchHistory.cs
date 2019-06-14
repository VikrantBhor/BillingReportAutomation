using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class PatchHistory
    {
        public int Patch { get; set; }
        public DateTime PatchTimestamp { get; set; }
        public int PackVersion { get; set; }
    }
}
