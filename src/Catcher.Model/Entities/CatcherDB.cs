using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Catcher.Model.Entities
{
    public partial class CatcherDb : DbContext
    {
        public CatcherDb()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;port=3300;database=catcherschema;user=tester;password=chicken1234", ServerVersion.Parse("8.0.29-mysql"));
        }

        public CatcherDb(DbContextOptions<CatcherDb> options)
            : base(options)
        {
        }

        public virtual DbSet<MyUser> MyUsers { get; set; } = null!;
        public virtual DbSet<ErrorTitle> ErrorTitle { get; set; } = null!;
        public virtual DbSet<ErrorBody> ErrorBody { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<MyUser>(entity =>
            {
                entity.ToTable("my_user");

                entity.Property(e => e.Id).HasMaxLength(150);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Password).HasMaxLength(150);

                entity.Property(e => e.Role).HasMaxLength(10);
            });

            modelBuilder.Entity<ErrorTitle>(entity =>
            {
                entity.ToTable("error_title");

                entity.Property(e => e.Id).HasMaxLength(150);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.TypeCode).HasMaxLength(50);

                entity.Property(e => e.ErrorDate).HasColumnType("datetime");

                entity.Property(e => e.Memo).HasMaxLength(150);
            });

            modelBuilder.Entity<ErrorBody>(entity =>
            {
                entity.ToTable("error_body");

                entity.Property(e => e.Id).HasMaxLength(150);

                entity.Property(e => e.TypeCode).HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Qty);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
