using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations.KeyWord
{
    public partial class My3Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyWordDetails",
                columns: table => new
                {
                    KWId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KeyWord = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(8000)", nullable: false),
                    imageurl = table.Column<string>(type: "varchar(8000)", nullable: false),
                    docurl = table.Column<string>(type: "varchar(8000)", nullable: false),
                    Sourcename = table.Column<string>(type: "varchar(8000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyWordDetails", x => x.KWId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyWordDetails");
        }
    }
}
