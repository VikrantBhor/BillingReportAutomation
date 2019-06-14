using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserCurPtoBalance
    {
        public int UserId { get; set; }
        public double Balance { get; set; }
        public DateTime Expiry { get; set; }
    }
}
