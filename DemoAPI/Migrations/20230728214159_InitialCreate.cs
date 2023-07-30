using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_MovieLists_MovieListId",
                        column: x => x.MovieListId,
                        principalTable: "MovieLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MovieLists",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { 100, new DateTime(2014, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Firts List" });

            migrationBuilder.InsertData(
                table: "MovieLists",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { 101, new DateTime(2023, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second List" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Date", "MovieListId", "Name" },
                values: new object[] { 1, new DateTime(2014, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, "Hellraiser" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Date", "MovieListId", "Name" },
                values: new object[] { 2, new DateTime(2023, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, "Oppenheimer" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieListId",
                table: "Movies",
                column: "MovieListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "MovieLists");
        }
    }
}
