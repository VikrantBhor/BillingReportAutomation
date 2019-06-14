using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class MailMessage
    {
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public int BodyBinDataId { get; set; }
        public byte? Tries { get; set; }
        public DateTime? NextTryTimestamp { get; set; }
        public string LastFailureReason { get; set; }
        public string FromPersonal { get; set; }
        public string FromAddress { get; set; }
    }
}
