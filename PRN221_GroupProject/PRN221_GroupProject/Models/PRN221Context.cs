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
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("StringDB"));

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
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasColumnName("totalPrice");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_Id");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Courses");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Orders");
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
