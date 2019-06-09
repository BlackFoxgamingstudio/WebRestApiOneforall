using Microsoft.EntityFrameworkCore.Migrations;

namespace test2.Migrations
{
    public partial class Next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sourcename",
                table: "QuizDetails",
                type: "varchar(8000)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sourcename",
                table: "QuizDetails");
        }
    }
}
