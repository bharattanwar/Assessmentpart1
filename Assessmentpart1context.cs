using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assessment_part_1.Models;

public partial class Assessmentpart1Context : DbContext
{
    public Assessmentpart1Context()
    {
    }

    public Assessmentpart1Context(DbContextOptions<Assessmentpart1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<ApprovalReject> ApprovalRejects { get; set; }

    public virtual DbSet<AssessmentScore> AssessmentScores { get; set; }

    public virtual DbSet<QuestionOption> QuestionOptions { get; set; }

    public virtual DbSet<Questionnaire> Questionnaires { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VendorAssessment> VendorAssessments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("server=localhost;database=Assessmentpart1;port=5432;user id=postgres;password=3011");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admin_pkey");

            entity.ToTable("Admin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.VendorId).HasColumnName("vendorId");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Admins)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("admin_fkey");
        });

        modelBuilder.Entity<ApprovalReject>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ApprovalReject");

            entity.Property(e => e.AssessmentId).HasColumnName("assessmentId");
            entity.Property(e => e.Decision).HasColumnName("decision");
            entity.Property(e => e.DecisionBy).HasColumnName("decisionBy");
            entity.Property(e => e.DecisionOn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("decisionOn");
            entity.Property(e => e.VendorId).HasColumnName("vendorId");
        });

        modelBuilder.Entity<AssessmentScore>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AssessmentScore");

            entity.Property(e => e.AssessmentId).HasColumnName("assessmentId");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdOn");
            entity.Property(e => e.QuestionSet).HasColumnName("questionSet");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.VendorId).HasColumnName("vendorId");
        });

        modelBuilder.Entity<QuestionOption>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Questionnaire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Questionnaire_pkey");

            entity.ToTable("Questionnaire");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.LastModifiedBy).HasColumnName("lastModifiedBy");
            entity.Property(e => e.LastModifiedOn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastModifiedOn");
            entity.Property(e => e.QuestionNumber).HasColumnName("questionNumber");
            entity.Property(e => e.QuestionSet).HasColumnName("questionSet");
            entity.Property(e => e.QuestionType).HasColumnName("questionType");
            entity.Property(e => e.Weightage).HasColumnName("weightage");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EmailId).HasColumnName("emailId");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Vendor_pkey");

            entity.ToTable("Vendor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CompanyName).HasColumnName("companyName");
            entity.Property(e => e.ServiceDescription).HasColumnName("serviceDescription");
            entity.Property(e => e.ServiceOffering).HasColumnName("serviceOffering");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.YearInBusiness).HasColumnName("yearInBusiness");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Vendor)
                .HasForeignKey<Vendor>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Vendor_id_fkey");
        });

        modelBuilder.Entity<VendorAssessment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VendorAssessment");

            entity.Property(e => e.AssessmentId).HasColumnName("assessmentId");
            entity.Property(e => e.LastModifiedBy).HasColumnName("lastModifiedBy");
            entity.Property(e => e.LastModifiedOn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastModifiedOn");
            entity.Property(e => e.OptionTitle).HasColumnName("optionTitle");
            entity.Property(e => e.OptionValue).HasColumnName("optionValue");
            entity.Property(e => e.QuestionId).HasColumnName("questionId");
            entity.Property(e => e.QuestionNumber).HasColumnName("questionNumber");
            entity.Property(e => e.QuestionTitle).HasColumnName("questionTitle");
            entity.Property(e => e.VendorId).HasColumnName("vendorId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
