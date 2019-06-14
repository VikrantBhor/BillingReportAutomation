using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class UserTaskComment
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public DateTime CommentDate { get; set; }
        public string Comments { get; set; }
    }
}
