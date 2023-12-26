using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Infra.Data.Migrations
{
    public partial class AddCustomerLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_customerFeedbacks",
                table: "customerFeedbacks");

            migrationBuilder.RenameTable(
                name: "customerFeedbacks",
                newName: "CustomerFeedbacks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerFeedbacks",
                table: "CustomerFeedbacks",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "CustomerLogos",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orde = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLogos", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerLogos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerFeedbacks",
                table: "CustomerFeedbacks");

            migrationBuilder.RenameTable(
                name: "CustomerFeedbacks",
                newName: "customerFeedbacks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customerFeedbacks",
                table: "customerFeedbacks",
                column: "ID");
        }
    }
}
