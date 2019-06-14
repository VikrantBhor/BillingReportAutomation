using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public DateTime CreateTimestamp { get; set; }
        public string Name { get; set; }
        public string NameLower { get; set; }
        public string Description { get; set; }
        public DateTime? ArchivingTimestamp { get; set; }
    }
}
