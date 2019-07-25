using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace statusReport.ViewModel
{
    public class ReportSummery
    {
        public int id { get; set; }
        public string clientName { get; set; }
        public string projectName { get; set; }
        public string projectType { get; set; }
        public string accomp { get; set; }
        public List<CRDetails> crDetails { get; set; }
        public List<ActivityDetails> activityDetails { get; set; }
        public string clientAwtInfo { get; set; }
        public Decimal onShoreTotalHrs { get; set; }
        public Decimal onShoreHrsTillLastWeek { get; set; }
        public Decimal onShoreHrsCurrentWeek { get; set; }
        public Decimal offShoreTotalHrs { get; set; }
        public Decimal offShoreHrsTillLastWeek { get; set; }
        public Decimal offShoreHrsCurrentWeek { get; set; }
        public string notes { get; set; }
        public DateTime ReportStartDate { get; set; }
        public DateTime ReportEndDate { get; set; }
        public string CreatedByEmail { get; set; }
        public string CreatedBy { get; set; }
        public string Type { get; set; }
    }

    public class CRDetails
    {
        public string crName { get; set; }
        public Decimal estimateHrs { get; set; }
        public Decimal actualHrs { get; set; }
        public string status { get; set; }

    }

    public class ActivityDetails
    {
        public string milestones { get; set; }
        public Decimal eta { get; set; }

    }

    public class userCommends
    {
        public int userId { get; set; }
        public  int taskId { get; set; }
        public DateTime date { get; set; }
        public string comments { get; set; }

    }

}
