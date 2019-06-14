using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class TtRecord
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public DateTime RecordDate { get; set; }
        public int Actuals { get; set; }
    }
}
