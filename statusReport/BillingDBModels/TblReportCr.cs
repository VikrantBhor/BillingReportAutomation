using System;
using System.Collections.Generic;

namespace statusReport.BillingDBModels
{
    public partial class TblReportCr
    {
        public TblReportCr()
        {
            TblReportSummeryDetails = new HashSet<TblReportSummeryDetails>();
        }

        public int Crid { get; set; }
        public int ReportId { get; set; }
        public string CrName { get; set; }
        public decimal? EstimateHrs { get; set; }
        public decimal? ActualHrs { get; set; }
        public int Status { get; set; }

        public virtual TblReportSummery Report { get; set; }
        public virtual ICollection<TblReportSummeryDetails> TblReportSummeryDetails { get; set; }
    }
}
