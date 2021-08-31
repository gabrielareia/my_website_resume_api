using Microsoft.EntityFrameworkCore.Migrations;

namespace GabrielAreiaAPI.Migrations
{
    public partial class ResumeLanguageSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Resumes",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Resumes");
        }
    }
}
