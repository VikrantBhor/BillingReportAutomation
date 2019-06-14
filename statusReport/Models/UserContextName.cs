using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserContextName
    {
        public int UserId { get; set; }
        public string AtContextName { get; set; }
        public string ApContextName { get; set; }
    }
}
