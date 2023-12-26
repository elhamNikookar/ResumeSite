using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Infra.Data.Migrations
{
    public partial class newDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "order",
                table: "ThingIDos",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Orde",
                table: "CustomerLogos",
                newName: "Order");

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "ThingIDos",
                newName: "order");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "CustomerLogos",
                newName: "Orde");
        }
    }
}
