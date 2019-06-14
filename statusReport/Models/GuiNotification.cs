using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class GuiNotification
    {
        public int Id { get; set; }
        public string Contents { get; set; }
        public byte IsEnabled { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int Priority { get; set; }
        public byte ShowToNewUsers { get; set; }
    }
}
