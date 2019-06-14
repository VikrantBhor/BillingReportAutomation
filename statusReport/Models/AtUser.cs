using System;
using System.Collections.Generic;

namespace statusReport.Models
{
    public partial class AtUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string UsernameLower { get; set; }
        public string Md5Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string OtherContact { get; set; }
        public byte IsEnabled { get; set; }
        public byte? OvertimeTracking { get; set; }
        public int? OvertimeLevel { get; set; }
        public byte? IsLocked { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public byte AllProjectsAssigned { get; set; }
        public string TimeZone { get; set; }
        public int? UserGroupId { get; set; }
        public byte IsEnabledAp { get; set; }
        public string FirstNameLower { get; set; }
        public string LastNameLower { get; set; }
        public string MiddleNameLower { get; set; }
        public string InitialSchedule { get; set; }
        public int InitialScheduleTotal { get; set; }
        public byte IsDefaultInitialSchedule { get; set; }
        public byte RequiresLtrApproval { get; set; }
        public byte IsPto { get; set; }
        public byte DefPtoRules { get; set; }
        public byte KeepAllTasksFromPreviousWeek { get; set; }
        public byte RequiresTtApproval { get; set; }
        public byte ManageAllUsersTt { get; set; }
        public byte ManageAllUsersLtr { get; set; }
    }
}
