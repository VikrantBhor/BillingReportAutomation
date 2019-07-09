using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace statusReport.DTO
{
    public class ReportList
    {
        public int ReportId { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ReportStartDate { get; set; }
        public DateTime? ReportEndDate { get; set; }
        public string SubmittedBy { get; set; }
        public string Remark { get; set; }

    }
}
