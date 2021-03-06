﻿// <auto-generated />
using System;
using LibraryDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryDemo.Migrations
{
    [DbContext(typeof(LendingInfoDbContext))]
    [Migration("20190213070420_LendingInfo")]
    partial class LendingInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryDemo.Models.DomainModels.AppointmentOrLending", b =>
                {
                    b.Property<string>("BookId");

                    b.Property<string>("StudentId");

                    b.Property<DateTime?>("AppointingDateTime");

                    b.HasKey("BookId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("AppointmentOrLendings");
                });

            modelBuilder.Entity("LibraryDemo.Models.DomainModels.Book", b =>
                {
                    b.Property<string>("BarCode")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AppointedLatestTime");

                    b.Property<int>("BookshelfId");

                    b.Property<DateTime?>("BorrowTime");

                    b.Property<string>("FetchBookNumber");

                    b.Property<string>("ISBN");

                    b.Property<string>("KeeperId");

                    b.Property<string>("Location");

                    b.Property<DateTime?>("MatureTime");

                    b.Property<string>("Name");

                    b.Property<string>("Sort");

                    b.Property<int>("State");

                    b.HasKey("BarCode");

                    b.HasIndex("BookshelfId");

                    b.HasIndex("KeeperId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryDemo.Models.DomainModels.BookDetails", b =>
                {
                    b.Property<string>("ISBN")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("FetchBookNumber")
                        .IsRequired();

                    b.Property<byte[]>("ImageData");

                    b.Property<string>("ImageMimeType");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Press")
                        .IsRequired();

                    b.Property<DateTime>("PublishDateTime");

                    b.Property<string>("SoundCassettes");

                    b.Property<int>("Version");

                    b.HasKey("ISBN");

                    b.ToTable("BooksDetail");
                });

            modelBuilder.Entity("LibraryDemo.Models.DomainModels.Bookshelf", b =>
                {
                    b.Property<int>("BookshelfId");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("MaxFetchNumber")
                        .IsRequired();

                    b.Property<string>("MinFetchNumber")
                        .IsRequired();

                    b.Property<string>("Sort")
                        .IsRequired();

                    b.HasKey("BookshelfId");

                    b.ToTable("Bookshelves");
                });

            modelBuilder.Entity("LibraryDemo.Models.DomainModels.RecommendedBook", b =>
                {
                    b.Property<string>("ISBN")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Press")
                        .IsRequired();

                    b.Property<DateTime>("PublishDateTime");

                    b.Property<string>("SoundCassettes");

                    b.Property<int>("Version");

                    b.HasKey("ISBN");

                    b.ToTable("RecommendedBooks");
                });

            modelBuilder.Entity("LibraryDemo.Models.DomainModels.StudentInfo", b =>
                {
                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppointingBookBarCode");

                    b.Property<int>("Degree");

                    b.Property<decimal>("Fine");

                    b.Property<int>("MaxBooksNumber");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(14);

                    b.HasKey("UserName");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LibraryDemo.Models.DomainModels.AppointmentOrLending", b =>
                {
                    b.HasOne("LibraryDemo.Models.DomainModels.Book", "Book")
                        .WithMany("Appointments")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryDemo.Models.DomainModels.StudentInfo", "Student")
                        .WithMany("KeepingBooks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryDemo.Models.DomainModels.Book", b =>
                {
                    b.HasOne("LibraryDemo.Models.DomainModels.Bookshelf", "Bookshelf")
                        .WithMany("Books")
                        .HasForeignKey("BookshelfId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryDemo.Models.DomainModels.StudentInfo", "Keeper")
                        .WithMany()
                        .HasForeignKey("KeeperId");
                });
#pragma warning restore 612, 618
        }
    }
}
