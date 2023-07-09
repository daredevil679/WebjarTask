using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebjarTask.Infrastructure.Migrations
{
    public partial class qwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFormulaPrice",
                schema: "dbo",
                table: "ProductPrice",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFormulaPrice",
                schema: "dbo",
                table: "ProductPrice");
        }
    }
}
