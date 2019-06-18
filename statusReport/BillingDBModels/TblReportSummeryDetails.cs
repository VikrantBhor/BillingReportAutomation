using System;
using System.Collections.Generic;

namespace statusReport.BillingDBModels
{
    public partial class TblReportSummeryDetails
    {
        public int ReportDetailsId { get; set; }
        public int ReportId { get; set; }
        public int Crid { get; set; }
        public int ActivityId { get; set; }
        public decimal? OnshoreTotalHrs { get; set; }
        public decimal? OnshoreLastWeekHrs { get; set; }
        public decimal? OnshoreCurrentWeekHrs { get; set; }
        public decimal? OffShoreTotalHrs { get; set; }
        public decimal? OffshoreLastWeekHrs { get; set; }
        public decimal? OffshoreCurrentWeekHrs { get; set; }
        public string Accomplishments { get; set; }
        public string ClientAwtInfo { get; set; }
        public string Notes { get; set; }

        public virtual TblReportActivity Activity { get; set; }
        public virtual TblReportCr Cr { get; set; }
        public virtual TblReportSummery Report { get; set; }
    }
}
