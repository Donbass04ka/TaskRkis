using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace sisTask
{
    public partial class sisTaskContext : DbContext
    {
        public sisTaskContext()
        {
        }

        public sisTaskContext(DbContextOptions<sisTaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StatusTask> StatusTasks { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=sisTask;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusTask>(entity =>
            {
                entity.ToTable("StatusTask");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Writing)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.TaskIdAuthorNavigations)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_User2");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_StatusTask1");

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.TaskIdWorkerNavigations)
                    .HasForeignKey(d => d.IdWorker)
                    .HasConstraintName("FK_Task_User1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberPhone)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patric)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
