using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorizationService.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.UserName);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "UserName", "Password" },
                values: new object[] { "adminbak01", "Firstpass@01" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "UserName", "Password" },
                values: new object[] { "adminbak02", "Secondpass@02" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
