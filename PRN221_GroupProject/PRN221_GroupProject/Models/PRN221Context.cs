using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRN221_GroupProject.Models
{
    public partial class PRN221Context : DbContext
    {
        public PRN221Context()
        {
        }

        public PRN221Context(DbContextOptions<PRN221Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<MyCourse> MyCourses { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("StringDB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.CourseDescription)
                    .HasMaxLength(100)
                    .HasColumnName("courseDescription")
                    .IsFixedLength();

                entity.Property(e => e.CourseName)
                    .HasMaxLength(10)
                    .HasColumnName("courseName")
                    .IsFixedLength();

                entity.Property(e => e.CoursePrice)
                    .HasColumnType("money")
                    .HasColumnName("coursePrice");

                entity.Property(e => e.CourseTime).HasColumnName("courseTime");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .HasColumnName("image");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.LessonId).HasColumnName("lessonId");

                entity.Property(e => e.Content)
                    .HasMaxLength(100)
                    .HasColumnName("content");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Courses");
            });

            modelBuilder.Entity<MyCourse>(entity =>
            {
                entity.ToTable("MyCourse");

                entity.Property(e => e.MycourseId).HasColumnName("mycourseId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.MyCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyCourse_Courses");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MyCourses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MyCourse_Users");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.RateId);

                entity.ToTable("Rating");

                entity.Property(e => e.RateId).HasColumnName("rateId");

                entity.Property(e => e.Comment)
                    .HasMaxLength(200)
                    .HasColumnName("comment")
                    .IsFixedLength();

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Courses");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rating_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(20)
                    .HasColumnName("userEmail")
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .HasColumnName("userName")
                    .IsFixedLength();

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(10)
                    .HasColumnName("userPassword")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
