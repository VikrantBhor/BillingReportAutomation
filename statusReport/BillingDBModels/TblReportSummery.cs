using System;
using System.Collections.Generic;

namespace statusReport.BillingDBModels
{
    public partial class TblReportSummery
    {
        public TblReportSummery()
        {
            TblReportActivity = new HashSet<TblReportActivity>();
            TblReportCr = new HashSet<TblReportCr>();
            TblReportSummeryDetails = new HashSet<TblReportSummeryDetails>();
        }

        public int ReportId { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public DateTime ReportStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByEmail { get; set; }        
        public DateTime? CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Remark { get; set; }
        public bool? IsApproved { get; set; }
        public int? ReportStatus { get; set; }

        public virtual ICollection<TblReportActivity> TblReportActivity { get; set; }
        public virtual ICollection<TblReportCr> TblReportCr { get; set; }
        public virtual ICollection<TblReportSummeryDetails> TblReportSummeryDetails { get; set; }
    }
}
