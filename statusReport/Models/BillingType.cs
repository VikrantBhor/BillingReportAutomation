using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class BillingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameLower { get; set; }
        public byte IsDefault { get; set; }
        public byte IsBillable { get; set; }
        public byte IsActive { get; set; }
        public int Position { get; set; }
        public double? Rate { get; set; }
    }
}
