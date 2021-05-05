using Microsoft.EntityFrameworkCore.Migrations;

namespace MuscleCarRent.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalPromotion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalPromotion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalPromotion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonalPromotion_Promotion_ID",
                        column: x => x.ID,
                        principalTable: "Promotion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
        }
    }
}
