using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace statusReport.DTO
{
    public class Report
    {
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByEmail { get; set; }        
        public DateTime ReportStartDate { get; set; }
        public int? ReportStatus { get; set; }
        public DateTime ReportEndDate { get; set; }
        
        public string Type { get; set; }

    }
}
