using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserPtoCap
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double? Cap { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
