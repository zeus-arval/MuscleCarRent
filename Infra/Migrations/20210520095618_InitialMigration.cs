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
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    CardHolderFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<short>(type: "smallint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarTypes",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentTypeEnum = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CarID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderedDates",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedDates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<short>(type: "smallint", nullable: false),
                    HourAmmount = table.Column<byte>(type: "tinyint", nullable: false),
                    HasBankCard = table.Column<bool>(type: "bit", nullable: false),
                    CarID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrivingLicense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDrivingLicenseValid = table.Column<bool>(type: "bit", nullable: true),
                    AccessTypeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankCardID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessTypeDataID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_AccessTypes_AccessTypeDataID",
                        column: x => x.AccessTypeDataID,
                        principalTable: "AccessTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    Power = table.Column<short>(type: "smallint", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<short>(type: "smallint", nullable: false),
                    PricePerHour = table.Column<byte>(type: "tinyint", nullable: false),
                    NumberOfSeats = table.Column<byte>(type: "tinyint", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeedDriver = table.Column<bool>(type: "bit", nullable: false),
                    Surcharge = table.Column<short>(type: "smallint", nullable: true),
                    DriverID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarTypeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyType = table.Column<int>(type: "int", nullable: false),
                    CarTypeDataID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cars_CarTypes_CarTypeDataID",
                        column: x => x.CarTypeDataID,
                        principalTable: "CarTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    PromotionTypeEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Promotions_Orders_ID",
                        column: x => x.ID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccessTypeDataID",
                table: "Accounts",
                column: "AccessTypeDataID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarTypeDataID",
                table: "Cars",
                column: "CarTypeDataID");
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
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderedDates");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "AccessTypes");

            migrationBuilder.DropTable(
                name: "CarTypes");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
