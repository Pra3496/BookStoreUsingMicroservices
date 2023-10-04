using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Cart.Migrations
{
    public partial class SecondMigrationAddQuientityColmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quntity",
                table: "Carts");
        }
    }
}
