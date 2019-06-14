using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class ReportConfigs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameLower { get; set; }
        public int ReportForm { get; set; }
        public string Description { get; set; }
        public int FormatId { get; set; }
        public int UserId { get; set; }
    }
}
