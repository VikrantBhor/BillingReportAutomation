using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserPtoRule
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte Type { get; set; }
        public double Value { get; set; }
        public string Frequency { get; set; }
        public string FrequencyParams { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime? EffectiveFinishDate { get; set; }
        public int? MgrId { get; set; }
        public string MgrComment { get; set; }
    }
}
