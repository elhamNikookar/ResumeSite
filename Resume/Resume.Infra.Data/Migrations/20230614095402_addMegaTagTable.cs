using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Infra.Data.Migrations
{
    public partial class addMegaTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetaTagsSeo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTime = table.Column<int>(type: "int", nullable: false),
                    OgTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgLocale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaTagsSeo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetaTagsSeo");
        }
    }
}
