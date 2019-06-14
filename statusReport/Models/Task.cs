using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProjectId { get; set; }
        public DateTime CreateTimestamp { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Name { get; set; }
        public string NameLower { get; set; }
        public string Description { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public int BillingTypeId { get; set; }
        public int? Budget { get; set; }
        public int? ParentId { get; set; }
    }
}
