using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Infra.Data.Migrations
{
    public partial class AddCustomerFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_thingIDos",
                table: "thingIDos");

            migrationBuilder.RenameTable(
                name: "thingIDos",
                newName: "ThingIDos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThingIDos",
                table: "ThingIDos",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "customerFeedbacks",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerFeedbacks", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThingIDos",
                table: "ThingIDos");

            migrationBuilder.RenameTable(
                name: "ThingIDos",
                newName: "thingIDos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_thingIDos",
                table: "thingIDos",
                column: "ID");
        }
    }
}
