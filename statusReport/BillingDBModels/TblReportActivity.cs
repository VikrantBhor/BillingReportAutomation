using System;
using System.Collections.Generic;

namespace statusReport.BillingDBModels
{
    public partial class TblReportActivity
    {
        public TblReportActivity()
        {
            TblReportSummeryDetails = new HashSet<TblReportSummeryDetails>();
        }

        public int ActivityId { get; set; }
        public int ReportId { get; set; }
        public string Milestones { get; set; }
        public decimal? Eta { get; set; }

        public virtual TblReportSummery Report { get; set; }
        public virtual ICollection<TblReportSummeryDetails> TblReportSummeryDetails { get; set; }
    }
}
