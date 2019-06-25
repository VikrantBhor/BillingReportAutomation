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
        public int onShoreTotalHrs { get; set; }
        public int onShoreHrsTillLastWeek { get; set; }
        public int onShoreHrsCurrentWeek { get; set; }
        public int offShoreTotalHrs { get; set; }
        public int offShoreHrsTillLastWeek { get; set; }
        public int offShoreHrsCurrentWeek { get; set; }
        public string notes { get; set; }

    }

    public class CRDetails
    {
        public string crName { get; set; }
        public int estimateHrs { get; set; }
        public int actualHrs { get; set; }
        public string status { get; set; }

    }

    public class ActivityDetails
    {
        public string milestones { get; set; }
        public int eta { get; set; }

        //public int? activityId { get; set; }
        //public string report { get; set; }
        //public int? reportId { get; set; }


          //      milestone: string;
          //ETA: number;
    }

}
