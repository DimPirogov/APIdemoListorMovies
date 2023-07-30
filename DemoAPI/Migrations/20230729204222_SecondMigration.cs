using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MovieLists",
                keyColumn: "Id",
                keyValue: 100,
                column: "Name",
                value: "First List");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MovieLists",
                keyColumn: "Id",
                keyValue: 100,
                column: "Name",
                value: "Firts List");
        }
    }
}
