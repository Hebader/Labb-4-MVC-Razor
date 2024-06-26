﻿// <auto-generated />
using Labb_4___MVC___Razor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb_4___MVC___Razor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb_4___MVC___Razor.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("bit");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            BookTitle = "The Ghost",
                            IsBorrowed = true
                        },
                        new
                        {
                            BookId = 2,
                            BookTitle = "Forgotten",
                            IsBorrowed = false
                        });
                });

            modelBuilder.Entity("Labb_4___MVC___Razor.Models.BookCustomer", b =>
                {
                    b.Property<int>("BookCustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookCustomerId"));

                    b.Property<int>("FkBookId")
                        .HasColumnType("int");

                    b.Property<int>("FkCustomerId")
                        .HasColumnType("int");

                    b.HasKey("BookCustomerId");

                    b.HasIndex("FkBookId");

                    b.HasIndex("FkCustomerId");

                    b.ToTable("BookCustomers");

                    b.HasData(
                        new
                        {
                            BookCustomerId = 1,
                            FkBookId = 1,
                            FkCustomerId = 1
                        },
                        new
                        {
                            BookCustomerId = 2,
                            FkBookId = 2,
                            FkCustomerId = 2
                        });
                });

            modelBuilder.Entity("Labb_4___MVC___Razor.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerName = "Anna Persson",
                            Email = "anna.persson@example.com",
                            PhoneNumber = "0768839487"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerName = "Peter Johannson",
                            Email = "peter.johansson@example.com",
                            PhoneNumber = "0728839748"
                        });
                });

            modelBuilder.Entity("Labb_4___MVC___Razor.Models.BookCustomer", b =>
                {
                    b.HasOne("Labb_4___MVC___Razor.Models.Book", "Book")
                        .WithMany("Borrowers")
                        .HasForeignKey("FkBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb_4___MVC___Razor.Models.Customer", "Customer")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("FkCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Labb_4___MVC___Razor.Models.Book", b =>
                {
                    b.Navigation("Borrowers");
                });

            modelBuilder.Entity("Labb_4___MVC___Razor.Models.Customer", b =>
                {
                    b.Navigation("BorrowedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
