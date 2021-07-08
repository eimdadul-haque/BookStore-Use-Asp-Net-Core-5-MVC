﻿// <auto-generated />
using System;
using BookStore_Use_Asp_Net_Core_5_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore_Use_Asp_Net_Core_5_MVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210708080746_language and category table added")]
    partial class languageandcategorytableadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStore_Use_Asp_Net_Core_5_MVC.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPage")
                        .HasColumnType("int");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<int>("languageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("categoryId");

                    b.HasIndex("languageId");

                    b.ToTable("books");
                });

            modelBuilder.Entity("BookStore_Use_Asp_Net_Core_5_MVC.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("BookStore_Use_Asp_Net_Core_5_MVC.Models.ImageGallary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("ImageGallary");
                });

            modelBuilder.Entity("BookStore_Use_Asp_Net_Core_5_MVC.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("BookStore_Use_Asp_Net_Core_5_MVC.Models.Book", b =>
                {
                    b.HasOne("BookStore_Use_Asp_Net_Core_5_MVC.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore_Use_Asp_Net_Core_5_MVC.Models.Language", "language")
                        .WithMany()
                        .HasForeignKey("languageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("language");
                });

            modelBuilder.Entity("BookStore_Use_Asp_Net_Core_5_MVC.Models.ImageGallary", b =>
                {
                    b.HasOne("BookStore_Use_Asp_Net_Core_5_MVC.Models.Book", null)
                        .WithMany("ImgeUrl")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("BookStore_Use_Asp_Net_Core_5_MVC.Models.Book", b =>
                {
                    b.Navigation("ImgeUrl");
                });
#pragma warning restore 612, 618
        }
    }
}
