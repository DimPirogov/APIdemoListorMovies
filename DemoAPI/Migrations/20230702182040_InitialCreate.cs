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
                name: "Lists",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.ListId);
                });

            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    ConversationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: true),
                    ConversationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.ConversationId);
                    table.ForeignKey(
                        name: "FK_Conversation_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "ListId");
                });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "ListId", "Date", "ListName" },
                values: new object[] { 1, new DateTime(2014, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "FirstList" });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "ListId", "Date", "ListName" },
                values: new object[] { 2, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "SecondList" });

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_ListId",
                table: "Conversation",
                column: "ListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropTable(
                name: "Lists");
        }
    }
}
