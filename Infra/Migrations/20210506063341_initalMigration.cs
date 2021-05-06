using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class initalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessType",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BankCard",
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
                    table.PrimaryKey("PK_BankCard", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrivingLicense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDrivingLicenseValid = table.Column<bool>(type: "bit", nullable: true),
                    BankCardID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccessTypeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Account_AccessType_AccessTypeID",
                        column: x => x.AccessTypeID,
                        principalTable: "AccessType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_BankCard_BankCardID",
                        column: x => x.BankCardID,
                        principalTable: "BankCard",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    Power = table.Column<short>(type: "smallint", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<short>(type: "smallint", nullable: false),
                    PricePerHour = table.Column<byte>(type: "tinyint", nullable: false),
                    NumberOfSeats = table.Column<byte>(type: "tinyint", nullable: false),
                    Engine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NeedDriver = table.Column<bool>(type: "bit", nullable: false),
                    Surcharge = table.Column<short>(type: "smallint", nullable: true),
                    DriverID = table.Column<int>(type: "int", nullable: false),
                    CarTypeID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarTypeID = table.Column<int>(type: "int", nullable: false),
                    BodyType = table.Column<int>(type: "int", nullable: false),
                    DriverID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Car_CarType_CarTypeID1",
                        column: x => x.CarTypeID1,
                        principalTable: "CarType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Car_Driver_DriverID1",
                        column: x => x.DriverID1,
                        principalTable: "Driver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Image_Car_CarID1",
                        column: x => x.CarID1,
                        principalTable: "Car",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<short>(type: "smallint", nullable: false),
                    HourAmmount = table.Column<byte>(type: "tinyint", nullable: false),
                    HasBankCard = table.Column<bool>(type: "bit", nullable: false),
                    CarID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Account_AccountID1",
                        column: x => x.AccountID1,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Car_CarID1",
                        column: x => x.CarID1,
                        principalTable: "Car",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderedDates",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    CarID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedDates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderedDates_Car_CarID1",
                        column: x => x.CarID1,
                        principalTable: "Car",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    PromotionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Promotion_Order_ID",
                        column: x => x.ID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccessTypeID",
                table: "Account",
                column: "AccessTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_BankCardID",
                table: "Account",
                column: "BankCardID",
                unique: true,
                filter: "[BankCardID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarTypeID1",
                table: "Car",
                column: "CarTypeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Car_DriverID1",
                table: "Car",
                column: "DriverID1");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CarID1",
                table: "Image",
                column: "CarID1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AccountID1",
                table: "Order",
                column: "AccountID1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CarID1",
                table: "Order",
                column: "CarID1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedDates_CarID1",
                table: "OrderedDates",
                column: "CarID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "OrderedDates");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "AccessType");

            migrationBuilder.DropTable(
                name: "BankCard");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropTable(
                name: "Driver");
        }
    }
}
