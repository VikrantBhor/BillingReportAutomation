using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace statusReport.BillingDBModels
{
    public partial class BillingReportContext : DbContext
    {
        public BillingReportContext()
        {
        }

        public BillingReportContext(DbContextOptions<BillingReportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblReportActivity> TblReportActivity { get; set; }
        public virtual DbSet<TblReportCr> TblReportCr { get; set; }
        public virtual DbSet<TblReportStatus> TblReportStatus { get; set; }
        public virtual DbSet<TblReportSummery> TblReportSummery { get; set; }
        public virtual DbSet<TblReportSummeryDetails> TblReportSummeryDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=BillingReport;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<TblReportActivity>(entity =>
            {
                entity.HasKey(e => e.ActivityId);

                entity.ToTable("tbl_ReportActivity");

                entity.Property(e => e.Eta)
                    .HasColumnName("ETA")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Milestones).HasMaxLength(1000);

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.TblReportActivity)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ReportActivity_tbl_ReportSummery");
            });

            modelBuilder.Entity<TblReportCr>(entity =>
            {
                entity.HasKey(e => e.Crid);

                entity.ToTable("tbl_ReportCR");

                entity.Property(e => e.Crid).HasColumnName("CRId");

                entity.Property(e => e.ActualHrs).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CrName)
                    .HasColumnName("CR_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.EstimateHrs).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.TblReportCr)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ReportCR_tbl_ReportSummery");
            });

            modelBuilder.Entity<TblReportStatus>(entity =>
            {
                entity.ToTable("tbl_ReportStatus");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<TblReportSummery>(entity =>
            {
                entity.HasKey(e => e.ReportId);

                entity.ToTable("tbl_ReportSummery");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectEndDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ReportStartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblReportSummeryDetails>(entity =>
            {
                entity.HasKey(e => e.ReportDetailsId);

                entity.ToTable("tbl_ReportSummeryDetails");

                entity.Property(e => e.Accomplishments).HasMaxLength(1000);

                entity.Property(e => e.ClientAwtInfo).HasMaxLength(1000);

                entity.Property(e => e.Crid).HasColumnName("CRId");

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.OffShoreTotalHrs)
                    .HasColumnName("OffShore_TotalHrs")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OffshoreCurrentWeekHrs)
                    .HasColumnName("Offshore_CurrentWeekHrs")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OffshoreLastWeekHrs)
                    .HasColumnName("Offshore_LastWeekHrs")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OnshoreCurrentWeekHrs)
                    .HasColumnName("Onshore_CurrentWeekHrs")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OnshoreLastWeekHrs)
                    .HasColumnName("Onshore_LastWeekHrs")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OnshoreTotalHrs)
                    .HasColumnName("Onshore_TotalHrs")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TblReportSummeryDetails)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ReportSummeryDetails_tbl_ReportActivity");

                entity.HasOne(d => d.Cr)
                    .WithMany(p => p.TblReportSummeryDetails)
                    .HasForeignKey(d => d.Crid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ReportSummeryDetails_tbl_ReportCR");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.TblReportSummeryDetails)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ReportSummeryDetails_tbl_ReportSummery");
            });
        }
    }
}
