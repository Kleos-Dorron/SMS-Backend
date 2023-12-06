using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SMS_Backend.Models;

public partial class SmsDbContext : DbContext
{
    public SmsDbContext()
    {
    }

    public SmsDbContext(DbContextOptions<SmsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllocateClassroom> AllocateClassrooms { get; set; }

    public virtual DbSet<AllocateSubject> AllocateSubjects { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Check DbContextOptionsBuilder instance is already configured. 
        if (!optionsBuilder.IsConfigured)
        {
            // Create a new instance of ConfigurationBuilder to read the configuration settings from the appsettings.json file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())// Set the base path for the configuration file to the current working directory
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true); // Add the appsettings.json file as a configuration source, with optional loading and automatic reloading when the file changes

            // Build the configuration object from the configuration sources
            IConfigurationRoot configuration = builder.Build();

            // Use the connection string named "DefaultConnection" from the configuration object to configure the DbContext options
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllocateClassroom>(entity =>
        {
            entity.HasKey(e => e.AllocateClassroomId).HasName("PK__Allocate__8D6E393903CE73B6");

            entity.Property(e => e.AllocateClassroomId).HasColumnName("AllocateClassroomID");
            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Classroom).WithMany(p => p.AllocateClassrooms)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK__AllocateC__Class__5165187F");

            entity.HasOne(d => d.Teacher).WithMany(p => p.AllocateClassrooms)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__AllocateC__Teach__5070F446");
        });

        modelBuilder.Entity<AllocateSubject>(entity =>
        {
            entity.HasKey(e => e.AllocateSubjectId).HasName("PK__Allocate__1B5A4110D56A44DA");

            entity.Property(e => e.AllocateSubjectId).HasColumnName("AllocateSubjectID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Subject).WithMany(p => p.AllocateSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__AllocateS__Subje__5535A963");

            entity.HasOne(d => d.Teacher).WithMany(p => p.AllocateSubjects)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__AllocateS__Teach__5441852A");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.ClassroomId).HasName("PK__Classroo__11618E8ADDEB7BA4");

            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.ClassroomName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A79C6C4F2C7");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Classroom).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassroomId)
                .HasConstraintName("FK__Students__Classr__4D94879B");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA388C5E08D62");

            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__EDF25944C20FCAAF");

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
