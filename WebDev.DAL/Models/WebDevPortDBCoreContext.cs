using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebDev.DAL.Models
{
    public partial class WebDevPortDBCoreContext : DbContext
    {
        public WebDevPortDBCoreContext()
        {
        }

        public WebDevPortDBCoreContext(DbContextOptions<WebDevPortDBCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BugTracker> BugTrackers { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WebDevPortDBCore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BugTracker>(entity =>
            {
                entity.HasKey(e => e.BugId)
                    .HasName("pk_BugTracker_BugId");

                entity.ToTable("BugTracker");

                entity.Property(e => e.BugId)
                    .HasColumnType("numeric(6, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BugDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.BugName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.GitUrl).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnType("numeric(3, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BugTrackers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_BugTracker_UserId");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.HasIndex(e => e.ProjectName, "uq_Project_ProjectName")
                    .IsUnique();

                entity.Property(e => e.ProjectId)
                    .HasColumnType("numeric(4, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.GitUrl).IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectVersion).HasColumnType("numeric(3, 2)");

                entity.Property(e => e.UserId).HasColumnType("numeric(3, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_Project_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.EmailId, "uq_User_UserEmailId")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "uq_User_Username")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnType("numeric(3, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmailId)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
