﻿// <auto-generated />
using System;
using DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAnnotations.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAnnotations.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("AuthorId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("DataAnnotations.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<double>("PricePerUnit")
                        .IsConcurrencyToken()
                        .HasColumnType("float");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("DataAnnotations.Book", b =>
                {
                    b.HasOne("DataAnnotations.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
