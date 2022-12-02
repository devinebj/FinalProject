using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations.Game
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<string>(nullable: true),
                    Developer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Developer", "Rating", "ReleaseDate", "Title" },
                values: new object[] { 1, "Namco", "Everyone", new DateTime(1980, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pac-Man" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
