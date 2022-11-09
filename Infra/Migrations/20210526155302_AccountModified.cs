using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class AccountModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccessTypes_AccessTypeDataId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccessTypeDataId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccessTypeDataId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "DrivingLicensePhoto",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PersonalPhoto",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Drivers",
                newName: "PersonPhoto");

            migrationBuilder.RenameColumn(
                name: "RentTypeEnum",
                table: "CarTypes",
                newName: "RentType");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Accounts",
                newName: "PersonPhoto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonPhoto",
                table: "Drivers",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "RentType",
                table: "CarTypes",
                newName: "RentTypeEnum");

            migrationBuilder.RenameColumn(
                name: "PersonPhoto",
                table: "Accounts",
                newName: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "AccessTypeDataId",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DrivingLicensePhoto",
                table: "Accounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalPhoto",
                table: "Accounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccessTypeDataId",
                table: "Accounts",
                column: "AccessTypeDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccessTypes_AccessTypeDataId",
                table: "Accounts",
                column: "AccessTypeDataId",
                principalTable: "AccessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
