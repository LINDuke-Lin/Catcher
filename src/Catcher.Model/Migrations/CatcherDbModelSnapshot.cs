﻿// <auto-generated />
using System;
using Catcher.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catcher.Model.Migrations
{
    [DbContext(typeof(CatcherDb))]
    partial class CatcherDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Catcher.Model.Entities.ErrorBody", b =>
                {
                    b.Property<string>("TypeCode")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ErrorTitleId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Type"), "utf8mb3");

                    b.HasKey("TypeCode");

                    b.HasIndex("ErrorTitleId");

                    b.ToTable("error_body", (string)null);
                });

            modelBuilder.Entity("Catcher.Model.Entities.ErrorTitle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ErrorDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Memo")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TypeCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ErrorTitle");
                });

            modelBuilder.Entity("Catcher.Model.Entities.MyUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MyUsers");
                });

            modelBuilder.Entity("Catcher.Model.Entities.ErrorBody", b =>
                {
                    b.HasOne("Catcher.Model.Entities.ErrorTitle", "ErrorTitle")
                        .WithMany("ErrorBodys")
                        .HasForeignKey("ErrorTitleId");

                    b.Navigation("ErrorTitle");
                });

            modelBuilder.Entity("Catcher.Model.Entities.ErrorTitle", b =>
                {
                    b.Navigation("ErrorBodys");
                });
#pragma warning restore 612, 618
        }
    }
}
