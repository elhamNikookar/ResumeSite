using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Infra.Data.Migrations
{
    public partial class adOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order",
                table: "thingIDos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order",
                table: "thingIDos");
        }
    }
}
