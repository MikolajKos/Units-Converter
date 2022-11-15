using Microsoft.EntityFrameworkCore.Migrations;

namespace UnitsConverterApp.Migrations
{
    public partial class RatioColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Ratio",
                table: "Units",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratio",
                table: "Units");
        }
    }
}
