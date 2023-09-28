using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Admin.Migrations
{
    public partial class SecondMigrationAdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Users");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
