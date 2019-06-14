using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class DeletedUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
