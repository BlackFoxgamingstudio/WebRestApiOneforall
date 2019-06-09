using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace test2.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizDetails",
                columns: table => new
                {
                    QId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(8000)", nullable: false),
                    imageurl = table.Column<string>(type: "varchar(8000)", nullable: false),
                    docurl = table.Column<string>(type: "varchar(8000)", nullable: false),
                    choices1 = table.Column<string>(type: "varchar(8000)", nullable: false),
                    choices2 = table.Column<string>(type: "varchar(8000)", nullable: false),
                    choices3 = table.Column<string>(type: "varchar(8000)", nullable: false),
                    choices4 = table.Column<string>(type: "varchar(8000)", nullable: false),
                    choices5 = table.Column<string>(type: "varchar(8000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizDetails", x => x.QId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizDetails");
        }
    }
}
