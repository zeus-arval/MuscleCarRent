using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<short>(type: "smallint", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CardHolderFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Engine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    NeedDriver = table.Column<bool>(type: "bit", nullable: false),
                    Power = table.Column<short>(type: "smallint", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Surcharge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfSeats = table.Column<byte>(type: "tinyint", nullable: false),
                    CarTypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CarTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DriverId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DriverFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Brand = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    BodyType = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentTypeEnum = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CarModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CarId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderedDates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CarId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HourAmmount = table.Column<byte>(type: "tinyint", nullable: false),
                    HasBankCard = table.Column<bool>(type: "bit", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CarId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PromotionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PromotionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    PromotionTypeEnum = table.Column<int>(type: "int", nullable: false),
                    AccountFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CarModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CarId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersonalPhoto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DrivingLicensePhoto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDrivingLicenseValid = table.Column<bool>(type: "bit", nullable: true),
                    AccessTypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccessTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankCardId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankCardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccessTypeDataId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccessTypes_AccessTypeDataId",
                        column: x => x.AccessTypeDataId,
                        principalTable: "AccessTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccessTypeDataId",
                table: "Accounts",
                column: "AccessTypeDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarTypes");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderedDates");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "AccessTypes");
        }
    }
}
