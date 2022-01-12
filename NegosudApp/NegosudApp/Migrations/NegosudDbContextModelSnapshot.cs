﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NegosudApp.Migrations;

namespace NegosudApp.Migrations
{
    [DbContext(typeof(NegosudDbContext))]
    partial class NegosudDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NegosudApp.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("StreetNumber")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("WayType")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("NegosudApp.Models.AddressUser", b =>
                {
                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("Address_Id");

                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("Users_Id");

                    b.HasKey("AddressId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AddressUsers");
                });

            modelBuilder.Entity("NegosudApp.Models.Alcohol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Range")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Alcohol");
                });

            modelBuilder.Entity("NegosudApp.Models.Client", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("Users_Id");

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("Address_Id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UsersId")
                        .HasName("PK__Client__EB68292D266D1814");

                    b.HasIndex("AddressId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("NegosudApp.Models.Employee", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("Users_Id");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UsersId")
                        .HasName("PK__Employee__EB68292DFF14A48E");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("NegosudApp.Models.GrapeRate", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_Id");

                    b.Property<int>("GrapeVarietyId")
                        .HasColumnType("int")
                        .HasColumnName("GrapeVariety_Id");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "GrapeVarietyId");

                    b.HasIndex("GrapeVarietyId");

                    b.ToTable("GrapeRate");
                });

            modelBuilder.Entity("NegosudApp.Models.GrapeVariety", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("GrapeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("GrapeVariety");
                });

            modelBuilder.Entity("NegosudApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_Id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("NegosudApp.Models.OrderHistory", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int")
                        .HasColumnName("Users_Id");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_Id");

                    b.HasKey("UsersId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderHistory");
                });

            modelBuilder.Entity("NegosudApp.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlcoholId")
                        .HasColumnType("int")
                        .HasColumnName("Alcohol_Id");

                    b.Property<bool?>("Cubitainer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Medal")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("Supplier_Id");

                    b.Property<int?>("YearOrAge")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlcoholId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("NegosudApp.Models.ProductOrdered", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("Product_Id");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_Id");

                    b.HasKey("ProductId", "OrderId")
                        .HasName("PK_ProductOrder");

                    b.HasIndex("OrderId");

                    b.ToTable("ProductOrdered");
                });

            modelBuilder.Entity("NegosudApp.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("Address_Id");

                    b.Property<string>("ApeNaf")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("APE_NAF");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Legal")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Siret")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("SIRET");

                    b.Property<string>("SocialReason")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Tva")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("TVA");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("NegosudApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("HashPassword")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NegosudApp.Models.AddressUser", b =>
                {
                    b.HasOne("NegosudApp.Models.Address", "Address")
                        .WithMany("AddressUsers")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_AddressUsers_Address_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NegosudApp.Models.User", "Users")
                        .WithMany("AddressUsers")
                        .HasForeignKey("UsersId")
                        .HasConstraintName("FK_AddressUsers_Users_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("NegosudApp.Models.Client", b =>
                {
                    b.HasOne("NegosudApp.Models.Address", "Address")
                        .WithMany("Clients")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_Client_Address_Id")
                        .IsRequired();

                    b.HasOne("NegosudApp.Models.User", "Users")
                        .WithOne("Client")
                        .HasForeignKey("NegosudApp.Models.Client", "UsersId")
                        .HasConstraintName("FK_Client_User_Id")
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("NegosudApp.Models.Employee", b =>
                {
                    b.HasOne("NegosudApp.Models.User", "Users")
                        .WithOne("Employee")
                        .HasForeignKey("NegosudApp.Models.Employee", "UsersId")
                        .HasConstraintName("FK_Employee_User_Id")
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("NegosudApp.Models.GrapeRate", b =>
                {
                    b.HasOne("NegosudApp.Models.GrapeVariety", "GrapeVariety")
                        .WithMany("GrapeRates")
                        .HasForeignKey("GrapeVarietyId")
                        .HasConstraintName("FK_GrapeRate_GraepVariety_Id")
                        .IsRequired();

                    b.HasOne("NegosudApp.Models.Product", "Product")
                        .WithMany("GrapeRates")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_GrapeRate_Product_Id")
                        .IsRequired();

                    b.Navigation("GrapeVariety");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NegosudApp.Models.Order", b =>
                {
                    b.HasOne("NegosudApp.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Order_Product_Id")
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NegosudApp.Models.OrderHistory", b =>
                {
                    b.HasOne("NegosudApp.Models.Order", "Order")
                        .WithMany("OrderHistories")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("PK_OrderHistory_Order_Id")
                        .IsRequired();

                    b.HasOne("NegosudApp.Models.User", "Users")
                        .WithMany("OrderHistories")
                        .HasForeignKey("UsersId")
                        .HasConstraintName("PK_OrderHistory_Users_Id")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("NegosudApp.Models.Product", b =>
                {
                    b.HasOne("NegosudApp.Models.Alcohol", "Alcohol")
                        .WithMany("Products")
                        .HasForeignKey("AlcoholId")
                        .HasConstraintName("FK_Product_Alcohol_Id")
                        .IsRequired();

                    b.HasOne("NegosudApp.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK_Product_Supplier_Id")
                        .IsRequired();

                    b.Navigation("Alcohol");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("NegosudApp.Models.ProductOrdered", b =>
                {
                    b.HasOne("NegosudApp.Models.Order", "Order")
                        .WithMany("ProductOrdereds")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_ProdOrd_Order_Id")
                        .IsRequired();

                    b.HasOne("NegosudApp.Models.Product", "Product")
                        .WithMany("ProductOrdereds")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProdOrd_Product_Id")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NegosudApp.Models.Supplier", b =>
                {
                    b.HasOne("NegosudApp.Models.Address", "Address")
                        .WithMany("Suppliers")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_Supplier_AddressId")
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("NegosudApp.Models.Address", b =>
                {
                    b.Navigation("AddressUsers");

                    b.Navigation("Clients");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("NegosudApp.Models.Alcohol", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NegosudApp.Models.GrapeVariety", b =>
                {
                    b.Navigation("GrapeRates");
                });

            modelBuilder.Entity("NegosudApp.Models.Order", b =>
                {
                    b.Navigation("OrderHistories");

                    b.Navigation("ProductOrdereds");
                });

            modelBuilder.Entity("NegosudApp.Models.Product", b =>
                {
                    b.Navigation("GrapeRates");

                    b.Navigation("Orders");

                    b.Navigation("ProductOrdereds");
                });

            modelBuilder.Entity("NegosudApp.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NegosudApp.Models.User", b =>
                {
                    b.Navigation("AddressUsers");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("OrderHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
