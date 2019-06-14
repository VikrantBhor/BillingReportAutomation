using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class BinData
    {
        public int BinDataId { get; set; }
        public int DataLength { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
    }
}
