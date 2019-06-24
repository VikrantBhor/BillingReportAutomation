using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySql.Data.MySqlClient;

namespace statusReport.Models
{
    public partial class actitimeContext : DbContext
    {
        public string ConnectionString { get; set; }
        public actitimeContext()
        {
        }
        public actitimeContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public actitimeContext(DbContextOptions<actitimeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessRight> AccessRight { get; set; }
        public virtual DbSet<AtUser> AtUser { get; set; }
        public virtual DbSet<AtUserRevision> AtUserRevision { get; set; }
        public virtual DbSet<BillingType> BillingType { get; set; }
        public virtual DbSet<BillingTypeRevision> BillingTypeRevision { get; set; }
        public virtual DbSet<BinData> BinData { get; set; }
        public virtual DbSet<BinDataChunk> BinDataChunk { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerRevision> CustomerRevision { get; set; }
        public virtual DbSet<DefaultWorkdayDurationHistory> DefaultWorkdayDurationHistory { get; set; }
        public virtual DbSet<DeletedUser> DeletedUser { get; set; }
        public virtual DbSet<GuiNotification> GuiNotification { get; set; }
        public virtual DbSet<LeaveRate> LeaveRate { get; set; }
        public virtual DbSet<LeaveType> LeaveType { get; set; }
        public virtual DbSet<LeaveTypeRevision> LeaveTypeRevision { get; set; }
        public virtual DbSet<License> License { get; set; }
        public virtual DbSet<MailMessage> MailMessage { get; set; }
        public virtual DbSet<MailMessageAttachment> MailMessageAttachment { get; set; }
        public virtual DbSet<MailTemplate> MailTemplate { get; set; }
        public virtual DbSet<NotificationLastDate> NotificationLastDate { get; set; }
        public virtual DbSet<NotificationRule> NotificationRule { get; set; }
        public virtual DbSet<NotificationSchedule> NotificationSchedule { get; set; }
        public virtual DbSet<Overtime> Overtime { get; set; }
        public virtual DbSet<PatchHistory> PatchHistory { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectRevision> ProjectRevision { get; set; }
        public virtual DbSet<ProjectUserNotifRuleSend> ProjectUserNotifRuleSend { get; set; }
        public virtual DbSet<ReportConfigs> ReportConfigs { get; set; }
        public virtual DbSet<ReportParamsCustomer> ReportParamsCustomer { get; set; }
        public virtual DbSet<ReportParamsProject> ReportParamsProject { get; set; }
        public virtual DbSet<RevisionSeq> RevisionSeq { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskLastTtDate> TaskLastTtDate { get; set; }
        public virtual DbSet<TaskRevision> TaskRevision { get; set; }
        public virtual DbSet<TaskUserNotifRuleSend> TaskUserNotifRuleSend { get; set; }
        public virtual DbSet<TtMetadata> TtMetadata { get; set; }
        public virtual DbSet<TtRecord> TtRecord { get; set; }
        public virtual DbSet<TtRevision> TtRevision { get; set; }
        public virtual DbSet<UserAccessRight> UserAccessRight { get; set; }
        public virtual DbSet<UserContextName> UserContextName { get; set; }
        public virtual DbSet<UserCurPtoBalance> UserCurPtoBalance { get; set; }
        public virtual DbSet<UserDateLeave> UserDateLeave { get; set; }
        public virtual DbSet<UserDateLeaveRevision> UserDateLeaveRevision { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<UserLeaveTimeRequest> UserLeaveTimeRequest { get; set; }
        public virtual DbSet<UserLtrApprover> UserLtrApprover { get; set; }
        public virtual DbSet<UserNotifRuleSend> UserNotifRuleSend { get; set; }
        public virtual DbSet<UserProject> UserProject { get; set; }
        public virtual DbSet<UserProjectRevision> UserProjectRevision { get; set; }
        public virtual DbSet<UserPtoCap> UserPtoCap { get; set; }
        public virtual DbSet<UserPtoRule> UserPtoRule { get; set; }
        public virtual DbSet<UserPtoStats> UserPtoStats { get; set; }
        public virtual DbSet<UserRate> UserRate { get; set; }
        public virtual DbSet<UserSchedule> UserSchedule { get; set; }
        public virtual DbSet<UserSeenGuiNotif> UserSeenGuiNotif { get; set; }
        public virtual DbSet<UserTask> UserTask { get; set; }
        public virtual DbSet<UserTaskComment> UserTaskComment { get; set; }
        public virtual DbSet<UserTtApprover> UserTtApprover { get; set; }
        public virtual DbSet<UserUserNotifRuleSend> UserUserNotifRuleSend { get; set; }
        public virtual DbSet<UserWorkScheduleCalendar> UserWorkScheduleCalendar { get; set; }
        public virtual DbSet<WDays> WDays { get; set; }
        public virtual DbSet<WDaysRevision> WDaysRevision { get; set; }
        public virtual DbSet<WeekApprovalCurrentStatus> WeekApprovalCurrentStatus { get; set; }
        public virtual DbSet<WeekApprovalStatusHistory> WeekApprovalStatusHistory { get; set; }

       



        // Unable to generate entity type for table 'actitime.invoice_bill_to_recent_entry'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.invoice_discount'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.invoice_last_used_number'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.invoice_params'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.invoice_tax'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.invoice_terms'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.mail_message_recipient'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.notification_rule_params'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.password_recovery_token'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.registration_info'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.report_params'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.system_settings'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.system_settings_revision'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.tt_lock'. Please see the warning messages.
        // Unable to generate entity type for table 'actitime.user_settings'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=Azr-at-s5-de007;port=3306;user=vikasjain;password=V!kas@123;database=actitime");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AccessRight>(entity =>
            {
                entity.ToTable("access_right", "actitime");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AtUser>(entity =>
            {
                entity.ToTable("at_user", "actitime");

                entity.HasIndex(e => e.IsEnabled)
                    .HasName("is_enabled");

                entity.HasIndex(e => e.IsPto)
                    .HasName("is_pto");

                entity.HasIndex(e => e.UserGroupId)
                    .HasName("fk_at_user_user_group");

                entity.HasIndex(e => e.UsernameLower)
                    .HasName("username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.AllProjectsAssigned)
                    .HasColumnName("all_projects_assigned")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DefPtoRules)
                    .HasColumnName("def_pto_rules")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.FirstNameLower)
                    .IsRequired()
                    .HasColumnName("first_name_lower")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("date");

                entity.Property(e => e.InitialSchedule)
                    .IsRequired()
                    .HasColumnName("initial_schedule")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InitialScheduleTotal)
                    .HasColumnName("initial_schedule_total")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.IsDefaultInitialSchedule)
                    .HasColumnName("is_default_initial_schedule")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsEnabledAp)
                    .HasColumnName("is_enabled_ap")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsLocked)
                    .HasColumnName("is_locked")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IsPto)
                    .HasColumnName("is_pto")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.KeepAllTasksFromPreviousWeek)
                    .HasColumnName("keep_all_tasks_from_previous_week")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LastNameLower)
                    .IsRequired()
                    .HasColumnName("last_name_lower")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ManageAllUsersLtr)
                    .HasColumnName("manage_all_users_ltr")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ManageAllUsersTt)
                    .HasColumnName("manage_all_users_tt")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Md5Password)
                    .IsRequired()
                    .HasColumnName("md5_password")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleNameLower)
                    .HasColumnName("middle_name_lower")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OtherContact)
                    .HasColumnName("other_contact")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OvertimeLevel)
                    .HasColumnName("overtime_level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OvertimeTracking)
                    .HasColumnName("overtime_tracking")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate)
                    .HasColumnName("release_date")
                    .HasColumnType("date");

                entity.Property(e => e.RequiresLtrApproval)
                    .HasColumnName("requires_ltr_approval")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RequiresTtApproval)
                    .HasColumnName("requires_tt_approval")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TimeZone)
                    .HasColumnName("time_zone")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UserGroupId)
                    .HasColumnName("user_group_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsernameLower)
                    .IsRequired()
                    .HasColumnName("username_lower")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AtUserRevision>(entity =>
            {
                entity.ToTable("at_user_revision", "actitime");

                entity.HasIndex(e => e.Revision)
                    .HasName("uk_user_revision_value")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<BillingType>(entity =>
            {
                entity.ToTable("billing_type", "actitime");

                entity.HasIndex(e => e.NameLower)
                    .HasName("name_lower")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsBillable)
                    .HasColumnName("is_billable")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsDefault)
                    .HasColumnName("is_default")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameLower)
                    .IsRequired()
                    .HasColumnName("name_lower")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("double(10,2) unsigned");
            });

            modelBuilder.Entity<BillingTypeRevision>(entity =>
            {
                entity.ToTable("billing_type_revision", "actitime");

                entity.HasIndex(e => e.Revision)
                    .HasName("uk_billing_type_revision")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<BinData>(entity =>
            {
                entity.ToTable("bin_data", "actitime");

                entity.Property(e => e.BinDataId)
                    .HasColumnName("bin_data_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.DataLength)
                    .HasColumnName("data_length")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.FileName)
                    .HasColumnName("file_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MimeType)
                    .HasColumnName("mime_type")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BinDataChunk>(entity =>
            {
                entity.HasKey(e => new { e.BinDataId, e.ChunkNum });

                entity.ToTable("bin_data_chunk", "actitime");

                entity.Property(e => e.BinDataId)
                    .HasColumnName("bin_data_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.ChunkNum)
                    .HasColumnName("chunk_num")
                    .HasColumnType("int(2) unsigned");

                entity.Property(e => e.ChunkData)
                    .HasColumnName("chunk_data")
                    .HasColumnType("mediumblob");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer", "actitime");

                entity.HasIndex(e => e.ArchivingTimestamp)
                    .HasName("customer_archts_i");

                entity.HasIndex(e => e.NameLower)
                    .HasName("name_lower")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3)");

                entity.Property(e => e.ArchivingTimestamp).HasColumnName("archiving_timestamp");

                entity.Property(e => e.CreateTimestamp)
                    .HasColumnName("create_timestamp")
                    .HasDefaultValueSql("0000-00-00 00:00:00");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(209)
                    .IsUnicode(false);

                entity.Property(e => e.NameLower)
                    .IsRequired()
                    .HasColumnName("name_lower")
                    .HasMaxLength(209)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerRevision>(entity =>
            {
                entity.ToTable("customer_revision", "actitime");

                entity.HasIndex(e => e.Revision)
                    .HasName("uk_customer_revision_value")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<DefaultWorkdayDurationHistory>(entity =>
            {
                entity.HasKey(e => e.EffectiveDate);

                entity.ToTable("default_workday_duration_history", "actitime");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnName("effective_date")
                    .HasColumnType("date");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<DeletedUser>(entity =>
            {
                entity.ToTable("deleted_user", "actitime");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GuiNotification>(entity =>
            {
                entity.ToTable("gui_notification", "actitime");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Contents)
                    .IsRequired()
                    .HasColumnName("contents")
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate)
                    .HasColumnName("expiration_date")
                    .HasColumnType("date");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ShowToNewUsers)
                    .HasColumnName("show_to_new_users")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<LeaveRate>(entity =>
            {
                entity.HasKey(e => new { e.RateId, e.LeaveType });

                entity.ToTable("leave_rate", "actitime");

                entity.HasIndex(e => e.LeaveType)
                    .HasName("leave_rate_leave_type_fk_leave_type_id");

                entity.Property(e => e.RateId)
                    .HasColumnName("rate_id")
                    .HasColumnType("int(5) unsigned");

                entity.Property(e => e.LeaveType)
                    .HasColumnName("leave_type")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("double(10,2) unsigned");
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.ToTable("leave_type", "actitime");

                entity.HasIndex(e => e.IconId)
                    .HasName("k_icon_id");

                entity.HasIndex(e => e.NameLower)
                    .HasName("leave_type_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.IconId)
                    .HasColumnName("icon_id")
                    .HasColumnType("int(4) unsigned");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsPto)
                    .HasColumnName("is_pto")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.NameLower)
                    .IsRequired()
                    .HasColumnName("name_lower")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.PtoCoeff)
                    .HasColumnName("pto_coeff")
                    .HasColumnType("double(10,2) unsigned")
                    .HasDefaultValueSql("1.00");

                entity.Property(e => e.RateCoefficient)
                    .HasColumnName("rate_coefficient")
                    .HasColumnType("double(10,2) unsigned")
                    .HasDefaultValueSql("1.00");

                entity.Property(e => e.RequiresApproval)
                    .HasColumnName("requires_approval")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<LeaveTypeRevision>(entity =>
            {
                entity.ToTable("leave_type_revision", "actitime");

                entity.HasIndex(e => e.Revision)
                    .HasName("uk_leave_type_revision")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<License>(entity =>
            {
                entity.ToTable("license", "actitime");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .IsUnicode(false);

                entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            });

            modelBuilder.Entity<MailMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.ToTable("mail_message", "actitime");

                entity.HasIndex(e => e.BodyBinDataId)
                    .HasName("mail_message_body_bin_data_id_fk_bin_data_bin_data_id");

                entity.Property(e => e.MessageId)
                    .HasColumnName("message_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.BodyBinDataId)
                    .HasColumnName("body_bin_data_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.FromAddress)
                    .IsRequired()
                    .HasColumnName("from_address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FromPersonal)
                    .HasColumnName("from_personal")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastFailureReason)
                    .HasColumnName("last_failure_reason")
                    .IsUnicode(false);

                entity.Property(e => e.NextTryTimestamp).HasColumnName("next_try_timestamp");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .IsUnicode(false);

                entity.Property(e => e.Tries)
                    .HasColumnName("tries")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<MailMessageAttachment>(entity =>
            {
                entity.HasKey(e => new { e.MessageId, e.BinDataId });

                entity.ToTable("mail_message_attachment", "actitime");

                entity.HasIndex(e => e.BinDataId)
                    .HasName("mail_message_attachment_bin_data_id_fk_bin_data_bin_data_id");

                entity.Property(e => e.MessageId)
                    .HasColumnName("message_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.BinDataId)
                    .HasColumnName("bin_data_id")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<MailTemplate>(entity =>
            {
                entity.ToTable("mail_template", "actitime");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.LastModifiedTimestamp).HasColumnName("last_modified_timestamp");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Template)
                    .IsRequired()
                    .HasColumnName("template")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NotificationLastDate>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Type });

                entity.ToTable("notification_last_date", "actitime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(2) unsigned");

                entity.Property(e => e.LastDate)
                    .HasColumnName("last_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<NotificationRule>(entity =>
            {
                entity.ToTable("notification_rule", "actitime");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastChangeTimestamp).HasColumnName("last_change_timestamp");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(2) unsigned");
            });

            modelBuilder.Entity<NotificationSchedule>(entity =>
            {
                entity.HasKey(e => e.NotificationType);

                entity.ToTable("notification_schedule", "actitime");

                entity.Property(e => e.NotificationType)
                    .HasColumnName("notification_type")
                    .HasColumnType("int(2) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cron)
                    .IsRequired()
                    .HasColumnName("cron")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Overtime>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.OvertimeDate });

                entity.ToTable("overtime", "actitime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OvertimeDate)
                    .HasColumnName("overtime_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("0000-00-00");

                entity.Property(e => e.Overtime1)
                    .HasColumnName("overtime")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PatchHistory>(entity =>
            {
                entity.HasKey(e => new { e.Patch, e.PackVersion });

                entity.ToTable("patch_history", "actitime");

                entity.Property(e => e.Patch)
                    .HasColumnName("patch")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PackVersion)
                    .HasColumnName("pack_version")
                    .HasColumnType("int(2) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PatchTimestamp)
                    .HasColumnName("patch_timestamp")
                    .HasDefaultValueSql("0000-00-00 00:00:00");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project", "actitime");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("project_customer_id_i");

                entity.HasIndex(e => new { e.CustomerId, e.ArchivingTimestamp })
                    .HasName("project_customer_archts_i");

                entity.HasIndex(e => new { e.CustomerId, e.NameLower })
                    .HasName("uk_project_customer_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArchivingTimestamp).HasColumnName("archiving_timestamp");

                entity.Property(e => e.CreateTimestamp).HasColumnName("create_timestamp");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameLower)
                    .IsRequired()
                    .HasColumnName("name_lower")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectRevision>(entity =>
            {
                entity.ToTable("project_revision", "actitime");

                entity.HasIndex(e => e.Revision)
                    .HasName("uk_project_revision")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<ProjectUserNotifRuleSend>(entity =>
            {
                entity.HasKey(e => new { e.UserNotifRuleSendId, e.ProjectId });

                entity.ToTable("project_user_notif_rule_send", "actitime");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("fk_project_user_notif_rule_send_project");

                entity.Property(e => e.UserNotifRuleSendId)
                    .HasColumnName("user_notif_rule_send_id")
                    .HasColumnType("int(5) unsigned");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasColumnType("int(3)");
            });

            modelBuilder.Entity<ReportConfigs>(entity =>
            {
                entity.ToTable("report_configs", "actitime");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_report_configs_user_id");

                entity.HasIndex(e => new { e.NameLower, e.ReportForm, e.UserId })
                    .HasName("name_form_user")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.FormatId)
                    .HasColumnName("format_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(209)
                    .IsUnicode(false);

                entity.Property(e => e.NameLower)
                    .IsRequired()
                    .HasColumnName("name_lower")
                    .HasMaxLength(209)
                    .IsUnicode(false);

                entity.Property(e => e.ReportForm)
                    .HasColumnName("report_form")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<ReportParamsCustomer>(entity =>
            {
                entity.HasKey(e => new { e.ConfigId, e.CustomerId });

                entity.ToTable("report_params_customer", "actitime");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("fk_rpc_customer_id");

                entity.Property(e => e.ConfigId)
                    .HasColumnName("config_id")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ReportParamsProject>(entity =>
            {
                entity.HasKey(e => new { e.ConfigId, e.ProjectId });

                entity.ToTable("report_params_project", "actitime");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("fk_rpp_project_id");

                entity.Property(e => e.ConfigId)
                    .HasColumnName("config_id")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<RevisionSeq>(entity =>
            {
                entity.HasKey(e => e.Val);

                entity.ToTable("revision_seq", "actitime");

                entity.Property(e => e.Val)
                    .HasColumnName("val")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task", "actitime");

                entity.HasIndex(e => e.BillingTypeId)
                    .HasName("fk_task_billing_type");

                entity.HasIndex(e => e.CompletionDate)
                    .HasName("task_completion_date_idx");

                entity.HasIndex(e => e.ParentId)
                    .HasName("fk_parent_task_id");

                entity.HasIndex(e => new { e.CustomerId, e.NameLower })
                    .HasName("task_customer_name_i");

                entity.HasIndex(e => new { e.ProjectId, e.NameLower, e.ParentId })
                    .HasName("task_project_name_uk")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(5)");

                entity.Property(e => e.BillingTypeId)
                    .HasColumnName("billing_type_id")
                    .HasColumnType("int(3) unsigned")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.Budget)
                    .HasColumnName("budget")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CompletionDate)
                    .HasColumnName("completion_date")
                    .HasColumnType("date");

                entity.Property(e => e.CreateTimestamp).HasColumnName("create_timestamp");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("int(3)");

                entity.Property(e => e.DeadlineDate)
                    .HasColumnName("deadline_date")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameLower)
                    .IsRequired()
                    .HasColumnName("name_lower")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasColumnType("int(3)");
            });

            modelBuilder.Entity<TaskLastTtDate>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.ToTable("task_last_tt_date", "actitime");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasColumnType("int(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastTtDate)
                    .HasColumnName("last_tt_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<TaskRevision>(entity =>
            {
                entity.ToTable("task_revision", "actitime");

                entity.HasIndex(e => e.Revision)
                    .HasName("uk_task_revision")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<TaskUserNotifRuleSend>(entity =>
            {
                entity.HasKey(e => new { e.UserNotifRuleSendId, e.TaskId });

                entity.ToTable("task_user_notif_rule_send", "actitime");

                entity.HasIndex(e => e.TaskId)
                    .HasName("fk_task_user_notif_rule_send_task");

                entity.Property(e => e.UserNotifRuleSendId)
                    .HasColumnName("user_notif_rule_send_id")
                    .HasColumnType("int(5) unsigned");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasColumnType("int(5)");
            });

            modelBuilder.Entity<TtMetadata>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TtDate });

                entity.ToTable("tt_metadata", "actitime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.TtDate)
                    .HasColumnName("tt_date")
                    .HasColumnType("date");

                entity.Property(e => e.LastChangeTimestamp).HasColumnName("last_change_timestamp");
            });

            modelBuilder.Entity<TtRecord>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TaskId, e.RecordDate });

                entity.ToTable("tt_record", "actitime");

                entity.HasIndex(e => e.UserId)
                    .HasName("tt_record_user_i");

                entity.HasIndex(e => new { e.TaskId, e.RecordDate })
                    .HasName("tt_record_task_id_record_date_idx");

                entity.HasIndex(e => new { e.UserId, e.RecordDate })
                    .HasName("tt_record_user_id_record_date_idx");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasColumnType("int(5)");

                entity.Property(e => e.RecordDate)
                    .HasColumnName("record_date")
                    .HasColumnType("date");

                entity.Property(e => e.Actuals)
                    .HasColumnName("actuals")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TtRevision>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TaskId, e.RecordDate });

                entity.ToTable("tt_revision", "actitime");

                entity.HasIndex(e => e.Revision)
                    .HasName("uk_tt_revision")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasColumnType("int(3)");

                entity.Property(e => e.RecordDate)
                    .HasColumnName("record_date")
                    .HasColumnType("date");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<UserAccessRight>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AccessRightId });

                entity.ToTable("user_access_right", "actitime");

                entity.HasIndex(e => e.AccessRightId)
                    .HasName("access_right_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AccessRightId)
                    .HasColumnName("access_right_id")
                    .HasColumnType("int(3) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<UserContextName>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("user_context_name", "actitime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApContextName)
                    .HasColumnName("ap_context_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AtContextName)
                    .HasColumnName("at_context_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserCurPtoBalance>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("user_cur_pto_balance", "actitime");

                entity.HasIndex(e => new { e.UserId, e.Expiry })
                    .HasName("user_cur_pto_balance_user_id_expiry");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Expiry).HasColumnName("expiry");
            });

            modelBuilder.Entity<UserDateLeave>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LeaveDate });

                entity.ToTable("user_date_leave", "actitime");

                entity.HasIndex(e => e.LeaveTypeId)
                    .HasName("user_date_leave_ibfk_2");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.LeaveDate)
                    .HasColumnName("leave_date")
                    .HasColumnType("date");

                entity.Property(e => e.LeaveDuration)
                    .HasColumnName("leave_duration")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LeaveTypeId)
                    .HasColumnName("leave_type_id")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<UserDateLeaveRevision>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LeaveDate });

                entity.ToTable("user_date_leave_revision", "actitime");

                entity.HasIndex(e => e.Revision)
                    .HasName("uk_user_date_leave_revision")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.LeaveDate)
                    .HasColumnName("leave_date")
                    .HasColumnType("date");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.ToTable("user_group", "actitime");

                entity.HasIndex(e => e.Name)
                    .HasName("unique_user_group_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLeaveTimeRequest>(entity =>
            {
                entity.ToTable("user_leave_time_request", "actitime");

                entity.HasIndex(e => e.ApproverId)
                    .HasName("fk_user_leave_time_request_approver_id");

                entity.HasIndex(e => e.LeaveTypeId)
                    .HasName("fk_user_leave_time_request_leave_type_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_user_leave_time_request_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.ApproverId)
                    .HasColumnName("approver_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FirstDate)
                    .HasColumnName("first_date")
                    .HasColumnType("date");

                entity.Property(e => e.FirstDateDuration)
                    .HasColumnName("first_date_duration")
                    .HasColumnType("int(10)");

                entity.Property(e => e.LastDate)
                    .HasColumnName("last_date")
                    .HasColumnType("date");

                entity.Property(e => e.LastDateDuration)
                    .HasColumnName("last_date_duration")
                    .HasColumnType("int(10)");

                entity.Property(e => e.LeaveTypeId)
                    .HasColumnName("leave_type_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.StatusMessage)
                    .HasColumnName("status_message")
                    .IsUnicode(false);

                entity.Property(e => e.StatusTimestamp).HasColumnName("status_timestamp");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<UserLtrApprover>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ApproverId });

                entity.ToTable("user_ltr_approver", "actitime");

                entity.HasIndex(e => e.ApproverId)
                    .HasName("fk_user_approver_approver_id");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.ApproverId)
                    .HasColumnName("approver_id")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<UserNotifRuleSend>(entity =>
            {
                entity.ToTable("user_notif_rule_send", "actitime");

                entity.HasIndex(e => e.RuleId)
                    .HasName("fk_user_notif_rule_send_rule");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_user_notif_rule_send_user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(5) unsigned");

                entity.Property(e => e.NotificationDate)
                    .HasColumnName("notification_date")
                    .HasColumnType("date");

                entity.Property(e => e.RangeEnd)
                    .HasColumnName("range_end")
                    .HasColumnType("date");

                entity.Property(e => e.RangeStart)
                    .HasColumnName("range_start")
                    .HasColumnType("date");

                entity.Property(e => e.RuleId)
                    .HasColumnName("rule_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<UserProject>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProjectId });

                entity.ToTable("user_project", "actitime");

                entity.HasIndex(e => e.ProjectId)
                    .HasName("project_i");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(6) unsigned");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasColumnType("int(6)");
            });

            modelBuilder.Entity<UserProjectRevision>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProjectId });

                entity.ToTable("user_project_revision", "actitime");

                entity.HasIndex(e => e.Revision)
                    .HasName("uk_user_project_revision")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasColumnType("int(6)");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<UserPtoCap>(entity =>
            {
                entity.ToTable("user_pto_cap", "actitime");

                entity.HasIndex(e => new { e.UserId, e.EffectiveDate })
                    .HasName("uk_user_pto_cap_effective_date")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(5) unsigned");

                entity.Property(e => e.Cap).HasColumnName("cap");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnName("effective_date")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<UserPtoRule>(entity =>
            {
                entity.ToTable("user_pto_rule", "actitime");

                entity.HasIndex(e => e.MgrId)
                    .HasName("user_pto_rule_mgr_id_at_user_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_pto_rule_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(5) unsigned");

                entity.Property(e => e.EffectiveFinishDate)
                    .HasColumnName("effective_finish_date")
                    .HasColumnType("date");

                entity.Property(e => e.EffectiveStartDate)
                    .HasColumnName("effective_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.Frequency)
                    .IsRequired()
                    .HasColumnName("frequency")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FrequencyParams)
                    .IsRequired()
                    .HasColumnName("frequency_params")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MgrComment)
                    .HasColumnName("mgr_comment")
                    .IsUnicode(false);

                entity.Property(e => e.MgrId)
                    .HasColumnName("mgr_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<UserPtoStats>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("user_pto_stats", "actitime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApprovedPto).HasColumnName("approved_pto");

                entity.Property(e => e.NotApprovedPto).HasColumnName("not_approved_pto");
            });

            modelBuilder.Entity<UserRate>(entity =>
            {
                entity.ToTable("user_rate", "actitime");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_rate_id_fk_at_user_id");

                entity.HasIndex(e => new { e.EffectiveDate, e.UserId })
                    .HasName("user_id_effective_date_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(5) unsigned");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnName("effective_date")
                    .HasColumnType("date");

                entity.Property(e => e.OvertimeRate)
                    .HasColumnName("overtime_rate")
                    .HasColumnType("double(10,2) unsigned");

                entity.Property(e => e.RegularRate)
                    .HasColumnName("regular_rate")
                    .HasColumnType("double(10,2) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<UserSchedule>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.EffectiveDate });

                entity.ToTable("user_schedule", "actitime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnName("effective_date")
                    .HasColumnType("date");

                entity.Property(e => e.IsDefault)
                    .HasColumnName("is_default")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Schedule)
                    .IsRequired()
                    .HasColumnName("schedule")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WeekTotal)
                    .HasColumnName("week_total")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<UserSeenGuiNotif>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SeenGuiNotifId });

                entity.ToTable("user_seen_gui_notif", "actitime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.SeenGuiNotifId)
                    .HasColumnName("seen_gui_notif_id")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TaskId, e.Date });

                entity.ToTable("user_task", "actitime");

                entity.HasIndex(e => e.TaskId)
                    .HasName("user_task_task_i");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_task_user_i");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<UserTaskComment>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TaskId, e.CommentDate });

                entity.ToTable("user_task_comment", "actitime");

                entity.HasIndex(e => e.TaskId)
                    .HasName("user_task_comment_task_i");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_task_comment_user_i");

                entity.HasIndex(e => new { e.TaskId, e.CommentDate })
                    .HasName("user_task_comment_task_id_comment_date_idx");

                entity.HasIndex(e => new { e.UserId, e.CommentDate })
                    .HasName("user_task_comment_user_date_i");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasColumnType("int(5)");

                entity.Property(e => e.CommentDate)
                    .HasColumnName("comment_date")
                    .HasColumnType("date");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasColumnName("comments")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTtApprover>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ApproverId });

                entity.ToTable("user_tt_approver", "actitime");

                entity.HasIndex(e => e.ApproverId)
                    .HasName("fk_user_tt_approver_approver_id");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.ApproverId)
                    .HasColumnName("approver_id")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<UserUserNotifRuleSend>(entity =>
            {
                entity.HasKey(e => new { e.UserNotifRuleSendId, e.UserId });

                entity.ToTable("user_user_notif_rule_send", "actitime");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_user_user_notif_rule_send_user");

                entity.Property(e => e.UserNotifRuleSendId)
                    .HasColumnName("user_notif_rule_send_id")
                    .HasColumnType("int(5) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");
            });

            modelBuilder.Entity<UserWorkScheduleCalendar>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("user_work_schedule_calendar", "actitime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.MonthCount)
                    .HasColumnName("month_count")
                    .HasColumnType("tinyint(4)");
            });

            modelBuilder.Entity<WDays>(entity =>
            {
                entity.HasKey(e => e.WDate);

                entity.ToTable("w_days", "actitime");

                entity.Property(e => e.WDate)
                    .HasColumnName("w_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("0000-00-00");

                entity.Property(e => e.IsWorkingDay)
                    .HasColumnName("is_working_day")
                    .HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<WDaysRevision>(entity =>
            {
                entity.HasKey(e => e.WDate);

                entity.ToTable("w_days_revision", "actitime");

                entity.HasIndex(e => e.Revision)
                    .HasName("uk_w_days_revision")
                    .IsUnique();

                entity.Property(e => e.WDate)
                    .HasColumnName("w_date")
                    .HasColumnType("date");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("bigint(20) unsigned");
            });

            modelBuilder.Entity<WeekApprovalCurrentStatus>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.WeekDate });

                entity.ToTable("week_approval_current_status", "actitime");

                entity.HasIndex(e => e.ApproverId)
                    .HasName("fk_week_approval_current_status_approver_id");

                entity.HasIndex(e => e.WeekDate)
                    .HasName("week_approval_current_status_week_date_idx");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.WeekDate)
                    .HasColumnName("week_date")
                    .HasColumnType("date");

                entity.Property(e => e.ApproverId)
                    .HasColumnName("approver_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.StatusTimestamp).HasColumnName("status_timestamp");
            });

            modelBuilder.Entity<WeekApprovalStatusHistory>(entity =>
            {
                entity.ToTable("week_approval_status_history", "actitime");

                entity.HasIndex(e => e.ApproverId)
                    .HasName("fk_week_approval_status_history_approver_id");

                entity.HasIndex(e => e.WeekDate)
                    .HasName("week_approval_status_history_week_date_idx");

                entity.HasIndex(e => new { e.UserId, e.WeekDate })
                    .HasName("week_approval_status_history_user_id_week_date_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.ApproverId)
                    .HasColumnName("approver_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.StatusTimestamp).HasColumnName("status_timestamp");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(3) unsigned");

                entity.Property(e => e.WeekDate)
                    .HasColumnName("week_date")
                    .HasColumnType("date");
            });
        }
    }
}
