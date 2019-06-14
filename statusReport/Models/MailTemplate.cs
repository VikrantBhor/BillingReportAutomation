using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class MailTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
    }
}
