using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Admin.Migrations
{
    public partial class ThirdMigrationAdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
           name: "Admin",
           columns: table => new
           {
               AdminId = table.Column<long>(type: "bigint", nullable: false)
                   .Annotation("SqlServer:Identity", "1, 1"),
               FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
               LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
               Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
               Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_Users", x => x.AdminId);
           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Admin");
        }
    }
}
