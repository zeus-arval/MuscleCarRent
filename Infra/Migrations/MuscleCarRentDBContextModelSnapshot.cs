﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MuscleCarRentProject.Infra;

namespace Infra.Migrations
{
    [DbContext(typeof(MuscleCarRentDBContext))]
    partial class MuscleCarRentDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MuscleCarRentProject.Data.AccessTypeData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ID");

                    b.ToTable("AccessTypes");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.AccountData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccessTypeDataID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccessTypeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankCardID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("DrivingLicense")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsDrivingLicenseValid")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AccessTypeDataID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.BankCardData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("CVV")
                        .HasColumnType("smallint");

                    b.Property<string>("CardHolderFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ID");

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.CarData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short>("BasePrice")
                        .HasColumnType("smallint");

                    b.Property<int>("BodyType")
                        .HasColumnType("int");

                    b.Property<int>("Brand")
                        .HasColumnType("int");

                    b.Property<string>("CarTypeDataID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarTypeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("DriverID")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("Surcharge")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("CarTypeDataID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.CarTypeData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RentTypeEnum")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ID");

                    b.ToTable("CarTypes");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.DriverData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ID");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.ImageData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.OrderData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasBankCard")
                        .HasColumnType("bit");

                    b.Property<byte>("HourAmmount")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<short>("TotalPrice")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.OrderedDateData", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("ID");

                    b.ToTable("OrderedDates");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.PromotionData", b =>
                {
                    b.HasBaseType("MuscleCarRentProject.Data.OrderData");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("PromotionTypeEnum")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.AccountData", b =>
                {
                    b.HasOne("MuscleCarRentProject.Data.AccessTypeData", null)
                        .WithMany("Accounts")
                        .HasForeignKey("AccessTypeDataID");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.CarData", b =>
                {
                    b.HasOne("MuscleCarRentProject.Data.CarTypeData", null)
                        .WithMany("Cars")
                        .HasForeignKey("CarTypeDataID");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.PromotionData", b =>
                {
                    b.HasOne("MuscleCarRentProject.Data.OrderData", null)
                        .WithOne()
                        .HasForeignKey("MuscleCarRentProject.Data.PromotionData", "ID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.AccessTypeData", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("MuscleCarRentProject.Data.CarTypeData", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
