using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class BinDataChunk
    {
        public int BinDataId { get; set; }
        public int ChunkNum { get; set; }
        public byte[] ChunkData { get; set; }
    }
}
