using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class WDays
    {
        public DateTime WDate { get; set; }
        public byte IsWorkingDay { get; set; }
    }
}
