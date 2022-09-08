using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBll.Migrations
{
    public partial class BudgetContext_Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "LogsEntrie",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "LogsEntrie");
        }
    }
}
