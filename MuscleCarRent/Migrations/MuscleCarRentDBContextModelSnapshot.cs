﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MuscleCarRent.Data;

namespace MuscleCarRent.Migrations
{
    [DbContext(typeof(MuscleCarRentDBContext))]
    partial class MuscleCarRentDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MuscleCarRent.Models.AccessType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("AccessType");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccessTypeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DrivingLicense")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDrivingLicenseValid")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AccessTypeID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("MuscleCarRent.Models.BankCard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<short>("CVV")
                        .HasColumnType("smallint");

                    b.Property<string>("CardHolderFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AccountID")
                        .IsUnique();

                    b.ToTable("BankCard");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Car", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("BasePrice")
                        .HasColumnType("smallint");

                    b.Property<int>("BodyType")
                        .HasColumnType("int");

                    b.Property<int>("Brand")
                        .HasColumnType("int");

                    b.Property<int>("CarTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverID")
                        .HasColumnType("int");

                    b.Property<string>("Engine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFavourite")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPopular")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NeedDriver")
                        .HasColumnType("bit");

                    b.Property<byte>("NumberOfSeats")
                        .HasColumnType("tinyint");

                    b.Property<short>("Power")
                        .HasColumnType("smallint");

                    b.Property<byte>("PricePerHour")
                        .HasColumnType("tinyint");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("Surcharge")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("CarTypeID");

                    b.HasIndex("DriverID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("MuscleCarRent.Models.CarType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RentType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("CarType");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Driver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Image", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<bool>("HasBankCard")
                        .HasColumnType("bit");

                    b.Property<byte>("HourAmmount")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("TotalPrice")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("AccountID");

                    b.HasIndex("CarID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MuscleCarRent.Models.OrderedDate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<int?>("DriverID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CarID");

                    b.HasIndex("DriverID");

                    b.ToTable("OrderedDates");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Promotion", b =>
                {
                    b.HasBaseType("MuscleCarRent.Models.Order");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("PromotionType")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("MuscleCarRent.Models.PersonalPromotion", b =>
                {
                    b.HasBaseType("MuscleCarRent.Models.Promotion");

                    b.ToTable("PersonalPromotion");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Account", b =>
                {
                    b.HasOne("MuscleCarRent.Models.AccessType", "AccessType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccessTypeID");

                    b.Navigation("AccessType");
                });

            modelBuilder.Entity("MuscleCarRent.Models.BankCard", b =>
                {
                    b.HasOne("MuscleCarRent.Models.Account", "Account")
                        .WithOne("BankCard")
                        .HasForeignKey("MuscleCarRent.Models.BankCard", "AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Car", b =>
                {
                    b.HasOne("MuscleCarRent.Models.CarType", "CarType")
                        .WithMany("Cars")
                        .HasForeignKey("CarTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MuscleCarRent.Models.Driver", "Driver")
                        .WithMany("Cars")
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarType");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Image", b =>
                {
                    b.HasOne("MuscleCarRent.Models.Car", "Car")
                        .WithMany("Images")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Order", b =>
                {
                    b.HasOne("MuscleCarRent.Models.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MuscleCarRent.Models.Car", "Car")
                        .WithMany("Orders")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("MuscleCarRent.Models.OrderedDate", b =>
                {
                    b.HasOne("MuscleCarRent.Models.Car", "Car")
                        .WithMany("OrderedDates")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MuscleCarRent.Models.Driver", null)
                        .WithMany("OrderedDates")
                        .HasForeignKey("DriverID");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Promotion", b =>
                {
                    b.HasOne("MuscleCarRent.Models.Order", null)
                        .WithOne()
                        .HasForeignKey("MuscleCarRent.Models.Promotion", "ID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MuscleCarRent.Models.PersonalPromotion", b =>
                {
                    b.HasOne("MuscleCarRent.Models.Promotion", null)
                        .WithOne()
                        .HasForeignKey("MuscleCarRent.Models.PersonalPromotion", "ID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MuscleCarRent.Models.AccessType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Account", b =>
                {
                    b.Navigation("BankCard");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Car", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("OrderedDates");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MuscleCarRent.Models.CarType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("MuscleCarRent.Models.Driver", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("OrderedDates");
                });
#pragma warning restore 612, 618
        }
    }
}