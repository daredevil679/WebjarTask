using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebjarTask.Infrastructure.Migrations
{
    public partial class AddStockToPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stock",
                schema: "dbo",
                table: "ProductPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "dbo",
                table: "ProductPrice");
        }
    }
}
