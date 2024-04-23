﻿// <auto-generated />
using System;
using E_CommerceMVCApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_CommerceMVCApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("E_CommerceMVCApi.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_CommerceMVCApi.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasMaxLength(50)
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("E_CommerceMVCApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("E_CommerceMVCApi.Models.Order", b =>
                {
                    b.HasOne("E_CommerceMVCApi.Models.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("E_CommerceMVCApi.Models.Product", b =>
                {
                    b.HasOne("E_CommerceMVCApi.Models.Order", null)
                        .WithMany("ProductList")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("E_CommerceMVCApi.Models.Order", b =>
                {
                    b.Navigation("ProductList");
                });

            modelBuilder.Entity("E_CommerceMVCApi.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
