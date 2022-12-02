﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductCustomers.Models;

#nullable disable

namespace FinalProjectBaiBeauty.Migrations
{
    [DbContext(typeof(pcDbContext))]
    [Migration("20221202023923_InitalCreate")]
    partial class InitalCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("ProductCustomers.Models.Customer", b =>
                {
                    b.Property<int>("customerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.HasKey("customerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ProductCustomers.Models.Order", b =>
                {
                    b.Property<int>("productID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("customerID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("orderNum")
                        .HasColumnType("INTEGER");

                    b.HasKey("productID", "customerID");

                    b.HasIndex("customerID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ProductCustomers.Models.Product", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("pName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("pPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("productID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ProductCustomers.Models.Order", b =>
                {
                    b.HasOne("ProductCustomers.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductCustomers.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductCustomers.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ProductCustomers.Models.Product", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}