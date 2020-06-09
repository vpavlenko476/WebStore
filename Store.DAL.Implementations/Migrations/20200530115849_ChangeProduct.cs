using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DAL.Implementations.Migrations
{
    public partial class ChangeProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
