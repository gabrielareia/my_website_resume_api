using Microsoft.EntityFrameworkCore.Migrations;

namespace GabrielAreiaAPI.Migrations
{
    public partial class OrderItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Goals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Experiences",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Achievements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Abilities",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Abilities");
        }
    }
}
