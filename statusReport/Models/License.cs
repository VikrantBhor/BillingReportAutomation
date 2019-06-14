using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class License
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string Body { get; set; }
    }
}
