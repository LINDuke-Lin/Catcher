using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Catcher.Model.Entities
{
    public partial class CatcherDB : DbContext
    {
        public CatcherDB()
        {
        }

        public CatcherDB(DbContextOptions<CatcherDB> options)
            : base(options)
        {
        }

        public virtual DbSet<MyUser> MyUsers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<MyUser>(entity =>
            {
                entity.ToTable("my_user");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
