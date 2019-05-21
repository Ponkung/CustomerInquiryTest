﻿// <auto-generated />
using System;
using CustomerInquiryTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerInquiryTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerInquiryTest.Data.Models.Customers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(25);

                    b.Property<int>("CustomerId");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(30);

                    b.Property<int>("MobileNo");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerInquiryTest.Data.Models.Transactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(3);

                    b.Property<Guid?>("CustomersId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<int>("TransactionId");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CustomerInquiryTest.Data.Models.Transactions", b =>
                {
                    b.HasOne("CustomerInquiryTest.Data.Models.Customers")
                        .WithMany("Transactions")
                        .HasForeignKey("CustomersId");
                });
#pragma warning restore 612, 618
        }
    }
}
