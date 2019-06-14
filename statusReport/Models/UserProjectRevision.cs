using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserProjectRevision
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public long Revision { get; set; }
    }
}
