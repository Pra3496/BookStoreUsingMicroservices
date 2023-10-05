using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Order.Migrations
{
    public partial class AddQuntityColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "OrderItems");
        }
    }
}
