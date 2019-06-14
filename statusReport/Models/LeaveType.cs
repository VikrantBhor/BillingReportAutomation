using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameLower { get; set; }
        public byte IsActive { get; set; }
        public int IconId { get; set; }
        public int Position { get; set; }
        public double RateCoefficient { get; set; }
        public byte IsPto { get; set; }
        public double PtoCoeff { get; set; }
        public byte RequiresApproval { get; set; }
    }
}
