using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.Project
{
    public partial class intCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectDetails",
                columns: table => new
                {
                    PId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Project = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(8000)", nullable: false),
                    imageurl = table.Column<string>(type: "varchar(8000)", nullable: false),
                    docurl = table.Column<string>(type: "varchar(8000)", nullable: false),
                    Sourcename = table.Column<string>(type: "varchar(8000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetails", x => x.PId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDetails");
        }
    }
}
